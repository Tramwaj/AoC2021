using System.Text.RegularExpressions;

var data = File.ReadAllText("data5.txt");
string pattern = @"(\w+),(\w+) -> (\w+),(\w+)";

var matches = Regex.Matches(data, pattern).ToList();


List<Line> lines = new List<Line>();

foreach (var match in matches)
{
    lines.Add(new Line(
        int.Parse(match.Groups[1].Value),
        int.Parse(match.Groups[2].Value),
        int.Parse(match.Groups[3].Value),
        int.Parse(match.Groups[4].Value)
        ));
}
int max = new int[] { lines.Max(x => x.x0), lines.Max(x => x.x1), lines.Max(x => x.y0), lines.Max(x => x.y1) }.Max() + 1;
int[,] result = new int[max, max];

foreach (var line in lines)
{
    int lower, upper;
    if (line.x0 == line.x1)
    {
        if (line.y1 < line.y0)
        {
            lower = line.y1;
            upper = line.y0;
        }
        else
        {
            lower = line.y0;
            upper = line.y1;
        }
        for (int i = lower; i <= upper; i++)
        {
            result[line.x0, i]++;
        }
    }
    else if (line.y0 == line.y1)
    {
        if (line.x1 < line.x0)
        {
            lower = line.x1;
            upper = line.x0;
        }
        else
        {
            lower = line.x0;
            upper = line.x1;
        }
        for (int i = lower; i <= upper; i++)
        {
            result[i, line.y0]++;
        }
    }
    else
    {
        bool xRising = line.x1 > line.x0;
        bool yRising = line.y1 > line.y0;
        int steps = Math.Abs(line.x0 - line.x1);
        for (int i = 0; i <= steps; i++)
        {
            int x = xRising ? line.x0 + i : line.x0 - i;
            int y = yRising ? line.y0 + i : line.y0 - i;
            result[x, y]++;
        }
    }
}

int count = 0;
for (int i = 0; i < max; i++)
{
    for (int j = 0; j < max; j++)
    {
        if (result[i, j] >= 2) count++;
    }

}



Console.WriteLine(count);
record Line(int x0, int y0, int x1, int y1);