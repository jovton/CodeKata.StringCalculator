using System;
using System.Linq;

namespace CodeKata.StringCalculator
{
    public class StringCalculator
    {
        public decimal Add(string numbersString)
        {
            var delimiters = new char[] { ',', '\n' };

            if (numbersString.StartsWith("//"))
            {
                delimiters = delimiters.Append(numbersString[2]).ToArray();
                numbersString = numbersString.Substring(3);
            }

            var numbers = numbersString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(n => Convert.ToDecimal(n));

            if (numbers.Any(n => n < 0))
                throw new ArgumentException("Negatives not allowed");

            var sum = numbers.Sum();

            return sum;
        }
    }
}
