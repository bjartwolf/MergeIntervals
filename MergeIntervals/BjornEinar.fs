module BjornEinar
open System.Collections.Generic
open System.Linq

type OpenInterval = {Start: int; End: int }
let fmo (input : (int*int) list) = 
    if input.IsEmpty then
        0
    else 
        let intervals = input |> List.map (fun (x,y) -> { Start = x; End = y}) 

        let sorted = intervals |> Seq.sortBy (fun f -> f.Start) 

        //2. Push the first interval on to a stack.
        let stack = new Stack<OpenInterval>()
        stack.Push (Seq.head sorted)

        let restOfList = Seq.tail sorted

        //3. For each interval do the following
        for interval in restOfList do
        //   a. If the current interval does not overlap with the stack top, push it.
            let overLap i i' = i.End + 1 >= i'.Start
            if not (overLap (stack.Peek()) interval) then
                stack.Push interval       
        //   b. If the current interval overlaps with stack top and ending
        //       time of current interval is more than that of stack top, 
        //       update stack top with the ending  time of current interval.
            else if overLap (stack.Peek()) interval && interval.End > (stack.Peek()).End then        
                stack.Push({ (stack.Pop()) with End = interval.End })

        //4. At the end stack contains the merged intervals. 

        let lengthOfInterval i = i.End - i.Start

        stack.Sum(System.Func<OpenInterval,int>(fun i -> lengthOfInterval i)) 