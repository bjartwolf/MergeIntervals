﻿module Tests
open FsCheck 
open FsCheck.Xunit

let rnd = System.Random()

[<Property(Verbose = true)>]
let ``Einar and Bjorn Einar agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
    Einar.fmo testList = BjornEinar.fmo testList 