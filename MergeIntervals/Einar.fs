module Einar 

let rec merge = function
  | [] -> []
  | [last] -> [last]
  | (s, e) :: (s', e') :: rest -> 
    if e < s' then
      (s, e) :: merge ((s', e') :: rest)
    else
      merge ((s, max e e') :: rest)
      
let fmo = List.sortBy (fun (s, e) -> s) >> merge >> List.sumBy (fun (s, e) -> e - s)