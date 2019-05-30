using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private static List<string> _delimiters = new List<string>() { ",", "\n", "//", "[", "]" };
        public int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
                return 0;

            var allDelimiters = GetDelimiters(numbers);

            int[] nums = numbers
                .Split(allDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(n => Convert.ToInt32(n))
                .Where(n => n < 1000)
                .ToArray();


            CheckForNegativeNumbers(nums);

            return nums.Sum();
        }

        private static List<string> GetDelimiters(string numbers)
        {

            if (numbers.StartsWith("//[") && numbers.Contains("]["))
            {
                _delimiters.Add(numbers.Split('[', ']')[1]);
                _delimiters.Add(numbers.Split('[', ']')[3]);
            }
            else if (numbers.StartsWith("//["))
            {
                _delimiters.Add(numbers.Split('[', ']')[1]);
            }
            else if (numbers.StartsWith("//"))
            {
                _delimiters.Add(numbers[2].ToString());
            }
            return _delimiters;
        }

        private static void CheckForNegativeNumbers(int[] numbers)
        {

            var negNumbers = numbers.Where(n => n < 0);

            if (negNumbers.Any())
            {
                throw new ArgumentException("negatives not allowed " + string.Join(" ", negNumbers));
            }
        }
    }
}
