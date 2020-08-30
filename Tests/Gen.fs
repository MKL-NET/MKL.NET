module Gen

open System
open Microsoft.FSharp.Core

let pin (a:'a) (g:Gen<'a>) =
    { new Gen<_> with
        member _.Gen r =
            g.Gen r |> ignore
            a, Size.zero
    }

let tuple (ga:Gen<_>) (gb:Gen<_>) =
    { new Gen<_> with
        member _.Gen r =
            let a,sa = ga.Gen r
            let b,sb = gb.Gen r
            (a,b), Size(0UL,[sa;sb])
    }
    
let tuple2 (ga:Gen<_>) (gb:Gen<_>) (gc:Gen<_>) =
    { new Gen<_> with
        member _.Gen r =
            let a,sa = ga.Gen r
            let b,sb = gb.Gen r
            let c,sc = gc.Gen r
            (a,b,c), Size(0UL,[sa;sb;sc])
    }

let map (f:'a->'b) (g:Gen<'a>) =
    { new Gen<_> with
        member _.Gen r =
            let a,s = g.Gen r
            f a,s
    }

let map2 (f:'a->'b->'c) (ga:Gen<'a>) (gb:Gen<'b>) =
    { new Gen<_> with
        member _.Gen r =
            let a,sa = ga.Gen r
            let b,sb = gb.Gen r
            f a b, Size(0UL,[sa;sb])
    }

let map3 (f:'a->'b->'c->'d) (ga:Gen<'a>) (gb:Gen<'b>) (gc:Gen<'c>) =
    { new Gen<_> with
        member _.Gen r =
            let a,sa = ga.Gen r
            let b,sb = gb.Gen r
            let c,sc = gc.Gen r
            f a b c, Size(0UL,[sa;sb;sc])
    }

let bind (f:'a->Gen<'b>) (g:Gen<'a>) =
    { new Gen<_> with
        member _.Gen r =
            let gb = g.Gen r |> fst |> f
            gb.Gen r
    }

let inline private genRange (f:'a option*'a option -> PCG -> 'b * Size) =
    let normal = f (None,None)
    let genNormal = { new Gen<_> with member _.Gen r = normal r }
    { new GenRange<'a,'b> with
        member _.Gen r = normal r
        member _.GetSlice(s,e) =
            match s, e with
            | None, None -> genNormal
            | s, e ->
                let f = f (s,e)
                { new Gen<_> with member _.Gen r = f r }
        }

let byte =
    genRange (fun (s,e) ->
        let s = defaultArg s 0
        let e = defaultArg e 255 - s + 1
        fun (r:PCG) ->
            let i = r.Next e + s
            byte i, Size(uint64 i,[])
    )

let uint =
    genRange (fun (s,e) ->
        let s = defaultArg s 0u
        let e = int(defaultArg e (uint32(Int32.MaxValue))) - int s + 1
        fun (r:PCG) ->
            let i = uint32(r.Next e) + s
            i, Size(uint64 i,[])
    )

let int =
    genRange (fun (s,e) ->
        let s = defaultArg s 0
        let e = defaultArg e Int32.MaxValue - s + 1
        fun (r:PCG) ->
            let i = r.Next e + s
            i, Size(uint64(zigzag -i),[])
    )

let inline private genFloat (r:PCG) =
    let i = r.Next64() >>> 12
    BitConverter.Int64BitsToDouble(int64 i ||| 0x3FF0000000000000L) - 1.0, uint64 i

let float =
    genRange (fun (s,e) ->
        let s = defaultArg s 0.0
        let e = defaultArg e 1.0 - s
        fun (r:PCG) ->
            let f,i = genFloat r
            f * e + s, Size(i,[])
    )

type GenCollection<'a,'b>(gc:int -> Gen<'a> -> Gen<'b>) =
    member _.GetSlice(s:int option,e:int option) : #Gen<'a> -> Gen<'b> =
        let gl = int.GetSlice(s,e)
        fun g -> bind (fun l -> gc l g) gl
    member m.Item
        with get(length:int) = // #Gen<'a> -> Gen<'b> not possible for some reason which is a shame.
            gc length

let array<'a> = GenCollection<'a,'a[]>(fun length g ->
    { new Gen<_> with
        member _.Gen r =
            let l,s = Array.init length (fun _ -> g.Gen r) |> Array.unzip
            l, Size(uint64 length <<< 32,Array.toList s)
    }
)

let list<'a> = GenCollection<'a,'a list>(fun length g ->
    { new Gen<_> with
        member _.Gen r =
            let l,s = List.init length (fun _ -> g.Gen r) |> List.unzip
            l, Size(uint64 length <<< 32,s)
    }
)

let seq<'a> = GenCollection<'a,'a seq>(fun length g ->
    { new Gen<_> with
        member _.Gen r =
            let l = Seq.init length (fun _ -> g.Gen r |> fst)
            l, Size(uint64 length <<< 32,[])
    }
)

let oneOf (gs:Gen<'a> list) =
    { new Gen<_> with
        member _.Gen r =
            let gu = int.[..gs.Length]
            let i = gu.Gen r |> fst
            let gi = gs.[i]
            let a,s = gi.Gen r
            a, Size(uint64 i,[s])
    }

let uint64 =
    genRange (fun (s,e) ->
        let s = defaultArg s 0UL
        let e = int64(defaultArg e (uint64(Int64.MaxValue)) - s + 1UL)
        fun (r:PCG) ->
            let i = uint64(r.Next64 e) + s
            i, Size(i,[])
    )

let char =
    genRange (fun (s:char option,e:char option) ->
        let s = match s with None -> 0 | Some c -> Operators.int c
        let e = match e with None -> 128 - s | Some c -> Operators.int c - s + 1
        fun (r:PCG) ->
            let i = r.Next e + s
            char i, Size(Operators.uint64 i,[])
    )

let string =
    let d = array.[..200] char |> map String
    { new GenRange<int,string> with
        member _.Gen r = d.Gen r
        member _.GetSlice(s,e) =
            match s, e with
            | None, None -> d
            | None, Some e -> array.[..e] char |> map String
            | Some s, None -> array.[s..200] char |> map String
            | Some s, Some e -> array.[s..e] char |> map String
    }