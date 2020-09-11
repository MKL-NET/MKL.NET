module Main

open System

let all =
    test null {
        MKLTests.all
        BlasTests.all
        LapackTests.all
        VslTests.all
    }

[<EntryPoint>]
let main args =
    match Config.parse args with
    | Ok config -> Tests.run config all
    | Error errors ->
        if List.isEmpty errors |> not then
            String.Join(" ",errors) |> sprintf "ERROR: %s\n" |> Alert
            |> TestText.toText |> Text.toANSI |> Console.WriteLine
        let commandName =
            Environment.GetCommandLineArgs().[0]
            |> IO.Path.GetFileName
            |> fun f -> if f.EndsWith(".dll") then "dotnet " + f else f
        Config.usage commandName |> Console.Write
        if List.isEmpty errors then 0 else 4