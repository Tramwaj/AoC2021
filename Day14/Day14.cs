using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D14
{
    class Day14
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines("data14.txt");

            string str = data.First();
            StringBuilder sb = new(str);

            List<(string pair, string ch)> InsertionRules = data.Where(x => x.Contains("->"))
                                                                .Select(x => x.Split("->"))
                                                                .Select(x => (x.First().Trim(), x.Last().Trim()))
                                                                .ToList();

            for (int i = 0; i < 40; i++)
            {

                List<(int position, string ch)> InsertionList = new();

                foreach (var rule in InsertionRules)
                {
                    int position = -1;
                    while (true)
                    {

                        position = str.IndexOf(rule.pair, position+ 1, str.Length - position- 1);
                        if (position < 0)
                            break;
                        InsertionList.Add((position, rule.ch));
                    }                     
                }
                foreach (var insertion in InsertionList.OrderByDescending(x => x.position))
                {
                    str = str.Insert(insertion.position + 1, insertion.ch);
                }
                Console.WriteLine($"{i + 1} {str.Length}");
            }
            List<(char ch, int count)> Occurences = new();
            foreach (char ch in str.ToCharArray().Distinct())
            {
                Occurences.Add((ch, str.ToCharArray().Count(x => x == ch)));
            }
            foreach (var item in Occurences)
            {
                Console.WriteLine($"{item.ch}:{item.count}");
            }
            Console.WriteLine($"Result: {Occurences.Max(x => x.count) - Occurences.Min(x => x.count)}");

        }
    }
}
