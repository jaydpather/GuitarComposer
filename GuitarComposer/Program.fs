// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    //printfn "Hello World from F#!"
    LogicLayer.Composer.composeRiff 0u []
    |> printfn "%A" 
    0 // return an integer exit code
