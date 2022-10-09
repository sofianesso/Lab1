using System;
using System.Linq;
using System.Collections.Generic;


public static class StringAppend
{
    public static bool CheckChar(this string stringOnly)
    {
        return !stringOnly.Any(c => c < '0' || c > '9');
    }
}
class findDigitApplication
{


    static void Main(string[] args)
    {
        Console.WriteLine("Enter your string here: ");
        string input = Console.ReadLine();
        ProcessInput(input);
        Console.ReadKey();


    }

    public static void ProcessInput(string input)
    {
        long[] totalSumColor = new long[1000];
        int totalIndex = 0;

        for (int startIndex = 0; startIndex < input.Length - 1; startIndex++)
        {
            for (int endIndex = input.Length - 1; endIndex > startIndex; endIndex--)
            {
                if (input[startIndex] == input[endIndex])
                {
                    
                    bool hasMultiple = input.Substring(startIndex + 1, endIndex - startIndex - 1).Contains(input[startIndex]);

                    if (!hasMultiple && input.Substring(startIndex, endIndex - startIndex).CheckChar())
                        totalSumColor[totalIndex++] = ResultOutput(input, startIndex, endIndex);
                }
            }
        }
        Console.WriteLine("\nTotal: " + sumArray(totalSumColor));
    }

    public static long sumArray(long[] totalSumColor)
    {
        var totalSum = 0L;
        for (int i = 0; i <= totalSumColor.Length; i++)
        {
            if (totalSumColor[i] == 0L)
            {
                break;
            }
            totalSum += totalSumColor[i];
        }
        return totalSum;
    }
    public static long ResultOutput(string actualIndex, int fromStart, int toEnd)
    {

        var primaryColor = Console.ForegroundColor;
        Console.Write(actualIndex.Substring(0, fromStart));
        Console.ForegroundColor = ConsoleColor.DarkRed;
        var str = actualIndex.Substring(fromStart, toEnd - fromStart + 1);
        Console.Write(str);
        Console.ForegroundColor = primaryColor;

        if (toEnd < actualIndex.Length - 1)
        {
            Console.Write(actualIndex.Substring(toEnd + 1));
        }
        Console.WriteLine();

        return long.Parse(str);


    }
}