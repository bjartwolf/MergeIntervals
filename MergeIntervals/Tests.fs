module Tests
open FsCheck 
open FsCheck.Xunit

let rnd = System.Random()

[<Property>]
let ``Einar and Bjorn Einar agree`` (baseList: int list) = 
    let testList = baseList |> List.map (fun x -> (x, x+rnd.Next())) 
    Einar.fmo testList = BjornEinar.fmo testList 