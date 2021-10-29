module Check

open System
open System.Numerics
open System.Diagnostics
open MKLNET

let info fmt =
    let sb = System.Text.StringBuilder()
    Printf.kbprintf (fun () -> sb.Replace("\n","").ToString() |> Information) sb fmt

let label s = Label s

let message format =
    Printf.kprintf (fun msg ->
        function
        | Failure f -> Failure(Message msg + ": " + f)
        | Faster (_,f,s) -> Faster(msg,f,s)
        | r -> r
    ) format

let isTrue (actual:bool) =
    if actual then Success
    else Failure(Normal "actual is false.")

let isFalse (actual:bool) =
    if actual then Failure(Normal "actual is true.")
    else Success

let equal (expected:'a) (actual:'a) =
    let rec equal (expected:obj) (actual:obj) =
        let equalArray (e:'b[]) (a:'b[]) =
            if e.Length = a.Length then
                Array.fold2 (fun (i,s) e a ->
                    match s with
                    | Success ->
                        i+1, equal e a
                    | f -> i,f
                ) (-1,Success) e a
                |> function | i, Failure t -> Failure(Normal "Index: " + Numeric i + ". " + t)
                            | _, r -> r
            else
                Failure(Normal "Length differs. expected: " + Numeric e.Length + " actual: " + Numeric a.Length)
        let inline equalDefault (e:'b) (a:'b) =
            let e = (string e).Replace("\n","")
            let a = (string a).Replace("\n","")
            Failure(Normal "actual is not equal to expected.\n     actual: " + Numeric a + "\n   expected: " + Numeric e)
        match expected, actual with
        | (:? double as e), (:? double as a) ->
            if e=a || Double.IsNaN a && Double.IsNaN e then Success
            else equalDefault e a
        | (:? single as e), (:? single as a) ->
            if e=a || Single.IsNaN a && Single.IsNaN e then Success
            else equalDefault e a
        | (:? (double[]) as e), (:? (double[]) as a) -> equalArray e a
        | (:? (single[]) as e), (:? (single[]) as a) -> equalArray e a
        | (:? (Complex[]) as e), (:? (Complex[]) as a) -> equalArray e a
        | (:? (int[]) as e), (:? (int[]) as a) -> equalArray e a
        | e, a ->
            if a=e then Success
            else equalDefault e a
    equal expected actual

