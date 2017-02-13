//
// this is the Cool Fibonacci Function Implementation
////
module fibbo

let fibbo (n) =     //let fibbo (n:int) =
    let arr = [|0;1|]     //same as.. let arr:int[] = [|0;1|]
    if n > 0 then
        for j = 1 to n/2 do
            arr.[0] <- arr.[0] + arr.[1]
            arr.[1] <- arr.[1] + arr.[0]
        arr.[(n)%2]
    else
        arr.[0]
