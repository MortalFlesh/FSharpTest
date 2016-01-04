namespace FSharpTest.Codingame
    module codingameVowels =
        let input = "Hello World" // 2 1

        let vowels = ['a'; 'e'; 'i'; 'o'; 'u']

        let countVowels (w:string) =
            w.ToLower().ToCharArray()
                |> List.ofArray
                |> List.filter (fun char -> vowels |> List.exists (fun vowel -> char = vowel ))
                |> List.length

        let answer = 
            input.Split [|' '|] 
                |> List.ofArray
                |> List.map (fun w -> countVowels w)
                |> List.map string
                |> List.reduce (fun acc elem -> acc + " " + elem)

        printfn "Vowels: %s in %A" answer input

        System.Console.WriteLine("=============================")

    module codingameNumbersCount =
        let inCount = 4
        let inNumbers = [1; 2; 3; 2;]

        printfn "Input: %d | %A" inCount inNumbers

        for i in [1 .. 9] do
            let iCount =
                inNumbers
                    |> List.filter (fun n -> n = i)
                    |> List.length
            let asterisks = 
                if iCount > 0 then
                    [for _ in [1 .. iCount] do yield "*"]
                        |> List.reduce (fun acc elem -> acc + elem)
                else ""

            printfn "%d:%s" i asterisks

        System.Console.WriteLine("=============================")

    module codingameMissingNumber =
        let inNumbers = "908721534"

        let numbers =
            inNumbers.ToCharArray()
                |> List.ofArray
                |> List.map (fun c -> c.ToString() |> System.Int32.Parse)

        let missingNumber =
            for i in [0 .. 9] do
                if not (numbers |> List.contains i) then
                    printfn "Missing %d in %s" i inNumbers

        System.Console.WriteLine("=============================")
