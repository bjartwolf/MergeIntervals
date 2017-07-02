module Original

let GetMaxOverlapping (entry: int * int) (entry2: int * int) =
    if (fst entry) <= (snd entry2)
        && (fst entry2) <= (snd entry) then
            List.min [fst entry; fst entry2], List.max [snd entry; snd entry2] 
    else    
            entry

let ResolveOverlappingRanges (ranges: (int * int) list) =
    ranges
    |> List.fold(fun acc x -> 
                    let entry = ranges
                                |> List.fold(fun acu y -> 
                                                let resolved = GetMaxOverlapping x y
                                                if (fst acu) = 0 && (snd acu) = 0 then
                                                    resolved
                                                else
                                                    List.min [fst acu; fst resolved], List.max [snd acu; snd resolved] ) (0,0)
                    List.append acc [entry] ) List.empty<int * int>    

let fmo input = 
    input
    |> ResolveOverlappingRanges
    |> List.distinctBy(fun x -> (fst x) + (snd x) )
    |> List.sumBy(fun x -> (snd x) - (fst x) ) 