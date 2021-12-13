using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines("data10.txt");
            List<char> BadClosures = new();
            int sum = 0;
            foreach (var line in data)
            {
                char ch = CheckLinePart1(line) ;
                Console.WriteLine($"{ch}: {GetPointsPart1(ch)}");
                sum += GetPointsPart1(ch);
            }
            foreach (var line in data)
            {
                string lacking = CheckLinePart2(line);
            }
                Console.WriteLine("Part 1 score:");
            Console.WriteLine(sum);
            Console.ReadKey();

            List<long> LineScores = new();
            foreach (var line in data)
            {
                string str = CheckLinePart2(line);
                Console.WriteLine(str);
                if (!string.IsNullOrWhiteSpace(str))
                {
                    LineScores.Add(GetPointsPart2(str));
                    Console.WriteLine(LineScores.Last());
                }
            }
            LineScores = LineScores.OrderBy(x=>x).ToList();
            Console.WriteLine(LineScores[LineScores.Count()/2]);
        }
        public static char CheckLinePart1(string line)
        {
            Stack stack = new();
            foreach (char ch in line)
            {
                if (new char[] { '(', '[', '{', '<' }.Contains(ch))
                {
                    stack.Push(ch);
                }
                else
                {
                    char pop = (char)stack.Pop();
                    if (GetOpener(ch) != pop)
                        return ch;
                }
            }
            return '-';
        }
        public static string CheckLinePart2(string line)
        {
            Stack stack = new();
            foreach (char ch in line)
            {
                if (new char[] { '(', '[', '{', '<' }.Contains(ch))
                {
                    stack.Push(ch);
                }
                else
                {
                    char pop = (char)stack.Pop();
                    if (GetOpener(ch) != pop)
                        return "";
                }
            }
            return new string(stack.ToArray().Select(x => (char)x).ToArray());
            
        }
        public static char GetOpener(char ch)
        {
            return ch switch
            {
                ')' => '(',
                ']' => '[',
                '}' => '{',
                '>' => '<'
            };
        }
        public static int GetPointsPart1(char ch){
            return ch switch
            {
                ')' => 3,
                ']' => 57,
                '}' => 1197,
                '>' => 25137,
                '-' => 0
            };
        }
        public static long GetPointsPart2(string str)
        {
            long sum=0;
            foreach (char ch in str)
            {
                sum *= 5;
                sum += GetCharPointP2(ch);
            }
            return sum;
        }
        public static int GetCharPointP2(char ch)
        {
            return ch switch
            {
                '(' => 1,
                '[' => 2,
                '{' => 3,
                '<' => 4,
                '-' => 0
            };
        }
    }
}
