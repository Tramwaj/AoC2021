// See https://aka.ms/new-console-template for more information
using D8;

Console.WriteLine("Hello, World!");

string path = "Data8.txt";

var data = File.ReadAllLines(path);

(int a,int b) = (new Day8()).Evaluate(data);