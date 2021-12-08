namespace D8;

public class Day8
{
    public (int, int) Evaluate(IEnumerable<string> data)
    {
        int result2 = 0;
        int result1 = 0;
        List<string> list = new();
        int[] bu = new[] { 2, 3, 4, 7 };
        Dictionary<char, char[]> dict;
        char[] options = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
        List<string> Results = new List<string>();
        foreach (var line in data)
        {
            result1 += line.Split('|')
                     .Select(x => x.Trim())
                     .Last()
                     .Split(' ')
                     .Where(x => bu.Contains(x.Length))
                     .Count();
            dict = CreateDict();
            string tempSum = "";
            var clues = line.Split('|').First().Split(' ');

            foreach (var item in clues)
            {
                if (item.Length == 2)
                {
                    dict['c'] = dict['c'].Intersect(item.ToCharArray()).ToArray();
                    dict['f'] = dict['f'].Intersect(item.ToCharArray()).ToArray();
                    dict['a'] = dict['a'].Except(item.ToCharArray()).ToArray();
                    dict['b'] = dict['b'].Except(item.ToCharArray()).ToArray();
                    dict['d'] = dict['d'].Except(item.ToCharArray()).ToArray();
                    dict['e'] = dict['e'].Except(item.ToCharArray()).ToArray();
                    dict['g'] = dict['g'].Except(item.ToCharArray()).ToArray();
                }
                if (item.Length == 4)
                {
                    dict['b'] = dict['b'].Intersect(item.ToCharArray()).ToArray();
                    dict['c'] = dict['c'].Intersect(item.ToCharArray()).ToArray();
                    dict['d'] = dict['d'].Intersect(item.ToCharArray()).ToArray();
                    dict['f'] = dict['f'].Intersect(item.ToCharArray()).ToArray();
                    dict['a'] = dict['a'].Except(item.ToCharArray()).ToArray();
                    dict['e'] = dict['e'].Except(item.ToCharArray()).ToArray();
                    dict['g'] = dict['g'].Except(item.ToCharArray()).ToArray();
                }
                if (item.Length == 3)
                {
                    dict['a'] = dict['a'].Intersect(item.ToCharArray()).ToArray();
                    dict['c'] = dict['c'].Intersect(item.ToCharArray()).ToArray();
                    dict['f'] = dict['f'].Intersect(item.ToCharArray()).ToArray();
                    dict['b'] = dict['b'].Except(item.ToCharArray()).ToArray();
                    dict['d'] = dict['d'].Except(item.ToCharArray()).ToArray();
                    dict['e'] = dict['e'].Except(item.ToCharArray()).ToArray();
                    dict['g'] = dict['g'].Except(item.ToCharArray()).ToArray();
                }
                if (item.Length == 5)
                {
                    dict['a'] = dict['a'].Intersect(item.ToCharArray()).ToArray();
                    //dict['c'] = dict['c'].Intersect(item.ToCharArray()).ToArray();
                    dict['d'] = dict['d'].Intersect(item.ToCharArray()).ToArray();
                    dict['g'] = dict['g'].Intersect(item.ToCharArray()).ToArray();
                }
                if (item.Length == 6)
                {
                    dict['a'] = dict['a'].Intersect(item.ToCharArray()).ToArray();
                    dict['b'] = dict['b'].Intersect(item.ToCharArray()).ToArray();
                    dict['f'] = dict['f'].Intersect(item.ToCharArray()).ToArray();
                    dict['g'] = dict['g'].Intersect(item.ToCharArray()).ToArray();
                    //dict['c'] = dict['c'].Intersect(options.Except(item.ToCharArray())).ToArray();
                    //dict['d'] = dict['d'].Intersect(options.Except(item.ToCharArray())).ToArray();
                    //dict['e'] = dict['e'].Intersect(options.Except(item.ToCharArray())).ToArray();
                    //dict['a'] = dict['a'].Except(item.ToCharArray()).ToArray();
                    //dict['b'] = dict['b'].Except(item.ToCharArray()).ToArray();
                    //dict['f'] = dict['f'].Except(item.ToCharArray()).ToArray();
                    //dict['g'] = dict['g'].Except(item.ToCharArray()).ToArray();
                }
            }
            foreach (char ch in options)
            {
                if (dict[ch].Count() == 1)
                {
                    foreach (var ch2 in options)
                    {
                        if (ch2 != ch) dict[ch2] = dict[ch2].Except(dict[ch]).ToArray();
                    }
                }
            }

            Console.WriteLine("State:");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {new string(item.Value)}");
            }
            

            var readings = line.Split('|').Last().Split(' ');
            foreach (var item in readings)
            {
                var digit = GetNumber(TranslateDigits(item.ToCharArray(),dict));
                Console.Write($" {digit} ");
                tempSum = tempSum + digit.ToString();
            }
            result2 += int.Parse(tempSum);
            //Console.WriteLine(line.Split('|').Last());

        }
        Console.WriteLine(result1);
        Console.WriteLine(result2);
        return (result1, result2);


