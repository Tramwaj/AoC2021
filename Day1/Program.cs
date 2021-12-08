// See https://aka.ms/new-console-template for more information
int prev = int.MaxValue;
int increases = 0;
foreach (var item in System.IO.File.ReadLines(@"Data1"))
{
    int current = Int32.Parse(item.Trim());
    if (current > prev) increases++;
    prev = current;
}
Console.WriteLine("Part 1:");
Console.WriteLine(increases);
Console.WriteLine();

prev = int.MaxValue;
increases = 0;
List<int> currentList = new List<int>();
foreach (var item in System.IO.File.ReadLines(@"Data1"))
{
    currentList.Add(Int32.Parse(item.Trim()));
    if (currentList.Count == 3)
        prev = currentList.Sum();
    if (currentList.Count > 3)
    {
        currentList.RemoveAt(0);
        if (currentList.Sum() > prev) increases++;
        prev = currentList.Sum();
    }
}
Console.WriteLine("Part 2:");
Console.WriteLine(increases);
