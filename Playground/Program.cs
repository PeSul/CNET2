// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

var numInString = strings.Select(x => x.ToUpper());

PrintList(numInString.ToList());

//2 numbers zjistěte pomocí LINQ zda pole obsahuje pouze suda cisla

//var result2 = numbers.Where(x => x % 2 != 0).Count();

bool isOnlyEvenNumbers = numbers.All(x => x % 2 == 0);

global::System.Console.WriteLine($"Jsou všechna čísla suda: { isOnlyEvenNumbers}");

//3 Vypište čísla v poli jako slova -LINQ


var result3 = numbers.Select(x => strings[x]);
PrintList(result3.ToList());

    static void PrintList(List<string> listToPrint)
{
    foreach (var item in listToPrint)
    {
        Console.WriteLine(item);
    }

}
