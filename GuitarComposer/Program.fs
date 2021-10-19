// Learn more about F# at http://fsharp.org

open System


let rec printSectionOutput (sectionText:string list) curColumn curRow = 
    match sectionText with
    | [] -> curRow
    | head::tail -> 
        Console.SetCursorPosition(curColumn, curRow)
        Console.Write(head)
        printSectionOutput tail curColumn curRow+1
    

let rec printRiffOutput output curColumn curRow = 
    match output with 
    | [] -> ()
    | head::tail ->
        let lastRow = printSectionOutput head curColumn curRow
        printRiffOutput tail (curColumn+1) (lastRow+2)
        ()



[<EntryPoint>]
let main argv =

    let riff = LogicLayer.Composer.composeRiff 0u []
    
    printfn "%A" riff

    
    let output = 
        LogicLayer.Composer.composeRiff 0u []
        |> TextFormatter.getTextOutput

    output
    |> printfn "%A" 


    0 // return an integer exit code
