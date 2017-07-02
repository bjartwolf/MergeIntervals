module Readable
let fmo input = 
    let total  = input 
                |> List.map(fun (a, b) -> [a..b])
                |> List.concat
                |> List.distinct
    let total2 = List.zip total.Tail (total |> List.rev |> List.tail |> List.rev)
    total2 |> List.map(fun (a, b) -> if a - b = 1 then 1 else 0) |> List.sum
