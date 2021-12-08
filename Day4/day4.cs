
var data = File.ReadAllLines("Data4.txt");

int[] numbers = data.First().Split(',').Select(x => int.Parse(x)).ToArray();

List<string> matricesStr = data.Where(x => !string.IsNullOrWhiteSpace(x))
    .Where(x => !x.Contains(','))
    .ToList();

int iter = 0;
List<int[,]> matrices = new List<int[,]>();

for (int i = 0; i < matricesStr.Count; i += 5)
{
    var b = new int[5, 5];
    for (int j = 0; j < 5; j++)
    {
        for (int k = 0; k < 5; k++)
        {
            b[j, k] = matricesStr[i + j].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()[k];
        }
    }
    //var b = matricesStr.GetRange(i,5).Select(x=>x.Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray()).ToArray();
    matrices.Add(b);
}

List<int> drawnNumbers = new List<int>();

List<bool> Eliminated = Enumerable.Range(0, 100).Select(x => false).ToList();

foreach (var number in numbers)
{
    drawnNumbers.Add(number);
    int matrixNo = 0;
    foreach (var matrix in matrices)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (!drawnNumbers.Contains(matrix[i, j]))
                    j = 6;
                else
                {
                    if (j == 4)
                    {
                        Eliminated[matrixNo] = true;
                        if (Eliminated.Count(x => x == false) ==0)
                        {
                            Console.WriteLine(SumUnmarked(matrix, drawnNumbers));
                            Console.WriteLine($"Number: {number}");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (!drawnNumbers.Contains(matrix[j, i]))
                    j = 6;
                else
                {
                    if (j == 4)
                    {
                        Eliminated[matrixNo] = true;
                        if (Eliminated.Count(x => x == false) ==0)
                        {
                            Console.WriteLine(SumUnmarked(matrix, drawnNumbers));
                            Console.WriteLine($"Number: {number}");
                            Console.WriteLine();
                            Console.WriteLine(SumUnmarked(matrices[13],drawnNumbers));
                        }
                    }
                }

            }
        }
        matrixNo++;
    }

}
int SumUnmarked(int[,] matrix, List<int> numbers)
{
    int sum = 0;
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (!numbers.Contains(matrix[i, j]))
                sum += matrix[i, j];
        }
    }
    return sum;
}


Console.WriteLine();
