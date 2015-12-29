namespace FSharpTest.Test
    module Basics =
        let value = "Hello world"

        printfn "%s" value

        let square n = n * n
        let x = 4
        let result = square x

        printfn "%d squared is %d" x result

        let xAndSquared = (x, square x)
        System.Console.WriteLine(xAndSquared)

        let mutable names = ["Mortalek"; "Adin"]
        let moreNames = "DinoCop" :: names
        //name <- "Horrigen" :: names

        System.Console.WriteLine(names)
        System.Console.WriteLine(moreNames)
        printfn "%A" moreNames

        let numbers = [ for i in 0 .. 10 -> (i, i * i, i * i * i) ]
        System.Console.WriteLine(numbers)

        let doubleX x = x * 2
        let add2 x = x + 2
        let subtract5 x = x - 5

        let a = 5 |> add2 |> doubleX |> subtract5
        printfn "Result: (5 + 2) * 2 - 5 = %d" a

        let testSum = 
            [ 1 .. 10 ]
                |> List.filter ( fun i -> i > 5 )
                |> List.sum
        printfn "Sum is %d" testSum

        let testFilterTuple =
            [ (1, 2); (1, 3); (1, 4) ]
                |> List.filter (fun x -> snd x > 2)
        printfn "List of 2 tuples: %A" testFilterTuple

        // days in year
        let year = 2015
        let daysOfYear = 
            [ for month in 1 .. 12 do
                for day in 1 .. System.DateTime.DaysInMonth(year, month) do
                    yield (day, month, year) ]

        

        System.Console.WriteLine(daysOfYear)

        System.Console.WriteLine(snd (1, 2))

    module Classes = 
        open System.Collections.Generic

        type Person(name:string, age:int) =
            let mutable _age = age

            new (name:string) = Person(name, 0)

            member this.Name = name
            member this.Age
                with get() = _age
                and set(value) = _age <- value

            member this.HasBirthday() = _age <- _age + 1
            member this.IsOlderThan age = _age >= age

            override this.ToString() = 
                "Name: " + name + ", Age: " + (string)_age

        // testing Person

        let mortalek = Person("Mortalek", 27)
        let adin = Person("Adin")
        adin.Age <- 22
        adin.HasBirthday()

        System.Console.WriteLine(mortalek)
        System.Console.WriteLine(adin)

        // creating Person from console

        System.Console.Write("Write name:")
        let name = System.Console.ReadLine()

        System.Console.Write("Write age:")
        let age = System.Console.ReadLine() |> System.Int32.Parse

        let newPerson = Person(name, age)
        System.Console.WriteLine(newPerson)

        // collections
        printfn "... collections ..."

        let vals = [1; 2; 3]
        let results = vals |> List.map (fun i -> i * i)
        System.Console.WriteLine(results)

        let persons = [mortalek; adin; newPerson]
        System.Console.WriteLine(persons)

        let personList = new List<Person>()
        personList.Add(mortalek)
        personList.Add(adin)
        personList.Add(newPerson)

        let names = persons |> List.map (fun p -> p.Name)
        System.Console.WriteLine(names)

        let maxAge = 100
        let ageLeftList = persons |> List.map (fun p -> (p.Name, maxAge - p.Age))
        System.Console.WriteLine(ageLeftList)
