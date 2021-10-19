namespace LogicLayer

open Model.Model
open System

module Composer =
    [<Literal>]
    let MIN_TAB = 0
    
    [<Literal>]
    let MAX_TAB = 5

    [<Literal>]
    let RIFF_LEN = 4u

    let _random = new Random()

    let getRandomBool() = 
        _random.Next(2) = 1

    let composeSection() = 
        let numRhythms = Enum.GetValues(typeof<Rhythm>).Length
        let randomRhythm = _random.Next(numRhythms) |> enum<Rhythm>
        let randomSound = Sound(_random.Next(MIN_TAB, MAX_TAB),  getRandomBool(), getRandomBool())
        Section(randomSound, randomRhythm)

    let rec composeRiff (curIndex:uint) curRiff = 
    
        match curIndex with 
        | RIFF_LEN -> curRiff
        | _ -> composeRiff (curIndex+1u) (composeSection() :: curRiff)

    let compose () =
        "output string"




