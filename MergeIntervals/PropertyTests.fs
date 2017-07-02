module PropertyTests
open FsCheck 
open FsCheck.Xunit

let rnd = System.Random()

[<Property(Verbose = true)>]
let ``ImmutableStack and mutableStack agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x = y then (x,y+1) else (x,y))
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
                       |> List.distinct
    ImmutableStack.fmo testList = MutableStack.fmo testList 

[<Property(Verbose = true)>]
let ``Original and MutableStack agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x = y then (x,y+1) else (x,y))
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
                       |> List.distinct
    Original.fmo testList = MutableStack.fmo testList 


[<Property(Verbose = true)>]
let ``Readable and ImmutableStack agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x = y then (x,y+1) else (x,y))
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
                       |> List.distinct
    Readable.fmo testList = ImmutableStack.fmo testList 

[<Property(Verbose = true)>]
let ``Readable and mutableStack agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x = y then (x,y+1) else (x,y))
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
                       |> List.distinct
    Readable.fmo testList = MutableStack.fmo testList 


