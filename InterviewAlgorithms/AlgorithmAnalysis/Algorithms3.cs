using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmAnalysis
{
    class Algorithms3
    {
        private List<Person> _People =
            new List<Person> {
                new Person { FirstName = "Amy", LastName="Monroe", Age = 54},
                new Person { FirstName = "Amy", LastName="Duval", Age = 54},
                new Person { FirstName = "Joe", LastName="Conrad", Age = 14},
                new Person { FirstName = "Amy", LastName="Jenkins", Age = 34},
                new Person { FirstName = "Bill", LastName="Monroe", Age = 34},
                new Person { FirstName = "Amy", LastName="Smith", Age = 34},
                new Person { FirstName = "Joe", LastName="Johnson", Age = 14}};

        private class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        public string SortByLastNameThenFirstName()
        {
            // Write code to return a comma delimited list sorted by last name, then first name, then age

            var sortedPeople = _People.OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.Age);

            var commaDelimitedList = new StringBuilder();
            foreach (var person in sortedPeople)
            {
                commaDelimitedList.Append($"{person.FirstName} {person.LastName} {person.Age}");

                if (person != sortedPeople.Last())
                {
                    commaDelimitedList.Append(",");
                }
            }

            return commaDelimitedList.ToString();
        }

        public void CountsByFirstName()
        {
            // Write code to print a count of each first name in this format
            // Amy, 4
            // Joe, 2, etc

            foreach (var group in _People.GroupBy(x => x.FirstName))
            {
                Console.WriteLine($"{group.Key}, {group.Count()}");
            }
        }
    }
}
