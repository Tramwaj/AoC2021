

int depth=0;
int dist=0;

foreach (var item in System.IO.File.ReadLines(@"Data2.txt"))
{
    var order = item.Split(' ');
    switch (order[0])
    {
        case "forward":
            dist+= int.Parse(order[1]);
            break;
        case "down":
            depth+= int.Parse(order[1]);
            break ;
        case "up":
            depth-= int.Parse(order[1]);
            break; ;
    }
    
}
Console.WriteLine("Part 1 (depth,dist,multiplication result)");
Console.WriteLine(depth);
Console.WriteLine(dist);
Console.WriteLine(depth*dist);

Console.WriteLine();

int aim = 0;
depth = dist = 0;

foreach (var item in System.IO.File.ReadLines(@"Data2.txt"))
{
    var order = item.Split(' ');
    switch (order[0])
    {
        case "forward":
            dist += int.Parse(order[1]);
            depth += int.Parse(order[1]) * aim;
            break;
        case "down":
            aim += int.Parse(order[1]);
            break;
        case "up":
            aim -= int.Parse(order[1]);
            break; ;
    }

}
Console.WriteLine("Part 2 (depth,dist,multiplication result)");
Console.WriteLine(depth);
Console.WriteLine(dist);
Console.WriteLine(depth * dist);