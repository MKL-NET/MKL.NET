namespace global

open System
open System.Threading
open System.Diagnostics
open System.Globalization
open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open CsCheck

[<AutoOpen>]
module Auto =
    let inline repeat n (f:unit->'a) () =
        for _ = 2 to n do f() |> ignore
        f()
    let inline zigzag i =
        (i <<< 1) ^^^ (i >>> 31) |> uint32
    let inline idiv (n:int) (d:int) =
        Math.Round(double n/double d) |> int
    let inline idiv64 (n:int64) (d:int64) =
        Math.Round(double n/double d) |> int64

type Accuracy =
    | Low
    | Medium
    | High
    | VeryHigh
    static member ($) (m:Accuracy,_:double) =
        match m with
        | Low -> fun a b -> 1e-6 + 1e-3 * max (abs a) (abs b)
        | Medium -> fun a b -> 1e-8 + 1e-5 * max (abs a) (abs b)
        | High -> fun a b -> 1e-10 + 1e-7 * max (abs a) (abs b)
        | VeryHigh -> fun a b -> 1e-12 + 1e-9 * max (abs a) (abs b)
    static member ($) (m:Accuracy,_:single) =
        match m with
        | Low -> fun a b -> 1e-3f + 1e-1f * max (abs a) (abs b)
        | Medium -> fun a b -> 1e-6f + 1e-3f * max (abs a) (abs b)
        | High -> fun a b -> 1e-8f + 1e-5f * max (abs a) (abs b)
        | VeryHigh -> fun a b -> 1e-10f + 1e-7f * max (abs a) (abs b)



module Accuracy =
    let inline areCloseLhs (a:'a) (b:'a) = abs(a-b)
    let inline areCloseRhs (m:Accuracy) : ('a -> 'a -> 'a) =
        m $ Unchecked.defaultof<'a>
    let inline areClose (m:Accuracy) =
        let rhs = areCloseRhs m
        fun a b -> areCloseLhs a b <= rhs a b

module private Result =
    let traverse f list =
        List.fold (fun s i ->
            match s,f i with
            | Ok l, Ok h -> Ok (h::l)
            | Error l, Ok _ -> Error l
            | Ok _, Error e -> Error [e]
            | Error l, Error h -> Error (h::l)
        ) (Ok []) list
    let sequence list = traverse id list

type Text =
    | For of string
    | Grey of string
    | Red of string
    | BrightRed of string
    | Green of string
    | BrightGreen of string
    | Yellow of string
    | BrightYellow of string
    | Blue of string
    | BrightBlue of string
    | Magenta of string
    | BrightMagenta of string
    | Cyan of string
    | BrightCyan of string
    | Text of struct (Text * Text)
    static member (+)(t1,t2) = Text(t1,t2)

module Text =
    [<Literal>]
    let private reset = "\u001b[0m"
    let rec private toANSIList t =
        match t with
        | For s -> [s]
        | Grey s -> ["\u001b[30;1m";s;reset]
        | Red s -> ["\u001b[31m";s;reset]
        | BrightRed s -> ["\u001b[31;1m";s;reset]
        | Green s -> ["\u001b[32m";s;reset]
        | BrightGreen s -> ["\u001b[32;1m";s;reset]
        | Yellow s -> ["\u001b[33m";s;reset]
        | BrightYellow s -> ["\u001b[33;1m";s;reset]
        | Blue s -> ["\u001b[34m";s;reset]
        | BrightBlue s -> ["\u001b[34;1m";s;reset]
        | Magenta s -> ["\u001b[35m";s;reset]
        | BrightMagenta s -> ["\u001b[35;1m";s;reset]
        | Cyan s -> ["\u001b[36m";s;reset]
        | BrightCyan s -> ["\u001b[36;1m";s;reset]
        | Text(t1,t2) -> toANSIList t1 @ toANSIList t2
    let toANSI t = toANSIList t |> String.Concat

type ListSlim<'k> =
    val mutable private count : int
    val mutable private entries : 'k[]
    new() = {count=0; entries=Array.empty}
    new(capacity:int) = {count = 0; entries = Array.zeroCreate capacity}

    member m.Count = m.count

    member m.Item
        with get i = m.entries.[i]
        and set i v = m.entries.[i] <- v

    member m.Add(key:'k) =
        let i = m.count
        if i = m.entries.Length then
            if i = 0 then
                m.entries <- Array.zeroCreate 4
            else
                let newEntries = i * 2 |> Array.zeroCreate
                Array.Copy(m.entries, 0, newEntries, 0, i)
                m.entries <- newEntries
        m.entries.[i] <- key
        m.count <- i+1
        i

    member m.ToArray() =
        Array.init m.count (Array.get m.entries)

    member m.ToList() =
        List.init m.count (Array.get m.entries)

[<Struct>]
type private Entry<'k,'v> =
    val mutable bucket : int
    val mutable key : 'k
    val mutable value : 'v
    val mutable next : int

type private InitialHolder<'k,'v>() =
    static let initial = Array.zeroCreate<Entry<'k,'v>> 1
    static member inline Initial = initial

type MapSlim<'k,'v when 'k : equality and 'k :> IEquatable<'k>> =
    val mutable private count : int
    val mutable private entries : Entry<'k,'v>[]
    new() = {count=0; entries=InitialHolder.Initial}
    new(capacity:int) = {
        count = 0
        entries =
            let inline powerOf2 v =
                if v &&& (v-1) = 0 then v
                else
                    let rec twos i =
                        if i>=v then i
                        else twos (i*2)
                    twos 2
            powerOf2 capacity |> Array.zeroCreate
    }

    member m.Count = m.count

    member private m.Resize() =
        let oldEntries = m.entries
        let entries = Array.zeroCreate<Entry<_,_>> (oldEntries.Length*2)
        for i = oldEntries.Length-1 downto 0 do
            entries.[i].value <- oldEntries.[i].value
            entries.[i].key <- oldEntries.[i].key
            let bi = entries.[i].key.GetHashCode() &&& (entries.Length-1)
            entries.[i].next <- entries.[bi].bucket-1
            entries.[bi].bucket <- i+1
        m.entries <- entries

    [<MethodImpl(MethodImplOptions.NoInlining)>]
    member private m.AddKey(key:'k, hashCode:int) =
        let i = m.count
        if i = 0 && m.entries.Length = 1 then
            m.entries <- Array.zeroCreate 2
        elif i = m.entries.Length then m.Resize()
        let entries = m.entries
        entries.[i].key <- key
        let bucketIndex = hashCode &&& (entries.Length-1)
        entries.[i].next <- entries.[bucketIndex].bucket-1
        entries.[bucketIndex].bucket <- i+1
        m.count <- i+1
        &entries.[i].value

    member m.Set(key:'k, value:'v) =
        let entries = m.entries
        let hashCode = key.GetHashCode()
        let mutable i = entries.[hashCode &&& (entries.Length-1)].bucket-1
        while i >= 0 && not(key.Equals(entries.[i].key)) do
            i <- entries.[i].next
        if i >= 0 then entries.[i].value <- value
        else
            let v = &m.AddKey(key, hashCode)
            v <- value

    member m.GetRef(key:'k) : 'v byref =
        let entries = m.entries
        let hashCode = key.GetHashCode()
        let mutable i = entries.[hashCode &&& (entries.Length-1)].bucket-1
        while i >= 0 && not(key.Equals(entries.[i].key)) do // check >= in IL
            i <- entries.[i].next
        if i >= 0 then &entries.[i].value
        else &m.AddKey(key, hashCode)

    member m.GetRef(key:'k, added: bool outref) : 'v byref =
        let entries = m.entries
        let hashCode = key.GetHashCode()
        let mutable i = entries.[hashCode &&& (entries.Length-1)].bucket-1
        while i >= 0 && not(key.Equals(entries.[i].key)) do
            i <- entries.[i].next
        if i >= 0 then
            added <- false
            &entries.[i].value
        else
            added <- true
            &m.AddKey(key, hashCode)

    member m.GetOption (key:'k) : 'v voption =
        let entries = m.entries
        let mutable i = entries.[key.GetHashCode() &&& (entries.Length-1)].bucket-1
        while i >= 0 && not(key.Equals(entries.[i].key)) do
            i <- entries.[i].next
        if i >= 0 then ValueSome entries.[i].value
        else ValueNone

    member m.Item i : 'k * 'v =
        let entries = m.entries.[i]
        entries.key, entries.value

    member m.Key i : 'k =
        m.entries.[i].key

type TestText =
    | Normal of string
    | Minor of string
    | TestName of string
    | Message of string
    | Alert of string
    | Numeric of obj
    | TestText of struct (TestText * TestText)
    static member (+)(t1,t2) = TestText (t1,t2)
    static member (+)(s:string,t) = TestText(Normal s,t)
    static member (+)(t,s:string) = TestText(t,Normal s)

module TestText =
    let rec toText t =
        match t with
        | Normal s -> For s
        | Minor s -> Grey s
        | TestName s -> BrightGreen s
        | Message s -> BrightYellow s
        | Alert s -> BrightRed s
        | Numeric o ->
            match o with
            | :? int as i -> i.ToString("#,##0")
            | :? int64 as i -> i.ToString("#,##0")
            | :? uint64 as i -> i.ToString("#,##0")
            | o -> string o
            |> BrightCyan
        | TestText(t1,t2) -> Text(toText t1,toText t2)

[<AllowNullLiteral>]
type FasterAggregation =
    val Message : string
    val Median : MedianEstimator
    val mutable Faster : int
    val mutable Slower : int
    val mutable Error : bool
    new(message:string) = {Message=message;Median=MedianEstimator();Faster=0;Slower=0;Error=false}
    member m.Variance = double(m.Faster-m.Slower) * double(m.Faster-m.Slower) / double(m.Faster+m.Slower)
    member m.Sigma = sqrt m.Variance

type TestResult =
    | Success
    | Failure of TestText
    | Exception of exn
    | Information of string
    | Label of string
    | Faster of message: string * sample: double
    | FasterAgg of FasterAggregation
    static member hasErrs (r:TestResult list) =
        List.exists (function | Failure _ | Exception _ -> true | FasterAgg fa when fa.Error -> true | _ -> false) r

[<Struct>]
type Test = private Test of string list * (PCG->(TestResult list option->unit)->unit)

type TestBuilder(name:string) =
    let sizeMins = MapSlim<int,Size>()
    let faster = MapSlim<int,FasterAggregation>()
    let nameList = if isNull name then [] else [name]
    let zero = Test(nameList, fun _ c -> c(Some[]))
    let mutable delayed = false
    member _.Zero() = zero
    member _.Yield (a:TestResult,
        [<CallerLineNumberAttribute;Optional;DefaultParameterValue 0>]line:int) =
        match a with
        | Success -> zero
        | Faster(m,s) ->
            lock faster (fun () ->
                let fa = &faster.GetRef line
                if isNull fa then fa <- FasterAggregation m
                if fa.Error |> not then
                    fa.Median.Add s
                    if s>0.0 then fa.Faster <- fa.Faster + 1
                    elif s<0.0 then fa.Slower <- fa.Slower + 1
                    if fa.Faster < fa.Slower && fa.Variance > 36.0 then fa.Error <- true
                let r = Some [FasterAgg fa]
                Test(nameList, fun _ c -> c r)
            )
        | _ -> let r = Some [a]
               Test(nameList, fun _ c -> c r)
    member _.Yield(Test(n,f)) =
        [Test((if isNull name then n else name::n),f)]
    member _.Yield (l:Test list) =
        List.map (fun (Test(n,f)) -> Test((if isNull name then n else name::n),f)) l
    member _.Combine (Test(_,f1),Test(_,f2)) =
        Test((if isNull name then [] else [name]), fun p c ->
            f1 p (function
                  | Some r1 ->
                      f2 p (function
                            | Some r2 -> c(Some(r1 @ r2))
                            | None -> c None
                      )
                  | None -> c None
            )
        )
    member inline _.Combine (l1:Test list,l2:Test list) =
        l1 @ l2
    member inline _.Combine (l1:Test list,t2:Test) =
        l1 @ [t2]
    member _.Delay(f:unit->Test) =
        if delayed then f()
        else
            delayed <- true
            Test(nameList, fun p c ->
                try
                    let (Test(_,f)) = f()
                    f p c
                with e -> c(Some [Exception e])
            )
    member inline _.Delay(f:unit->Test list) =
        f()
    member inline m.Bind(t:Test,f:unit->Test) =
        m.Combine(t, m.Delay f)
    member _.Bind(g:#Gen<'a>,f:'a->Test,
      [<CallerLineNumberAttribute;Optional;DefaultParameterValue 0>]line:int) =
        Test(nameList, fun p c ->
            let struct (a,s) = g.Generate p
            match sizeMins.GetOption line with
            | ValueSome v when v.IsLessThan s -> c None
            | _ ->
                let (Test(_,tf)) = f a
                tf p (function
                      | None -> c None
                      | Some r ->
                            if TestResult.hasErrs r then
                                //lock sizeMins (fun () ->
                                    let m = &sizeMins.GetRef line
                                    if isNull m || not(m.IsLessThan s) then
                                        m <- s
                                        Some r
                                    else None
                                    |> c
                                //) |> c
                            else c(Some r)
                )
        )
    member _.While(guard, body:unit->Test) =
        let ts = ListSlim()
        while guard() do
            let (Test(_,f)) = body()
            ts.Add f |> ignore
        Test((if isNull name then [] else [name]), fun p c ->
            let mutable running = true
            let mutable l = []
            for i = 0 to ts.Count-1 do
                ts.[i] p (function | None -> running <- false | Some r -> l <- l @ r)
            c(if running then Some l else None)
        )
    member _.TryFinally(body, compensation) =
        try body()
        finally compensation()
    member m.Using(d:#IDisposable, body) =
        m.TryFinally((fun () -> body d), fun () -> d.Dispose())
    member m.For(s:seq<'a>,body:'a->Test) =
        let e = s.GetEnumerator()
        m.While(e.MoveNext, fun () -> body e.Current)

[<AutoOpen>]
module TestAutoOpen =
    let test name = TestBuilder name

type Config =
    | Filt of string list
    | Para of int
    | Seed of PCG
    | Iter of int
    | Time of double
    | Memo of double
    | Wait of double
    | Info
    | Skip
    | Stop
    | NoSt
    | NoPr
    | Meas

module Config =

    type private Parser<'a> = (string[] * int * int) -> Result<'a,string> * int

    let inline private none case : Parser<_> =
        fun (_,_,l) -> Ok case, l

    let inline private string case : Parser<_> =
        fun (ss,i,l) ->
            if l>0 then Ok(case ss.[i]), l-1
            else Error "requires a parameter", 0

    let inline private list (parser:_->Parser<_>) case : Parser<_> =
        fun (ss,i,l) ->
            [i..i+l-1]
            |> Result.traverse (fun j -> parser id (ss,j,1) |> fst)
            |> Result.map (fun l -> case(List.rev l))
            |> Result.mapError (fun i -> String.Join(", ", i))
            , 0

    let inline private parseWith tryParseFn case: Parser<'a> =
        fun (args, i, l) ->
            if l = 0 then Error "requires a parameter", 0
            else
                match tryParseFn args.[i] with
                | Some i -> Ok(case i), l-1
                | None -> Error("Cannot parse parameter '" + args.[i] + "'"), l-1

    let inline private parseExact parseFn case : Parser<'a> =
        fun (args, i, l) ->
            if l = 0 then Error "requires a parameter", 0
            else parseFn args.[i] |> case |> Ok, l-1

    let inline tryParse (s: string) =
        let mutable r = Unchecked.defaultof<_>
        if (^a : (static member TryParse: string * ^a byref -> bool) (s, &r))
        then Some r else None

    let inline private tryParseNumber (s: string) =
        let mutable r = Unchecked.defaultof<_>
        if (^a : (static member TryParse: string * NumberStyles * IFormatProvider * ^a byref -> bool)
                                            (s, NumberStyles.Any, CultureInfo.InvariantCulture, &r))
        then Some r else None

    let inline private number case: Parser<'a> = parseWith tryParseNumber case

    let private options = [
        "--filt", "Test name filters (switch not required if first argument).", list string Filt
        "--para", "Number of parallel threads.", number Para
        "--seed", "First thread starts with this seed.", parseExact PCG.Parse Seed
        "--iter", "Run tests randomly for this number of iterations (defaults to 1).", number Iter
        "--time", "Run tests randomly for this time in seconds.", number Time
        "--memo", "Memory limit in MB (defaults to 100 MB).", number Memo
        "--wait", "Wait up to this number of seconds after last test started before reporting a timeout (defaults to 1).", number Wait
        "--info", "Include info messages in the output.", none Info
        "--skip", "Skip failed random, passed none random and passed faster tests.", none Skip
        "--stop", "Stop on first failure.", none Stop
        "--nost", "No progress status spinner.", none NoSt
        "--nopr", "No console output.", none NoPr
        "--meas", "Measure test run time.", none Meas
    ]

    let parse (strings:string[]) =
        let strings = if strings.Length > 0 && strings.[0].StartsWith("--") then strings
                      else Array.append [|"--filt"|] strings
        let rec updateUnknown unknown last length =
            if length = 0 then unknown
            else updateUnknown (strings.[last]::unknown) (last-1) (length-1)
        let rec collect isHelp unknown args paramCount i =
            if i>=0 then
                let currentArg = strings.[i]
                if currentArg = "--help" || currentArg = "-h" || currentArg = "-?" || currentArg = "/?" then
                    collect true (updateUnknown unknown (i+paramCount) paramCount) args 0 (i-1)
                else
                    match List.tryFind (fun (i,_,_) -> i = currentArg) options with
                    | Some (option, _, parser) ->
                        let arg, unknownCount = parser (strings, i+1, paramCount)
                        collect isHelp
                            (updateUnknown unknown (i+paramCount) unknownCount)
                            (Result.mapError (fun i -> option + " " + i) arg::args) 0 (i-1)
                    | None -> collect isHelp unknown args (paramCount+1) (i-1)
            else
                let unknown =
                    match updateUnknown unknown (paramCount-1) paramCount with
                    | [] -> None
                    | l -> String.Join(" ","unknown options:" :: l) |> Some
                match isHelp, Result.sequence args, unknown with
                | false, Ok os, None -> Ok(List.rev os)
                | true, Ok _, None -> Error []
                | _, Ok _, Some u -> Error [u]
                | _, r, None -> r
                | _, Error es, Some u -> List.rev (u::es) |> Error
        collect false [] [] 0 (strings.Length-1)

    let usage commandName =
        let sb = Text.StringBuilder("Usage: ")
        let add (text:string) = sb.Append(text) |> ignore
        add commandName
        add " [options]\n\nOptions:\n"
        let maxLength =
            options |> Seq.map (fun (s,_,_) -> s.Length) |> Seq.max
        ["--help","Show this help message."]
        |> Seq.append (Seq.map (fun (s,d,_) -> s,d) options)
        |> Seq.iter (fun (s,d) ->
            add "  "
            add (s.PadRight maxLength)
            add "  "
            add d
            add "\n"
        )
        sb.ToString()

type private TestData = {
    Name: string
    mutable Method: PCG -> (TestResult list option -> unit) -> unit
    mutable Skip: int
    mutable Result: (TestResult list * (PCG * uint64) option) option
}

type private RunCounts = {
    mutable Threads : CountdownEvent
    mutable Tests : int
    mutable Passed : int64
    mutable Failed : int64
    mutable Skipped : int64
}

type private Worker(pcg:PCG option,nextTest:unit->TestData option,tc:RunCounts,skip,stopOnError) as worker =
    [<DefaultValue>]
    val mutable Running : TestData option
    let rec run (pcg:PCG) =
        match nextTest() with
        | None ->
            worker.Running <- None
            tc.Threads.Signal() |> ignore
        | Some t ->
            worker.Running <- Some t
            if t.Skip=0 then
                let stateBefore = pcg.State
                t.Method pcg (fun r ->
                    match r with
                    | None -> Interlocked.Increment &tc.Skipped |> ignore
                    | Some r ->
                        let seed = if pcg.State=stateBefore then None else Some(pcg,stateBefore)
                        if TestResult.hasErrs r then
                            if skip || Option.isNone seed then
                                if Interlocked.Increment &t.Skip = 1 then Interlocked.Decrement &tc.Tests |> ignore
                            t.Result <- Some(r,seed)
                            Interlocked.Increment &tc.Failed |> ignore
                            if stopOnError then tc.Threads.Reset 0
                        else
                            if skip && r |> List.exists (function |FasterAgg a -> a.Faster > a.Slower && a.Variance > 36.0 | _ -> false) then
                                if Interlocked.Increment &t.Skip = 1 then Interlocked.Decrement &tc.Tests |> ignore
                            Interlocked.Increment &tc.Passed |> ignore
                            if t.Result=None then
                                if skip && Option.isNone seed && List.exists (function |FasterAgg _ -> true | _ -> false) r |> not then
                                    if Interlocked.Increment &t.Skip = 1 then Interlocked.Decrement &tc.Tests |> ignore
                                t.Result <- Some(r,None)
                    ThreadPool.UnsafeQueueUserWorkItem(WaitCallback worker.Execute, false) |> ignore
                )
            else
                Interlocked.Increment &tc.Skipped |> ignore
                run pcg
    do ThreadPool.UnsafeQueueUserWorkItem(WaitCallback worker.Execute, false) |> ignore
    member _.Execute(_:obj) =
        let pcg = match pcg with Some p -> p | None -> PCG.ThreadPCG
        run pcg

module Tests =

    let private validUriChar c =
        (c>='a' && c<= 'z') || c='_' || c>='0' && c<='9' || (c>='A' && c<= 'Z') || c='-'

    let private validateTestNames tests =
        let duplicates =
            Seq.countBy (fun (Test(n,_)) -> n) tests
            |> Seq.choose (fun (n,c) -> if c=1 then None else Some n)
            |> Seq.toList
        let invalidUris =
            Seq.collect (fun (Test(n,_)) -> n) tests
            |> Seq.distinct
            |> Seq.where (fun s -> Seq.forall validUriChar s |> not)
            |> Seq.toList
        duplicates, invalidUris

    let private filterTests config tests =
        let includes,excludes =
            List.collect (function | Filt f -> f | _ -> []) config
            |> List.fold (fun (i,e) s -> if s.[0]='-' then i,s.Substring 1::e else s::i,e) ([],[])
        let ts =
            if List.isEmpty includes then tests
            else List.collect (fun (f:string) -> List.where (fun (Test(n,_)) -> String.Join(".",n).Contains f) tests) includes
                 |> List.distinctBy (fun (Test(n,_)) -> n)
        List.fold (fun l (e:string) -> List.where (fun (Test(n,_)) -> String.Join(".",n).Contains e |> not) l) ts excludes
        |> List.map (fun (Test(n,f)) -> {Name=String.Join(".",n); Method=f; Skip=0; Result=None})
        |> List.toArray

    let private testResultWriteLine config =
        let info = List.contains Info config
        fun (name:string) (results,seed) ->
            let rows =
                List.choose (function
                    | Success | Label _ -> None
                    | Failure t -> Alert "  FAIL: " + t |> Some
                    | Exception e ->
                        Alert "  EXCN: " + Message e.Message + " " +
                        Minor(string(e.GetType())) + "\n" + string e.StackTrace |> Some
                    | Information s -> if info then Some(Normal "  INFO: " + s) else None
                    | Faster(_,_) -> failwith "Should be FasterAgg now"
                    | FasterAgg fa ->
                        if fa.Error || info then
                            let me = fa.Median
                            let range = "%[-" + Numeric((me.MADless*100.0).ToString("#0")) + "..+" + Numeric((me.MADmore*100.0).ToString("#0")) + "]"
                            let result = if me.Median >= 0.0 then Numeric((me.Median*100.0).ToString("#0.0")) + range + " faster"
                                         else Numeric((me.Median*100.0 / (-1.0 - me.Median)).ToString("#0.0")) + range + " slower"
                            if fa.Error then Alert "  FAIL: " + Message fa.Message + result
                            else Normal "  INFO: " + Message fa.Message + result
                            + ", sigma=" + Numeric(fa.Sigma.ToString("#0.0")) + " ("+Numeric fa.Faster+" vs "+Numeric(fa.Slower)+")" |> Some
                        else None
                ) results
            if List.isEmpty rows then None
            else
                let n = match seed with None -> name | Some(p:PCG,s) -> name + " --seed " + p.ToString s
                TestName n :: rows
                |> List.reduce (fun a b -> a+"\n"+b) |> Some

    let run (config:Config list) (tests:Test list) =
        let counts = {Threads=new CountdownEvent 0; Tests = 0; Passed=0L; Failed=0L; Skipped=0L}
        let print, status =
            let inline toStr t = TestText.toText t |> Text.toANSI
            if List.contains NoPr config then ignore,ignore
            elif List.contains NoSt config then
                (toStr >> Console.WriteLine),ignore
            else let clear = "      \u001b[1000D\u001b[?25h"
                 Console.CancelKeyPress
                 |> Event.add (fun a ->
                    Console.Write clear
                    counts.Threads.Reset 0
                    a.Cancel <- true
                 )
                 fun (t:TestText) -> clear + t |> toStr |> Console.WriteLine
                 ,fun (t:TestText) -> t + "\u001b[1000D\u001b[?25l"
                                      |> toStr |> Console.Write
        match validateTestNames tests with
        | [],[] ->
            let allTestCount = List.length tests
            let tests = filterTests config tests
            let printResults =
                if List.contains Meas config then
                    let mes = Array.zeroCreate tests.Length
                    Array.iteri (fun i t ->
                        let me = MedianEstimator()
                        mes.[i] <- me
                        let f = t.Method
                        t.Method <- fun p c ->
                                        let t = Stopwatch.GetTimestamp()
                                        f p (fun r ->
                                            me.Add(double(Stopwatch.GetTimestamp() - t))
                                            c r
                                        )
                    ) tests
                    fun () ->
                        let results =
                            Array.map2 (fun (t:TestData) (me:MedianEstimator) ->
                                match t.Result with
                                | None -> 0.0, None
                                | Some(rs,seed) ->
                                    let m = Message "Duration " + Numeric((1000.0*me.Median/double Stopwatch.Frequency).ToString("#0.000")) +
                                            "ms[-" + Numeric((1000.0*me.MADless/double Stopwatch.Frequency).ToString("#0.000")) +
                                            "..+" + Numeric((1000.0*me.MADmore/double Stopwatch.Frequency).ToString("#0.000")) + "]"
                                    let time = TestText.toText m |> Text.toANSI |> Information
                                    me.Median, testResultWriteLine config t.Name (time::rs,seed)
                            ) tests mes
                        Array.sortInPlaceBy fst results
                        Array.iter (snd >> Option.iter print) results
                else fun () ->
                        Array.iter (fun i -> match i.Result with
                                             | None -> ()
                                             | Some r -> testResultWriteLine config i.Name r
                                                        |> Option.iter print) tests
            let mutable timeout = Int64.MaxValue
            let wait = List.tryPick (function Wait t -> Some t | _ -> None) config
                       |> Option.defaultValue 1.0 |> (*) 1000.0 |> int64
            let startTime = Stopwatch.GetTimestamp()
            counts.Tests <- tests.Length
            let rec randomTest (pcg:PCG) =
                let c = counts.Tests
                if c=0 then None
                else
                    let rec loop i t =
                        if i = tests.Length then None
                        else
                            if tests.[i].Skip=0 && t=0 then Some i
                            else loop (i+1) (if t=0 then t else t-1)
                    match loop 0 (int(pcg.Next(uint32 c))) with
                    | Some test -> Some test
                    | None -> randomTest pcg
            let workers, progress =
                let skip = List.contains Skip config
                let stopOnError = List.contains Stop config
                let seed = List.tryPick (function Seed s -> Some s | _ -> None) config
                match List.tryPick (function Time t -> Some t | _ -> None) config with
                | Some t -> // Time
                    let endTime = startTime + int64(t * double Stopwatch.Frequency)
                    timeout <- endTime + wait * Stopwatch.Frequency / 1000L
                    let noThreads = if tests.Length = 0 then 0
                                    else List.tryPick (function Para s -> Some s | _ -> None) config
                                         |> Option.defaultWith Environment.get_ProcessorCount
                    counts.Threads.Reset noThreads
                    let workers = Array.init noThreads (fun _ ->
                        let pcg = PCG.ThreadPCG
                        Worker(seed,
                            (fun () -> if Stopwatch.GetTimestamp() > endTime then None
                                       else randomTest pcg |> Option.map (Array.get tests)),
                            counts, skip, stopOnError)
                    )
                    "Running " + Numeric tests.Length + " (out of " +
                    Numeric allTestCount + ") tests for " + Numeric(int(t + 0.5))
                    + " seconds on " + Numeric noThreads + " threads." |> print
                    workers, fun now -> 100L * (now - startTime) / (endTime - startTime) |> int
                | None -> // Iter
                    let iters = List.tryPick (function Iter s -> Some s | _ -> None) config |> Option.defaultValue 1
                    let noThreads = List.tryPick (function Para s -> Some s | _ -> None) config
                                    |> Option.defaultWith Environment.get_ProcessorCount
                                    |> min (tests.Length * iters)
                    counts.Threads.Reset noThreads
                    let testRunCount = Array.zeroCreate<int> tests.Length
                    let mutable testsLeft = tests.Length * iters
                    let workers = Array.init noThreads (fun _ ->
                        let pcg = PCG.ThreadPCG
                        Worker(seed,
                            (fun () ->
                                let tl = Interlocked.Decrement &testsLeft
                                if tl = 0 then timeout <- Stopwatch.GetTimestamp() + wait * Stopwatch.Frequency / 1000L
                                if tl < 0 then None
                                else let rec nextTest() =
                                        match randomTest pcg with
                                        | None -> None
                                        | Some t ->
                                            let n = Interlocked.Increment &testRunCount.[t]
                                            if n <= iters then Some tests.[t]
                                            else
                                                if n=iters+1 && Interlocked.Increment &tests.[t].Skip = 1 then Interlocked.Decrement &counts.Tests |> ignore
                                                nextTest()
                                     nextTest() ),
                                counts, skip, stopOnError)
                    )
                    "Running " + Numeric tests.Length + " (out of " +
                    Numeric allTestCount + ") tests for " + Numeric iters +
                    " iterations on " + Numeric noThreads + " threads." |> print
                    workers, fun _ -> (1.0 - double testsLeft / double(tests.Length*iters)) * 100.0 |> int
            let inline printThreads() =
                workers |> Array.iteri (fun i w ->
                    Option.iter (fun t ->
                        let th = i.ToString().PadLeft(3)
                        "Thread " + Numeric th + ": " + TestName t.Name
                        |> print
                    ) w.Running
                )
            let memoryLimit = List.tryPick (function Memo l -> Some l | _ -> None) config
                              |> Option.defaultValue 100.0 |> (*) (1024.0 * 1024.0) |> int64
            let doStatus = List.contains NoSt config |> not
            let rec monitor maxMemory =
                let mem = GC.GetTotalMemory false
                if mem > memoryLimit then
                    printResults()
                    Alert "Memory limited exceeded: " + Numeric(mem/1024L) +
                    " KB (limit set at " + Numeric(memoryLimit/1024L) + " KB)." +
                    Message "\nTests running:" |> print
                    printThreads()
                    3
                elif Stopwatch.GetTimestamp() >= timeout then
                    printResults()
                    Alert "Timeout!" + Message "\nTests running:" |> print
                    printThreads()
                    2
                elif counts.Tests = 0 || int wait |> min 250 |> counts.Threads.Wait then
                    printResults()
                    let timeTaken = int((Stopwatch.GetTimestamp() - startTime) / Stopwatch.Frequency)
                    let p,f,s = counts.Passed, counts.Failed, counts.Skipped
                    "Maximum memory usage was " + Numeric(maxMemory/1024L) + " KB (limit set at " +
                    Numeric(memoryLimit/1024L) + " KB).\n" + Numeric(p + f + s) +
                    " tests run in " + Numeric timeTaken + " seconds: " + Numeric p +
                    " passed, " + Numeric f + " failed, " + Numeric s + " skipped. " +
                    (if f = 0L then TestName "Success!" else Alert "Failure!") |> print
                    if f = 0L then 0 else 1
                else
                    if doStatus then
                        let now = Stopwatch.GetTimestamp()
                        let percent = string(progress now).PadLeft(3)
                        let a = match int(now / (Stopwatch.Frequency / 4L)) % 4 with
                                | 0 -> "% |" | 1 -> "% /" | 2 -> "% -" | _ -> "% \\"
                        Numeric percent + Minor a |> status
                    monitor (max maxMemory mem)
            monitor 0L
        | dups, invalid ->
            List.iter (fun (n:string list) -> Alert "Duplicate test name: " + TestName(String.Join(".",n)) |> print) dups
            List.iter (fun (n:string) -> Alert "Invalid test name (A-Z,a-z,0-9,-,_): " + TestName n |> print) invalid
            4