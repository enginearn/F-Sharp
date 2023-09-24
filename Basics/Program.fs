module BasicFunctions =

    /// You use 'let' to define a function. This one accepts an integer argument and returns an integer.
    /// Parentheses are optional for function arguments, except for when you use an explicit type annotation.
    let sampleFunction1 x = x * x + 3

    /// Apply the function, naming the function return result using 'let'.
    /// The variable type is inferred from the function return type.
    let result1 = sampleFunction1 4573

    // This line uses '%d' to print the result as an integer. This is type-safe.
    // If 'result1' were not of type 'int', then the line would fail to compile.
    printfn $"The result of squaring the integer 4573 and adding 3 is %d{result1}"

    /// When needed, annotate the type of a parameter name using '(argument:type)'.  Parentheses are required.
    let sampleFunction2 (x: int) = 2 * x * x - x / 5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn $"The result of applying the 2nd sample function to (7 + 4) is %d{result2}"

    /// Conditionals use if/then/elif/else.
    ///
    /// Note that F# uses white space indentation-aware syntax, similar to languages like Python.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0 * x * x - x / 5.0 + 3.0
        else
            2.0 * x * x + x / 5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // This line uses '%f' to print the result as a float.  As with '%d' above, this is type-safe.
    printfn $"The result of applying the 3rd sample function to (6.5 + 4.5) is %f{result3}"

module Immutability =

    /// Binding a value to a name via 'let' makes it immutable.
    ///
    /// The second line of code compiles, but 'number' from that point onward will shadow the previous definition.
    /// There is no way to access the previous definition of 'number' due to shadowing.
    let number = 2
    // let number = 3

    /// A mutable binding.  This is required to be able to mutate the value of 'otherNumber'.
    let mutable otherNumber = 2

    printfn $"'otherNumber' is {otherNumber}"

    // When mutating a value, use '<-' to assign a new value.
    //
    // Note that '=' is not the same as this.  Outside binding values via 'let', '=' is used to test equality.
    otherNumber <- otherNumber + 1

    printfn $"'otherNumber' changed to be {otherNumber}"

module IntegersAndNumbers =

    /// This is a sample integer.
    let sampleInteger = 176

    /// This is a sample floating point number.
    let sampleDouble = 4.1

    /// This computed a new number by some arithmetic.  Numeric types are converted using
    /// functions 'int', 'double' and so on.
    let sampleInteger2 = (sampleInteger / 4 + 5 - 7) * 4 + int sampleDouble

    /// This is a list of the numbers from 0 to 99.
    let sampleNumbers = [ 0..99 ]

    /// This is a list of all tuples containing all the numbers from 0 to 99 and their squares.
    let sampleTableOfSquares = [ for i in 0..99 -> (i, i * i) ]

    // The next line prints a list that includes tuples, using an interpolated string.
    printfn $"The table of squares from 0 to 99 is:\n{sampleTableOfSquares}"

module Booleans =

    /// Booleans values are 'true' and 'false'.
    let boolean1 = true
    let boolean2 = false

    /// Operators on booleans are 'not', '&&' and '||'.
    let boolean3 = not boolean1 && (boolean2 || false)

    // This line uses '%b'to print a boolean value.  This is type-safe.
    printfn $"The expression 'not boolean1 && (boolean2 || false)' is %b{boolean3}"

module StringManipulation =

    /// Strings use double quotes.
    let string1 = "Hello"
    let string2 = "world"
    printfn $"""The strings '{string1}' and '{string2}' concatenated are '{string1 + " " + string2}'"""

    /// Strings can also use @ to create a verbatim string literal.
    /// This will ignore escape characters such as '\', '\n', '\t', etc.
    let string3 = @"C:\Program Files\"
    printfn $"The string '{string3}' is a verbatim string literal"

    /// String literals can also use triple-quotes.
    let string4 = """The computer said "hello world" when I told it to!"""
    printfn $"The string '{string4}' is a string literal using triple-quotes"

    /// String concatenation is normally done with the '+' operator.
    let helloWorld = string1 + " " + string2

    // This line uses '%s' to print a string value.  This is type-safe.
    printfn "%s" helloWorld

    // Japanese characters can be used in strings.
    let japanese = "こんにちは世界"

    // This line uses '%s' to print a string value.  This is type-safe.
    printfn "%s" japanese

    /// Substrings use the indexer notation.  This line extracts the first 7 characters as a substring.
    /// Note that like many languages, Strings are zero-indexed in F#.
    let substring1 = helloWorld[0..6]
    let substring2 = helloWorld[0..]
    printfn $"{substring1}"
    printfn $"{substring2}"

