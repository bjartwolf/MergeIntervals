module PropertyTests
open FsCheck 
open FsCheck.Xunit

[<Property(Verbose = true)>]
let ``ImmutableStack and mutableStack agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
    ImmutableStack.fmo testList = MutableStack.fmo testList 

[<Property(Verbose = true)>]
let ``Original and MutableStack agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
    Original.fmo testList = MutableStack.fmo testList 


[<Property(Verbose = true)>]
let ``Readable and ImmutableStack agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
    Readable.fmo testList = ImmutableStack.fmo testList 

[<Property(Verbose = true)>]
let ``Readable and mutableStack agree`` (baseList: (int*int) list) = 
    let testList = baseList
                       |> List.map (fun (x,y) -> (abs x, abs y)) 
                       |> List.map (fun (x,y) -> if x < y then (x,y) else (y,x))
    Readable.fmo testList = MutableStack.fmo testList 


