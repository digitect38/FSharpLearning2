//
// 2017/02/14 Initial
//

module 메인모듈 // program 내에 2개이상의 module 이 존재할 경우 반드시 module 명시, 당연히 한글식 이름 가능
open System
open fibbo

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let external_foo x =
    printfn "print from ext_foo... %d" x

let toHackerTalk (phrase:string) =
    phrase.Replace('t', '7').Replace('o', '0')

let mapf test x =
    let y = test x
    printfn "%d" y

///
// EntryPoint 함수는 항상 맨 마지막에
///

[<EntryPoint>]
let 내가메인이당깨 argv =     // EntryPoint 명시만 있으면 main 함수명은 무엇이든 무관, 당연히 한글식 이름 가능

    //1. let 은 기본적으로 immutable 이므로 변수의 값을 변경코자 한다면 mutable
    let mutable x = 1
    x <- 2
    
    //2. console 출력은 printfn 을 기본적으로 사용하마, C#의 Console.WriteLine 도 사용가능
    printfn "%d" x    
    Console.WriteLine x    

    //3. func 내에서 func 선언이 가능
    let internal_foo x =
        printfn "print from internal_foo... %d" x
    
    internal_foo 5
    external_foo 5

    // normal function call using for loop
    printfn "Using for loop lets print Fibonacci numbers... "
    for i=0 to 10 do
        printfn "fnum1(%d) =%d" i (fibbo i)

    // alternative fancy ways using List.map
    printfn "Alternatively, How to use awesome List.map function instead of for loop ... "

    let data:List<int> = [0..10]        
    let fnum = data |> List.map fibbo                               // The how of mapping     
    let dummy = List.map (fun j -> printfn "fnum3 = %d" j) fnum     // List.map 2
    let dummy = fnum |> List.map (fun j -> printfn "fnum2 = %d" j)  // List.map 1 forward pipe operator
    let dummy = List.map (fun j -> printfn "fnum4 = %d" j) <| fnum  // List.map 3 using backward pipe operator

    // How to use reference type...

    printfn "How to use reference type and dereference it ..."

    // Declare a reference.
    let refVar = ref 6

    // Change the value referred to by the reference.
    refVar := 50

    // Dereference by using the ! operator.
    printfn "deref1: %d" !refVar
    printfn "deref2: %d" refVar.contents    // same as ! operator
    printfn "deref3: %d" refVar.Value       // same as ! operator     

    // lists

    let twotofive = [2;3;4;5]
    let onetofive = 1::twotofive
    let zerotofive = [0;1]@twotofive        // concaternates

    // functions

    let evens list =
        let isEven x = 
            x % 2 = 0
        List.filter isEven list

    let ev = evens zerotofive
    let dummy = ev |> List.map (fun x -> printfn "x = %d" x)
    let dummy = List.map (fun x -> printfn "x = %d" x) <| ev
    let sum = List.sum (ev)
    printfn "List.sum = %d" (List.sum ev)

    let square x = x*x
    let OneToHundSquaredSum1 =  [1..100] |> List.map square |> List.sum
    let OneToHundSquaredSum2 =  [1..100] |> List.map (fun x -> x*x) |> List.sum

    // Pattern matching

    let simplePatternMatch x =
        match x with
        | 1 -> printfn "One"
        | 2 -> printfn "Two"
        | _ ->  printfn "Else"
    
    // Null is not alowed Option type is needed
    let validVal = Some(99)
    let inValidVal = None

    let OptionPatternMatch x =
        match x with
        | Some y -> printfn "Some, Input is an int = %d" y
        | None -> printfn "None, Input is missing"
        
    OptionPatternMatch validVal
    OptionPatternMatch (Some 1)
    OptionPatternMatch (Some <| 1)
    OptionPatternMatch (None)

    // Printing

    printfn "An int = %i, A float = %f, A bool = %b" 1 1.2 true
    printfn "A string %s, and something generic %A" "hello" [1; 2; 3; 4]

    let add x y = x + y
    let add1 = add 1
    let add2 = add 2
    let add4 = add 4
    let add7 = add1 >> add2 >> add4 // composition of functions
    let c = add7 1
    printfn "1 + 7 = %i" c

    // higher order functions
    [1..10] |> List.map add7 |> printfn "new list is %A"

    // lists of functions, and more (another way)
    let add7 = [add1; add2; add4] |> List.reduce (>>)
    let d = add7 1
    printfn "1 + 2 + 4 + 1 = %i" d

    let add7 = [add1; add2; add4] |> List.reduce (<<)
    
    let d = add7 1
    printfn "4 + 2 + 1 + 1 = %i" d
    
    // List and collection

    let squares = [for i in 1..10 do yield i * i]// AKA generator
    // sampe as... let squares = [1..10] |> List.map (fun x -> x*x)


    let listSplit = function
        |(p::xs) -> xs  // all but exclude first
        | [] -> []

    let ls = listSplit [1..10]
    ls |> printfn "%A"    
    let ls = listSplit ls
    ls |> printfn "%A"    
    let ls = listSplit ls
    ls |> printfn "%A"    
    let ls = listSplit ls
    ls |> printfn "%A"    
    let ls = listSplit ls

    // A prime number ganerator
    let rec sieve = function    // rec allow recursion
        | (p::xs) -> p::sieve [ for x in xs do if x % p > 0 then yield x ]
        | []      -> []
    
    let primes = sieve []
    printfn "seieve [] = %A" primes

    let primes = sieve [1]
    printfn "seieve [1] = %A" primes

    let primes = sieve [2;3;4;5;6]
    printfn "seieve [2;3;4;5;6] = %A" primes

    let primes = sieve [2..50]
    printfn "sieve [2..50] = %A" primes

    let primes = sieve [2..5000]
    printfn "sieve [2..5000] = %A" primes

    0 // return an integer exit code
