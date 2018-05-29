using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmAnalysis
{
    public static class Algorithms2
    {
        // Implement this function. I would like to return a stream of batches of size <= batchcount while enumerating over the input enumerable.
        // Each batch is defined as a List<T> where List<T>.Count <= batchcount
        public static IEnumerable<List<T>> Batch<T>(this IEnumerable<T> enumerable, int batchCount)
        {
            var currentIndex = 0;

            while (true)
            {
                var batch = enumerable.Skip(currentIndex).Take(batchCount).ToList();
                
                if (batch.Any())
                {
                    currentIndex += batch.Count;
                    yield return batch;
                }
                else
                {
                    yield break;
                }
            }
        }
    }
}
