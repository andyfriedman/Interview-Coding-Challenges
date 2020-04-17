using System;

namespace StringReverse
{
    /// <summary>
    /// Write a function to reverse a string without allocating any new strings in memory
    /// </summary>
    class Program
    {
        unsafe static void Main(string[] args)
        {
            Console.Write("Enter a string to be reversed: ");
            var str = Console.ReadLine();

            var reversed = Reverse(str);

            Console.WriteLine(reversed);
        }

        unsafe static string Reverse(string str)
        {
            fixed (char* pStr = str)
            {
                int start = 0, end = str.Length - 1;
                while (start < end)
                {
                    pStr[start] ^= pStr[end];
                    pStr[end] ^= pStr[start];
                    pStr[start] ^= pStr[end];
                    ++start; --end;
                }
                return str;
            }
        }
    }
}
