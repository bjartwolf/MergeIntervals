module Tests
open FsCheck 
open FsCheck.Xunit

let rnd = System.Random()

[<Property(Verbose = true)>]
let ``Original handles a simple case`` (x:int) =
    let  testdata = [(3,4);(6,7)]
    Original.fmo testdata = 4

[<Property(Verbose = true)>]
let ``Bjorn Einar handles a simple case`` (x:int) =
    let  testdata = [(3,4);(6,7)]
    BjornEinar.fmo testdata = 4

[<Property(Verbose = true)>]
let ``Einar handles a simple case`` (x:int) =
    let  testdata = [(3,4);(6,7)]
    Einar.fmo testdata = 4

[<Property(Verbose = true)>]
let ``Einar and Bjorn Einar agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x = y then (x,y+1) else (x,y))
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
                       |> List.distinct
    Einar.fmo testList = BjornEinar.fmo testList 

[<Property(Verbose = true)>]
let ``Original and Bjorn Einar agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x = y then (x,y+1) else (x,y))
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
                       |> List.distinct
    Original.fmo testList = BjornEinar.fmo testList 


[<Property(Verbose = true)>]
let ``Readable and Bjorn Einar agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x = y then (x,y+1) else (x,y))
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
                       |> List.distinct
    Readable.fmo testList = BjornEinar.fmo testList 

[<Property(Verbose = true)>]
let ``Readable and Einar agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x = y then (x,y+1) else (x,y))
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
                       |> List.distinct
    Readable.fmo testList = Einar.fmo testList 