        Dictionary<char, char[]> CreateDict()
        {
            char[] chars = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            return new Dictionary<char, char[]>
                {
                    { 'a', (char[])chars.Clone() },
                    { 'b', (char[])chars.Clone() },
                    { 'c', (char[])chars.Clone() },
                    { 'd', (char[])chars.Clone() },
                    { 'e', (char[])chars.Clone() },
                    { 'f', (char[])chars.Clone() },
                    { 'g', (char[])chars.Clone() }
                };
        }
    }
    private char[] TranslateDigits(char[] digits, Dictionary<char, char[]> dictionary)
    {
        Console.WriteLine($"Input before translation: {new string(digits)}");
        List<char> translatedDigits = new ();
        foreach (var ch in digits)
        {
            foreach (var dictItem in dictionary)
            {
                if (dictItem.Value.First() == ch)
                {
                    translatedDigits.Add(dictItem.Key);
                }
            }
        }
        Console.WriteLine($"Input after translation: {new string(translatedDigits.ToArray())}");
        return translatedDigits.ToArray();
    }
    private int GetNumber(char[] digits)
    {
        Console.WriteLine($"Input: {new string(digits)}");
        char a = 'a'; char b = 'b'; char c = 'c'; char d = 'd'; char e = 'e'; char f = 'f'; char g = 'g';
        char[] zero = new char[] { a, b, c, e, f, g };
        char[] one = new char[] { c, f };
        char[] two = new char[] { a, c, d, e, g };
        char[] three = new char[] { a, c, d, f, g };
        char[] four = new char[] { b, c, d, f };
        char[] five = new char[] { a, b, d, f, g };
        char[] six = new char[] { a, b, d, e, f, g };
        char[] seven = new char[] { a, c, f };
        char[] eight = new char[] { a, b, c, d, e, f, g };
        char[] nine = new char[] { a, b, c, d, f, g, };
            
        if (digits.Count()==(zero).Count()&& !digits.Except(zero).Any() )
            return 0;
        if (digits.Count()==(one).Count() && !digits.Except(one).Any())
            return 1;
        if (digits.Count()==(two).Count() && !digits.Except(two).Any())
            return 2;
        if (digits.Count()==(three).Count() && !digits.Except(three).Any())
            return 3;
        if (digits.Count()==(four).Count() && !digits.Except(four).Any())
            return 4;
        if (digits.Count()==(five).Count() && !digits.Except(five).Any())
            return 5;
        if (digits.Count()==(six).Count() && !digits.Except(six).Any())
            return 6;
        if (digits.Count()==(seven).Count() && !digits.Except(seven).Any())
            return 7;
        if (digits.Count()==(eight).Count() && !digits.Except(eight).Any())
            return 8;
        if (digits.Count()==(nine).Count() && !digits.Except(nine).Any())
            return 9;
        else throw new NotImplementedException();
    }
}
