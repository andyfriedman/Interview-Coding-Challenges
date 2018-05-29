using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace CrosswordPuzzlerCheater
{
    class Program
    {
        private static Dictionary<int, List<string>> _wordLookup = 
            new Dictionary<int, List<string>>(); // container to group words by their size

        static void Main()
        {
            // populate the lookup dictionary
            var words = File.ReadAllLines("english.csv");
            foreach (var word in words)
            {
                if (!_wordLookup.ContainsKey(word.Length))
                {
                    _wordLookup.Add(word.Length, new List<string>());
                }
                _wordLookup[word.Length].Add(word);
            }

            Console.Write("Enter word length: ");
            var wordLength = int.Parse(Console.ReadLine());
            Console.Write("Enter known letters separated by spaces to indicate position: ");
            var letters = Console.ReadLine().ToUpper().ToCharArray();

            // build the "Where" predicate by chaining Contains() expressions for each known letter
            Expression<Func<string, bool>> predicate = x => true;

            // build the "Where" predicate by chaining Contains() expressions for each known letter.
            // original implementation - returned all words that contained all letters regardless of position
            //
            //Expression<Func<string, bool>> predicate = x => true;
            //foreach (var letter in letters)
            //{
            //    Expression<Func<string, bool>> contains = x => x.Contains(letter);
            //    var invokeExpression = Expression.Invoke(contains, predicate.Parameters);
            //    predicate = Expression.Lambda<Func<string, bool>>(
            //        Expression.AndAlso(predicate.Body, invokeExpression), predicate.Parameters);
            //}

            // build the "Where" predicate by chaining ElementAt() expressions for each known letter.
            // returns all words that contains the letters in specified positions
            var positionCounter = 0;
            foreach (var letter in letters)
            {
                if (letter != ' ')
                {
                    var position = positionCounter;
                    Expression<Func<string, bool>> contains = x => x.ElementAt(position) == letter;
                    var invokeExpression = Expression.Invoke(contains, predicate.Parameters);
                    predicate = Expression.Lambda<Func<string, bool>>(
                        Expression.AndAlso(predicate.Body, invokeExpression), predicate.Parameters);
                }
                positionCounter++;
            }

            var containsQuery = predicate.Compile();

            // start the search
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var foundWords = _wordLookup[wordLength].Where(containsQuery).ToList();
            sw.Stop();

            foreach (var word in foundWords)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();
            Console.WriteLine("Elapsed search time: {0} ticks", sw.ElapsedTicks);
            Console.Write("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