module Tuples =

    /// A simple tuple of integers.
    let tuple1 = (1, 2, 3)

    /// A function that swaps the order of two values in a tuple.
    ///
    /// F# Type Inference will automatically generalize the function to have a generic type,
    /// meaning that it will work with any type.
    let swapElems (a, b) = (b, a)

    printfn $"The result of swapping (1, 2) is {(swapElems (1, 2))}"

    /// A tuple consisting of an integer, a string,
    /// and a double-precision floating point number.
    let tuple2 = (1, "fred", 3.1415)

    printfn $"tuple1: {tuple1}\ttuple2: {tuple2}"

    /// Tuples are normally objects, but they can also be represented as structs.
    ///
    /// These interoperate completely with structs in C# and Visual Basic.NET; however,
    /// struct tuples are not implicitly convertible with object tuples (often called reference tuples).
    ///
    /// The second line below will fail to compile because of this.  Uncomment it to see what happens.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Although you can
    let convertFromStructTuple (struct (a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct (a, b)

    printfn
        $"Struct Tuple: {sampleStructTuple}\nReference tuple made from the Struct Tuple: {(sampleStructTuple |> convertFromStructTuple)}"

module PipelinesAndComposition =

    /// Squares a value.
    let square x = x * x

    /// Adds 1 to a value.
    let addOne x = x + 1

    /// Tests if an integer value is odd via modulo.
    ///
    /// '<>' is a binary comparison operator that means "not equal to".
    let isOdd x = x % 2 <> 0

    /// A list of 5 numbers.  More on lists later.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Given a list of integers, it filters out the even numbers,
    /// squares the resulting odds, and adds 1 to the squared odds.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn $"processing {numbers} through 'squareOddValuesAndAddOne' produces: {squareOddValuesAndAddOne numbers}"

    /// A shorter way to write 'squareOddValuesAndAddOne' is to nest each
    /// sub-result into the function calls themselves.
    ///
    /// This makes the function much shorter, but it's difficult to see the
    /// order in which the data is processed.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn
        $"processing {numbers} through 'squareOddValuesAndAddOneNested' produces: {squareOddValuesAndAddOneNested numbers}"

    /// A preferred way to write 'squareOddValuesAndAddOne' is to use F# pipe operators.
    /// This allows you to avoid creating intermediate results, but is much more readable
    /// than nesting function calls like 'squareOddValuesAndAddOneNested'
    let squareOddValuesAndAddOnePipeline values =
        values |> List.filter isOdd |> List.map square |> List.map addOne

    printfn
        $"processing {numbers} through 'squareOddValuesAndAddOnePipeline' produces: {squareOddValuesAndAddOnePipeline numbers}"

    /// You can shorten 'squareOddValuesAndAddOnePipeline' by moving the second `List.map` call
    /// into the first, using a Lambda Function.
    ///
    /// Note that pipelines are also being used inside the lambda function.  F# pipe operators
    /// can be used for single values as well.  This makes them very powerful for processing data.
    let squareOddValuesAndAddOneShorterPipeline values =
        values |> List.filter isOdd |> List.map (fun x -> x |> square |> addOne)

    printfn
        $"processing {numbers} through 'squareOddValuesAndAddOneShorterPipeline' produces: {squareOddValuesAndAddOneShorterPipeline numbers}"

    /// Lastly, you can eliminate the need to explicitly take 'values' in as a parameter by using '>>'
    /// to compose the two core operations: filtering out even numbers, then squaring and adding one.
    /// Likewise, the 'fun x -> ...' bit of the lambda expression is also not needed, because 'x' is simply
    /// being defined in that scope so that it can be passed to a functional pipeline.  Thus, '>>' can be used
    /// there as well.
    ///
    /// The result of 'squareOddValuesAndAddOneComposition' is itself another function which takes a
    /// list of integers as its input.  If you execute 'squareOddValuesAndAddOneComposition' with a list
    /// of integers, you'll notice that it produces the same results as previous functions.
    ///
    /// This is using what is known as function composition.  This is possible because functions in F#
    /// use Partial Application and the input and output types of each data processing operation match
    /// the signatures of the functions we're using.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn
        $"processing {numbers} through 'squareOddValuesAndAddOneComposition' produces: {squareOddValuesAndAddOneComposition numbers}"

module Lists =

    /// Lists are defined using [ ... ].  This is an empty list.
    let list1 = []

    /// This is a list with 3 elements.  ';' is used to separate elements on the same line.
    let list2 = [ 1; 2; 3 ]

    /// You can also separate elements by placing them on their own lines.
    let list3 = [ 1; 2; 3 ]

    /// This is a list of integers from 1 to 1000
    let numberList = [ 1..1000 ]

    /// Lists can also be generated by computations. This is a list containing
    /// all the days of the year.
    ///
    /// 'yield' is used for on-demand evaluation. More on this later in Sequences.
    let daysList =
        [ for month in 1..12 do
              for day in 1 .. System.DateTime.DaysInMonth(2023, month) do
                  yield System.DateTime(2023, month, day) ]

    // Print the first 5 elements of 'daysList' using 'List.take'.
    printfn $"The first 5 days of 2023 are: {daysList |> List.take 5}"

    /// Computations can include conditionals.  This is a list containing the tuples
    /// which are the coordinates of the black squares on a chess board.
    let blackSquares =
        [ for i in 0..7 do
              for j in 0..7 do
                  if (i + j) % 2 = 1 then
                      yield (i, j) ]

    /// Lists can be transformed using 'List.map' and other functional programming combinators.
    /// This definition produces a new list by squaring the numbers in numberList, using the pipeline
    /// operator to pass an argument to List.map.
    let squares = numberList |> List.map (fun x -> x * x)

    /// There are many other list combinations. The following computes the sum of the squares of the
    /// numbers divisible by 3.
    let sumOfSquares =
        numberList |> List.filter (fun x -> x % 3 = 0) |> List.sumBy (fun x -> x * x)

    printfn $"The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d{sumOfSquares}"

module Arrays =

    /// This is The empty array.  Note that the syntax is similar to that of Lists, but uses `[| ... |]` instead.
    let array1 = [||]

    /// Arrays are specified using the same range of constructs as lists.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// This is an array of numbers from 1 to 1000.
    let array3 = [| 1..1000 |]

    /// This is an array containing only the words "hello" and "world".
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// This is an array initialized by index and containing the even numbers from 0 to 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Sub-arrays are extracted using slicing notation.
    let evenNumbersSlice = evenNumbers[0..500]

    /// You can loop over arrays and lists using 'for' loops.
    for word in array4 do
        printfn $"word: {word}"

    // You can modify the contents of an array element by using the left arrow assignment operator.
    //
    // To learn more about this operator, see: https://learn.microsoft.com/dotnet/fsharp/language-reference/values/index#mutable-variables
    array2[1] <- "WORLD!"

    /// You can transform arrays using 'Array.map' and other functional programming operations.
    /// The following calculates the sum of the lengths of the words that start with 'h'.
    ///
    /// Note that in this case, similar to Lists, array2 is not mutated by Array.filter.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn $"The sum of the lengths of the words in Array 2 is: %d{sumOfLengthsOfWords}"

module Sequences =

    /// This is the empty sequence.
    let seq1 = Seq.empty

    /// This a sequence of values.
    let seq2 =
        seq {
            yield "hello"
            yield "world"
            yield "and"
            yield "hello"
            yield "world"
            yield "again"
        }

    /// This is an on-demand sequence from 1 to 1000.
    let numbersSeq = seq { 1..1000 }

    /// This is a sequence producing the words "hello" and "world"
    let seq3 =
        seq {
            for word in seq2 do
                if word.Contains("l") then
                    yield word
        }

    /// This is a sequence producing the even numbers up to 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// This is an infinite sequence which is a random walk.
    /// This example uses yield! to return each element of a subsequence.
    let rec randomWalk x =
        seq {
            yield x
            yield! randomWalk (x + rnd.NextDouble() - 0.5)
        }

    /// This example shows the first 100 elements of the random walk.
    let first100ValuesOfRandomWalk = randomWalk 5.0 |> Seq.truncate 100 |> Seq.toList

    printfn $"First 100 elements of a random walk: {first100ValuesOfRandomWalk}"

module RecursiveFunctions =

    /// This example shows a recursive function that computes the factorial of an
    /// integer. It uses 'let rec' to define a recursive function.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n - 1)

    printfn $"Factorial of 6 is: %d{factorial 6}"

    /// Computes the greatest common factor of two integers.
    ///
    /// Since all of the recursive calls are tail calls,
    /// the compiler will turn the function into a loop,
    /// which improves performance and reduces memory consumption.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn $"The Greatest Common Factor of 300 and 620 is %d{greatestCommonFactor 300 620}"

    /// This example computes the sum of a list of integers using recursion.
    ///
    /// '::' is used to split a list into the head and tail of the list,
    /// the head being the first element and the tail being the rest of the list.
    let rec sumList xs =
        match xs with
        | [] -> 0
        | y :: ys -> y + sumList ys

    /// This makes 'sumList' tail recursive, using a helper function with a result accumulator.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | [] -> accumulator
        | y :: ys -> sumListTailRecHelper (accumulator + y) ys

    /// This invokes the tail recursive helper function, providing '0' as a seed accumulator.
    /// An approach like this is common in F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [ 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 ]

    printfn $"The sum 1-10 is %d{sumListTailRecursive oneThroughTen}"

[<EntryPoint>]
let main argv =
    // Call the functions defined above.
    BasicFunctions.result1 |> ignore
    BasicFunctions.result2 |> ignore
    BasicFunctions.result3 |> ignore

    // Call the functions defined above.
    Immutability.number |> ignore
    Immutability.otherNumber |> ignore

    // Call the functions defined above.
    IntegersAndNumbers.sampleInteger2 |> ignore
    IntegersAndNumbers.sampleNumbers |> ignore
    IntegersAndNumbers.sampleTableOfSquares |> ignore

    // Call the functions defined above.
    Booleans.boolean1 |> ignore
    Booleans.boolean2 |> ignore
    Booleans.boolean3 |> ignore

    // Call the functions defined above.
    StringManipulation.string1 |> ignore
    StringManipulation.string2 |> ignore
    StringManipulation.string3 |> ignore
    StringManipulation.string4 |> ignore
    StringManipulation.helloWorld |> ignore
    StringManipulation.japanese |> ignore
    StringManipulation.substring1 |> ignore
    StringManipulation.substring2 |> ignore

    // Call the functions defined above.
    Tuples.tuple1 |> ignore
    Tuples.tuple2 |> ignore
    Tuples.sampleStructTuple |> ignore
    Tuples.convertFromStructTuple Tuples.sampleStructTuple |> ignore
    Tuples.convertToStructTuple (1, 2) |> ignore

    // Call the functions defined above.
    PipelinesAndComposition.squareOddValuesAndAddOne [ 1; 2; 3; 4; 5 ] |> ignore

    PipelinesAndComposition.squareOddValuesAndAddOneNested [ 1; 2; 3; 4; 5 ]
    |> ignore

    PipelinesAndComposition.squareOddValuesAndAddOnePipeline [ 1; 2; 3; 4; 5 ]
    |> ignore

    PipelinesAndComposition.squareOddValuesAndAddOneShorterPipeline [ 1; 2; 3; 4; 5 ]
    |> ignore

    PipelinesAndComposition.squareOddValuesAndAddOneComposition [ 1; 2; 3; 4; 5 ]
    |> ignore

    // Call the functions defined above.
    Lists.list1 |> ignore
    Lists.list2 |> ignore
    Lists.list3 |> ignore
    Lists.numberList |> ignore
    Lists.daysList |> ignore
    Lists.blackSquares |> ignore
    Lists.squares |> ignore
    Lists.sumOfSquares |> ignore

    // Call the functions defined above.
    Arrays.array1 |> ignore
    Arrays.array2 |> ignore
    Arrays.array3 |> ignore
    Arrays.array4 |> ignore
    Arrays.evenNumbers |> ignore
    Arrays.evenNumbersSlice |> ignore
    Arrays.sumOfLengthsOfWords |> ignore

    // Call the functions defined above.
    Sequences.seq1 |> ignore
    Sequences.seq2 |> ignore
    Sequences.numbersSeq |> ignore
    Sequences.seq3 |> ignore
    Sequences.evenNumbers |> ignore
    Sequences.first100ValuesOfRandomWalk |> ignore

    // Call the functions defined above.
    RecursiveFunctions.factorial 6 |> ignore
    RecursiveFunctions.greatestCommonFactor 300 620 |> ignore
    RecursiveFunctions.sumList [ 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 ] |> ignore
    RecursiveFunctions.sumListTailRecursive [ 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 ] |> ignore

    0 // return an integer exit code
