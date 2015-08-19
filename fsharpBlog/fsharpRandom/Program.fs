﻿open System

let suffle (inputList: int List) = 
        let rnd = System.Random DateTime.Now.Millisecond
        snd (List.fold (fun acc item -> 
                        let randomCardIndex = rnd.Next (fst acc, inputList.Length)
                        (fst acc) + 1 ,
                        List.mapi (fun tmpIndex tmpItem -> 
                            match tmpIndex with 
                                | t when t = randomCardIndex -> (snd acc).[fst acc]
                                | t when t = (fst acc) -> (snd acc).[randomCardIndex]
                                | _ -> tmpItem ) (snd acc) 
                     ) 
                     (0, inputList) 
                     inputList)

let add resultSpace a b =
    let r = new Random(DateTime.Now.Millisecond)
    let loopList = [1..resultSpace]
    List.reduce (fun acc elem ->
                     let ra = r.Next(resultSpace)
                     let rb = r.Next(resultSpace)
                     match (ra, rb) with 
                        | x when fst x < a || snd x < b -> acc + 1
                        | _ -> acc                
                ) loopList

let multiply varMaxVal resultSpace a b =
    let r = new Random(DateTime.Now.Millisecond)
    let loopList = [1..resultSpace]
    List.reduce (fun acc elem ->
                     let ra = r.Next(varMaxVal)
                     let rb = r.Next(varMaxVal)
                     match (ra, rb) with 
                        | x when fst x < a && snd x < b -> acc + 1
                        | _ -> acc                
                ) loopList

[<EntryPoint>]
let main argv = 

    let toShuffle = [1..24]

    printfn "input:  %A" (toShuffle)
    printfn "result: %A" (suffle toShuffle)
    printfn "input:  %A" (toShuffle)
    printfn "result: %A" (suffle toShuffle)

//    let loopList = [1..1000]
//    let result = List.reduce (fun acc elem -> acc + (add 200 36 22)) loopList
//    printfn "add result: %A" (result/1000)
//
//    let loopList = [1..1000]
//    let result = List.reduce (fun acc elem -> acc + (multiply 100 10000 36 22)) loopList
//    printfn "multiply result: %A" (result/1000)

    0 // return an integer exit code
    