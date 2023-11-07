using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            int result = 1;
            try
            {
                if (n < 0)
                {
                    throw new ArgumentException("Input must be a non-negative integer.");
                }
                else if (n == 0 || n == 1)
                {
                    return 1;
                }
                else
                    for (int i = 2; i <= n; i++)
                    {
                        result *= i;
                    }
                return result;
            }
            catch (ArgumentException ex)
            {
                result = -1;
                return result;
            }
        }


        public static string FormatSeparators(params string[] items)
        {
            string resultStr = string.Empty;
            try
            {
                if (items.Length == 0)
                    resultStr = "No input Provided";
                else if (items.Length == 1)
                    resultStr = items[0];
                else if (items.Length == 2)
                    resultStr = items[0] + " and " + items[1];
                else
                {
                    string lastInput = items[items.Length - 1];
                    string precedingInputs = string.Join(", ", items, 0, items.Length - 1);
                    resultStr = $"{precedingInputs} and {lastInput}";
                }
            }
            catch(Exception)
            {
                resultStr = "Exception occured";
            }
            return resultStr;
        }
     }
}