module PropertyTests
open FsCheck 
open FsCheck.Xunit

type Interval = Interval of int*int with
  static member op_Explicit(Interval(x,y)) = (x,y)

type ArbitraryModifiers =
    static member Interval() = 
        Arb.from<int*int> 
        |> Arb.convert (fun (x,y) -> if (abs x < abs y) then Interval(abs x, abs y) else Interval(abs y, abs x)) 
                (fun (x:Interval) -> match x with | Interval(x,y) -> (x,y)) 
        
Arb.register<ArbitraryModifiers>()

[<Property(Verbose = true)>]
let ``ImmutableStack and mutableStack agree`` (baseList: Interval list) = 
    let testList = baseList |> List.map (fun x -> match x with | Interval(x,y) -> (x,y))
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


