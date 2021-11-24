// See https://aka.ms/new-console-template for more information

using Playground;

Console.WriteLine("Hello, World!");

using HttpClient httpClient1 = new HttpClient();

var res1 = await httpClient1.GetStringAsync("https://www.gutenberg.org/cache/epub/2036/pg2036.txt");
var res2 = await httpClient1.GetStringAsync("https://www.gutenberg.org/files/16749/16749-0.txt");
var res3 = await httpClient1.GetStringAsync("https://www.gutenberg.org/cache/epub/19694/pg19694.txt");

var task1 = Task<Dictionary<string, int>>.Run(() =>
{
    Dictionary<string, int> dict = new();
    var dict01 = TextTools.TextTools.FreqAnalysisFromString(res1);
    var top10 = TextTools.TextTools.GetTopWords(10, dict01);

    foreach (var kv in top10)
    {
        //Console.WriteLine($"{kv.Key}: {kv.Key} {Environment.NewLine}");
        dict.Add(kv.Key, kv.Value);

    }
    Console.WriteLine("Task finished 1");

    return dict;
}
);
Task.WaitAll(task1);

Console.WriteLine("Soubor 1");
foreach (var item in task1.Result)
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}

Console.WriteLine("Program finished.");



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

static void LINQ()
{
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

    //var bookdir = @"C:\Users\pes.PHA\source\repos\PeSul\NET2\Playground\Books";

    //foreach(var file in GetFilesFromDir(bookdir))
    //{
    //    var dict = TextTools.TextTools.FreqAnalysis(file);
    //    var top10 = TextTools.TextTools.GetTopWords(10, dict);

    //    var fi = new FileInfo(file);

    //    Console.WriteLine("KNIHA: " + fi.Name);
    //    PrintList(top10.Select(x => $"{x.Key} : {x.Value}").ToList());
    //    Console.WriteLine();
    //}
}

static void SimpleTasks()
{
    //var task1 = Task.Run(() =>
    //{
    //    TextTools.TextTools.FreqAnalysisFromFile(@"C:\Users\pes.PHA\source\repos\PeSul\NET2\Playground\BigFiles\words01.txt", Environment.NewLine);
    //    Console.WriteLine("Task 1 finished.");
    //});


    //var task2 = Task.Run(() =>
    //{
    //    TextTools.TextTools.FreqAnalysisFromFile(@"C:\Users\pes.PHA\source\repos\PeSul\NET2\Playground\BigFiles\words09.txt", Environment.NewLine);
    //    Console.WriteLine("Task 2 finished.");
    //});


    //await Task.WhenAny(task1, task2);

}

static void Tasky3Knihy()
{

    //using HttpClient httpClient = new();

    //var res1 = await httpClient.GetAsync("https://www.gutenberg.org/cache/epub/2036/pg2036.txt");
    //var res2 = await httpClient.GetAsync("https://www.gutenberg.org/files/16749/16749-0.txt");
    //var res3 = await httpClient.GetAsync("https://www.gutenberg.org/cache/epub/19694/pg19694.txt");

    //if (res1.IsSuccessStatusCode && res2.IsSuccessStatusCode && res3.IsSuccessStatusCode)
    //{
    //    string content1 = await res1.Content.ReadAsStringAsync();

    //    var task1 = Task<Dictionary<string, int>>.Run(() =>
    //    {
    //        Dictionary<string, int> dictionary = new();
    //        var dict = TextTools.TextTools.FreqAnalysisFromString(content1);
    //        var top10 = TextTools.TextTools.GetTopWords(10, dict);

    //        foreach (var kv in top10)
    //        {
    //            //Console.WriteLine($"{kv.Key}: {kv.Key} {Environment.NewLine}");
    //            dictionary.Add(kv.Key, kv.Value);

    //        }
    //        Console.WriteLine("Task finished 1");

    //        return dictionary;
    //    }
    //    );

    //    string content2 = await res2.Content.ReadAsStringAsync();


    //    var task2 = Task<Dictionary<string, int>>.Run(() =>
    //    {
    //        Dictionary<string, int> dictionary = new();
    //        var dict = TextTools.TextTools.FreqAnalysisFromString(content2);
    //        var top10 = TextTools.TextTools.GetTopWords(10, dict);

    //        foreach (var kv in top10)
    //        {
    //            //Console.WriteLine($"{kv.Key}: {kv.Key} {Environment.NewLine}");
    //            dictionary.Add(kv.Key, kv.Value);
    //        }
    //        Console.WriteLine("Task finished 2");

    //        return dictionary;
    //    }
    //    );

    //    string content3 = await res3.Content.ReadAsStringAsync();

    //    var task3 = Task<Dictionary<string, int>>.Run(() =>
    //    {
    //        Dictionary<string, int> dictionary = new();
    //        var dict = TextTools.TextTools.FreqAnalysisFromString(content3);
    //        var top10 = TextTools.TextTools.GetTopWords(10, dict);

    //        foreach (var kv in top10)
    //        {
    //            //Console.WriteLine($"{kv.Key}: {kv.Key} {Environment.NewLine}");
    //            dictionary.Add(kv.Key, kv.Value);
    //        }
    //        Console.WriteLine("Task finished 3");

    //        return dictionary;
    //    }
    //    );

    //    Task.WaitAll(task1, task2, task3);

    //    Console.WriteLine("Analýza 1");
    //    foreach (var item in task1.Result)
    //    {
    //        Console.WriteLine($"{item.Key} - {item.Value}");
    //    }
    //    Console.WriteLine("-------------------------------");
    //    Console.WriteLine("Analýza 2");
    //    foreach (var item in task2.Result)
    //    {
    //        Console.WriteLine($"{item.Key} - {item.Value}");
    //    }
    //    Console.WriteLine("-------------------------------");
    //    Console.WriteLine("Analýza 3");
    //    foreach (var item in task3.Result)
    //    {
    //        Console.WriteLine($"{item.Key} - {item.Value}");
    //    }
    //    Console.WriteLine("-------------------------------");
}