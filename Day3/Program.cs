// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var list = File.ReadAllLines("data3.txt").Select(x=>x.ToString()).ToList();
Console.WriteLine($"pierwszy testowy: {list.First()}");
int tempResult = 0;

for (int i = 0; i < list.First().Length; i++)
{
    tempResult = list.Select(x => x[i]).Count(x => x == '1') - list.Select(x => x[i]).Count(x => x == '0');
    if (tempResult >= 0) list = list.Where(x => x[i] == '1').ToList();
    else list = list.Where(x => x[i] == '0').ToList();
    if (list.Count() == 1) break;
}
Console.WriteLine(list.First());
int res1 = BinaryToDecimal(list.First());
Console.WriteLine($"res1: {res1}");

list = File.ReadAllLines("data3.txt").Select(x=>x.ToString()).ToList();
Console.WriteLine($"drugi testowy: {list.First()}");
tempResult = 0;

for (int i = 0; i < list.First().Length; i++)
{
    tempResult = list.Select(x => x[i]).Count(x => x == '1') - list.Select(x => x[i]).Count(x => x == '0');
    if (tempResult >= 0) list = list.Where(x => x[i] == '0').ToList();
    else list = list.Where(x => x[i] == '1').ToList();
    if (list.Count() == 1) break;
}
Console.WriteLine(list.First());
int res2 = BinaryToDecimal(list.First());
Console.WriteLine($"res2: {res2}");

Console.WriteLine($"Result: {res1*res2}");


static int BinaryToDecimal(string binary)
{
    var bin= binary.Reverse().ToList();
    Console.WriteLine(binary);
    int sum = 0;
    for (int i = 0; i < binary.Length; i++)
    {
        if (bin[i] == '1') sum += (int)Math.Pow(2, i);
    }
    return sum;
}
