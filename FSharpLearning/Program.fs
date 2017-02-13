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
  

// EntryPoint 함수는 항상 맨 마지막에
//

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
        
    let fnum = data |> List.map fibbo
    
    let dummy = List.map (fun j -> printfn "fnum3 = %d" j) fnum     // List.map 2
    let dummy = fnum |> List.map (fun j -> printfn "fnum2 = %d" j)  // List.map 1 forward pipe operator
    let dummy = List.map (fun j -> printfn "fnum4 = %d" j) <| fnum  // List.map 3 using backward pipe operator

    //List.map (printfn "fnum2 = %d") fnum

    //fnum |> List.map printfn "%d" fnum

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

    0 // return an integer exit code
