using System;
using System.Collections.Generic;
using System.Linq;

namespace kata1_StringCalculator
{
    public class Program
    {
        internal static void Main()
            => Console.WriteLine(Add(Console.ReadLine()));

        //Exercise: https://github.com/ardalis/kata-catalog/blob/master/katas/String%20Calculator.md
        public static int Add(string input)
        {
            var delimiters = GetDelimiters(input);
            var strings = input.Split(delimiters.ToArray(),StringSplitOptions.None).ToList();
            var numbers = new List<int>();

            foreach (var n in strings)
            {
                if (int.TryParse(n, out var number))
                {
                    numbers.Add(number);
                }
            }

            GetNegativeNumbers(numbers);

            return IgnoreNumbersAbove1000(numbers).Sum();
        }

        public static List<string> GetDelimiters(string input)
        {
            var delimiters = new List<string> {"\n", ","};

            if (!input.StartsWith("//")) return delimiters;
            var surroundedDelimiterString = input.Split("\n")[0];

            var delimiterInput = surroundedDelimiterString.Substring(2);
            var delimiterStrings = delimiterInput.Split('[', ']');

            delimiters.AddRange(delimiterStrings);

            return delimiters;
        }

        public static void GetNegativeNumbers(List<int> numbers)
        {
            var negativeNumbers = numbers.Where(x => x < 0).ToList();

            if(negativeNumbers.Any())
                throw new NegativeNumberException(negativeNumbers);
        }

        public static List<int> IgnoreNumbersAbove1000(List<int> numbers)
        {
            return numbers.Where(x=> x <= 1000).ToList();
        }
    }
}
