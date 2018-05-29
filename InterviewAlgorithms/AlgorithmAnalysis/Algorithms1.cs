using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmAnalysis
{
    public static class Algorithms1
    {
        // What does this function do?
        //      It's an extension method for a function delegate (that takes an input of T that returns a TResult) 
        //      and returns a modified version of the implementation that adds caching functionality. Would be
        //      useful for situations where obtaining the result is expensive or latent.

        // How does it work?
        //      It creates a dictionary cache to store the results of previous input values.

        // What is required in terms of c# to make it work. IE min version, etc.
        //      .NET 3.5

        // Write some code that uses it.
        //      See below

        public static Func<T, TResult> A<T, TResult>(this Func<T, TResult> function)
        {
            var map = new Dictionary<T, TResult>();
            return a =>
            {
                TResult value;

                if (map.TryGetValue(a, out value))
                    return value;

                value = function(a);
                map.Add(a, value);
                return value;
            };
        }

        public static void ExampleCode()
        {
            Func<int, bool> func = IsEven;
            var funcWithCache = func.A();

            bool isEven;
            isEven = funcWithCache.Invoke(4); // new input value, new result
            isEven = funcWithCache.Invoke(3); // new input value, new result
            isEven = funcWithCache.Invoke(4); // previously used value, cached result
        }

        private static bool IsEven(int n)
        {
            return (n % 2 == 0);
        }
    }
}
