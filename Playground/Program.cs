// See https://aka.ms/new-console-template for more information

using Playground;

Console.WriteLine("Hello, World!");

var task1 = Task.Run(() =>
{
    TextTools.TextTools.FreqAnalysisFromFile(@"c:\Users\pes.PHA\source\repos\PeSul\NET2\Playground\BigFiles\words01.txt", Environment.NewLine);
        Console.WriteLine("Task 1 finished");
});

var task2 = Task.Run(() =>
{
TextTools.TextTools.FreqAnalysisFromFile(@"c:\Users\pes.PHA\source\repos\PeSul\NET2\Playground\BigFiles\words02.txt", Environment.NewLine);
         Console.WriteLine("Task 2 finished");
});

Task.WaitAny(task1, task2);

Console.WriteLine("Program finished.");
Console.ReadLine();

/*
var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var strings = new[] { "zero", "one", "two", "three",
                        "four", "five", "six", "seven",
                        "eight", "nine" };

// 1 strings - pomocí LINQu vytvořte nové pole kde jsou všechna slova uppercase
//var result = strings.Select(x => x.ToUpper());

// 2 numbers - zjiste pomoci LINQu jestli pole obsahuje pouze suda cisla
//bool isOnlyEvenNumbers = numbers.All(x => x % 2 == 0);
//global::System.Console.WriteLine($"jsou vsechna cisla suda: {isOnlyEvenNumbers}");

// 3 - vypište čísla v poli numbers jako slova - LINQ
// var result = numbers.Select(x => strings[x]);

// 4 - zjistěte kolik obsahují všechna
// slova v poli "strings" dohromady písmen - LINQ
// var sumletters = strings.Select(x => x.Length).Sum();
// Console.WriteLine($"vsechna slova v poli strings maji dohromady {sumletters} pismen");

// 5 - vytvořte novou kolekci obsahující dvojici
// lowercase i uppercase variantu
//var result = strings
//            .Select(slovo => new UpperLowerString(slovo))
//            .Select(x => $"upper:{x.UpperCase} lower:{x.LowerCase}");

// - 5 pomoci tuplu
// var result = strings.Select(slovo => (slovo.ToLower(), slovo.ToUpper()));

// 6 - LINQ - frekvence vyskytu jednotlivych pismen ve vsech
// polozkach pole strings (kombinovane - v celem poli)

// agregace - https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate?view=net-6.0
//var res = strings.Aggregate(
//   "", // start with empty string to handle empty list case.
//   (agg, item) => agg + item);
//Console.WriteLine(res);

//var aggregated = string.Join("", strings); //spojim slova do jednoho retece
//var result = aggregated // pracuji se stringem jako s kolekci znaku
//    .GroupBy(x => x) // seskupuji podle pismenek (char v koleci string)
//    .Select(g => (Letter: g.Key,Count: g.Count())) // udelam tuple obsahujici klic (pismenko) a pocet prvku
//    .OrderBy(x => x.Count)
//    .ThenByDescending(x => x.Letter)
//    ; 

// Dictionary - https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0

var bookdir = @"C:\Users\pes.PHA\source\repos\PeSul\NET2\Playground\Data";

foreach (var file in GetFilesFromDir(bookdir))
{
    var dict = TextTools.TextTools.FreqAnalysisFromFile(file);
    var top10 = TextTools.TextTools.GetTopWords(10, dict);

    var fi = new FileInfo(file);

    Console.WriteLine("KNIHA: " + fi.Name);
    PrintList(top10.Select(x => $"{x.Key} : {x.Value}").ToList());
    Console.WriteLine();
}




Console.WriteLine();


//PrintList(result.ToList());

//PrintItems<(char, int)>(result);

static void PrintList(List<string> listToPrint)
{
    foreach (var item in listToPrint)
    {
        Console.WriteLine(item);
    }
}

static void PrintItems<T>(IEnumerable<T> items)
{
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static Dictionary<char, int> CharFreq(string input)
{
    var tuples = input.GroupBy(x => x) // seskupuji podle pismenek (char v koleci string)
    .Select(g => (Letter: g.Key, Count: g.Count())) // udelam tuple obsahujici klic (pismenko) a pocet prvku
    .OrderBy(x => x.Count)
    .ThenByDescending(x => x.Letter);

    Dictionary<char, int> dict = new Dictionary<char, int>();

    foreach (var tuple in tuples)
    {
        dict.Add(tuple.Letter, tuple.Count);
    }

    return dict;
}

static IEnumerable<string> GetFilesFromDir(string dir)
{
    return Directory.EnumerateFiles(dir);


}
*/