let zero (actual:'a) =
    equal (Unchecked.defaultof<_>) actual

let between (startInclusive:'a) (endInclusive:'a) (actual:'a) =
    if actual < startInclusive then
        Failure(Normal "actual " + Numeric actual + " is less than start " + Numeric startInclusive + ".")
    elif actual > endInclusive then
        Failure(Normal "actual " + Numeric actual + " is greater than end " + Numeric endInclusive + ".")
    else Success

let greaterThan (expected:'a) (actual:'a) =
    if actual > expected then Success
    else Failure(Normal "actual " + Numeric actual + " is not greater than " + Numeric expected + ".")

let greaterThanOrEqual (expected:'a) (actual:'a) =
    if actual >= expected then Success
    else Failure(Normal "actual " + Numeric actual + " is less than " + Numeric expected + ".")

let notDefaultValue (actual:'a) =
    if actual <> Unchecked.defaultof<'a> then Success
    else Failure(Normal "actual " + Numeric actual + " is the default value.")

let close accuracy (expected:'a) (actual:'a) =
    let rec close (expected:obj) (actual:obj) =
        let closeArray (e:'b[]) (a:'b[]) =
            if e.Length = a.Length then
                Array.fold2 (fun (i,s) e a ->
                    match s with
                    | Success ->
                        i+1, close e a
                    | f -> i,f
                ) (-1,Success) e a
                |> function | i, Failure t -> Failure(Normal "Index: " + Numeric i + ". " + t)
                            | _, r -> r
            else
                Failure(Normal "Length differs. expected: " + Numeric e.Length + " actual: " + Numeric a.Length)
        let inline closeDefault (e:'b) (a:'b) =
            Failure(Normal "actual=" + Numeric a + " expected=" + Numeric e
            + " (difference " + Numeric(Accuracy.areCloseLhs a e)
            + " not less than " + Numeric(Accuracy.areCloseRhs accuracy a e)
            + ")."
            )
        match expected, actual with
        | (:? double as e), (:? double as a) ->
            if Accuracy.areClose accuracy e a
             || Double.IsNaN a && Double.IsNaN e
             || Double.IsPositiveInfinity a && Double.IsPositiveInfinity e
             || Double.IsNegativeInfinity a && Double.IsNegativeInfinity e
             then Success
            else closeDefault e a
        | (:? single as e), (:? single as a) ->
            if Accuracy.areClose accuracy e a
             || Single.IsNaN a && Single.IsNaN e
             || Single.IsPositiveInfinity a && Single.IsPositiveInfinity e
             || Single.IsNegativeInfinity a && Single.IsNegativeInfinity e
             then Success
            else closeDefault e a
        | (:? (double[]) as e), (:? (double[]) as a) -> closeArray e a
        | (:? (single[]) as e), (:? (single[]) as a) -> closeArray e a
        | (:? vector as e), (:? vector as a) ->
            if e.Length <> a.Length then Failure(Normal "Vector size differs. expected: "
                                            + Numeric e.Length + " actual: "
                                            + Numeric a.Length)
            else
                let rec check i =
                    match close e.[i] a.[i] with
                    | Success ->
                        if i+1=e.Length then Success
                        else check (i+1)
                    | Failure t -> Failure(Normal "At " + Numeric i + " Size " + Numeric e.Length + ". " + t)
                    | f -> Failure(Normal "At " + Numeric i + " Size " + Numeric e.Length + ". " + f.ToString())
                check 0
        | (:? vectorT as e), (:? vectorT as a) ->
            if e.Length <> a.Length then Failure(Normal "VectorT size differs. expected: "
                                            + Numeric e.Length + " actual: "
                                            + Numeric a.Length)
            else
                let rec check i =
                    match close e.[i] a.[i] with
                    | Success ->
                        if i+1=e.Length then Success
                        else check (i+1)
                    | Failure t -> Failure(Normal "At " + Numeric i + " Size " + Numeric e.Length + ". " + t)
                    | f -> Failure(Normal "At " + Numeric i + " Size " + Numeric e.Length + ". " + f.ToString())
                check 0
        | (:? matrix as e), (:? matrix as a) ->
            if e.Rows <> a.Rows || e.Cols <> a.Cols then Failure(Normal "Matrix size differs. expected: ("
                                                         + Numeric e.Rows + "," + Numeric e.Cols + ") actual: ("
                                                         + Numeric a.Rows + "," + Numeric a.Cols + ")")
            else
                let rec check r c =
                    match close e.[r,c] a.[r,c] with
                    | Success ->
                        let nr, nc = if r+1<e.Rows then r+1,c else 0,c+1
                        if nr=0 && nc=e.Cols then Success
                        else check nr nc
                    | Failure t -> Failure(Normal "At (" + Numeric r + "," + Numeric c + ") Size (" + Numeric e.Rows + "," + Numeric e.Cols + "). " + t)
                    | f -> Failure(Normal "At (" + Numeric r + "," + Numeric c + ") Size (" + Numeric e.Rows + "," + Numeric e.Cols + "). " + f.ToString())
                check 0 0
        | _ -> failwithf "Unknown type %s" (actual.GetType().Name)
    close expected actual

let faster (faster:unit->'a) (slower:unit->'a) =
    let t1 = Stopwatch.GetTimestamp()
    let rf,tf,rs,ts =
        if t1 &&& 1L = 1L then
            let rf = faster()
            let t1 = Stopwatch.GetTimestamp() - t1
            let t2 = Stopwatch.GetTimestamp()
            let rs = slower()
            let t2 = Stopwatch.GetTimestamp() - t2
            rf,t1,rs,t2
        else
            let rs = slower()
            let t1 = Stopwatch.GetTimestamp() - t1
            let t2 = Stopwatch.GetTimestamp()
            let rf = faster()
            let t2 = Stopwatch.GetTimestamp() - t2
            rf,t2,rs,t1
    match equal rf rs with
    | Success -> Faster("",tf,ts)
    | fail -> fail

/// Chi-squared test to 6 standard deviations.
let chiSquared (expected:int[]) (actual:int[]) =
    if actual.Length <> expected.Length then
        Failure(Normal "actual and expected need to be the same length.")
    elif Array.exists (fun i -> i<=5) expected then
        Failure(Normal "expected frequency for all buckets needs to be above 5.")
    else
        let chi = Array.fold2 (fun s a e ->
            let d = double(a-e)
            s+d*d/double e) 0.0 actual expected
        let mean = double(expected.Length - 1)
        let sdev = sqrt(2.0 * mean)
        let SDs = (chi - mean) / sdev
        if abs SDs > 6.0 then
            Failure(Normal "chi-squared standard deviation = " + Numeric(SDs.ToString("0.0")))
        else Success
