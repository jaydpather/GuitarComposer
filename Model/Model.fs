namespace Model

module Model =
    type Tab = int 
    type PowerChord = bool
    type PM = bool
    type Sound = Tab * PowerChord * PM
    
    type Rhythm = 
        | Eights = 0
        | Gallop = 1
        | RGallop = 2

    type Section = Sound * Rhythm

    type Riff = Section list