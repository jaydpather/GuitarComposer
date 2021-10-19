// Learn more about F# at http://fsharp.org

open System

let rec printColumn (columnText:string list) curColumn curRow =
    match columnText with 
    | [] -> ()
    | head::tail ->
        Console.SetCursorPosition(curColumn, curRow)
        Console.Write(head)
        printColumn tail curColumn (curRow+1)

let rec printSectionOutput (sectionText:string list list) curColumn curRow = 
    match sectionText with
    | [] -> curRow
    | head::tail -> 
        printColumn head curColumn curRow    
        printSectionOutput tail curColumn curRow+8
    

let rec printRiffOutput output curColumn curRow = 
    match output with 
    | [] -> ()
    | head::tail ->
        let lastRow = printSectionOutput head curColumn curRow
        printRiffOutput tail (curColumn) (lastRow+2)
        ()



[<EntryPoint>]
let main argv =

    let riff = LogicLayer.Composer.composeRiff 0u []
    
    //printfn "%A" riff

    
    let output = 
        riff
        |> TextFormatter.getTextOutput

    //output
    //|> printfn "%A" 


    printRiffOutput output 0 0

    0 // return an integer exit code
