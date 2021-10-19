module TextFormatter

open System
open System.Text
open Model.Model

//each column of text will be one 1/16th note

[<Literal>]
let BLANK = "_"

let getPowerChordSymbol sound = 
    let (tab, isPowerChord, isPM) = sound
    if isPowerChord then
        (tab + 2).ToString()
    else
        BLANK

let getRestText() =
    [ 
        BLANK; 
        BLANK;
        BLANK;
        BLANK;
        BLANK;
        BLANK;
        BLANK;
    ]

let getSoundText sound =
    let (tab, isPowerChord, isPM) = sound
    [ 
        if isPM then "P" else ""; 
        tab.ToString();
        getPowerChordSymbol sound;
        getPowerChordSymbol sound;
        BLANK;
        BLANK;
        BLANK;
    ]

let rec getSectionTextHelper sound (strList:string list list) baseText  = 
    if strList.Length >= 8 then
        strList
    else
        getSectionTextHelper sound (List.append strList baseText) baseText

let getSectionText section = 
    let (sound, rhythm) = section
    match rhythm with 
    | Eigths -> getSectionTextHelper sound [] (List.append [getSoundText sound] [getRestText()])
    | Gallop -> 
        let soundText = getSoundText sound
        //[]
        let baseText = [soundText] @ [getRestText()] @ [soundText] @ [soundText]
        getSectionTextHelper sound [] baseText
    | RGallop -> 
        let soundText = getSoundText sound
        let baseText = [soundText] @ [soundText] @ [getRestText()] @ [soundText]
        getSectionTextHelper sound [] baseText

let getTextOutput riff =
    List.map getSectionText riff


