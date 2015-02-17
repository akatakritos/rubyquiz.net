using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Santa
{
    public class BruteForceRandomizer : ISantaAssigner
    {
        private readonly Random _rng;
        private readonly int _maxIterations;

        public BruteForceRandomizer(Random rng = null, int maxIterations = 100)
        {
            _rng = rng ?? new Random();
            _maxIterations = maxIterations;
        }
        
        public IEnumerable<Assignment> Assign(IEnumerable<Person> people)
        {
            if (people == null) throw new ArgumentNullException("people");

            // ReSharper disable once PossibleMultipleEnumeration
            var santas = people.ToArray();
            // ReSharper disable once PossibleMultipleEnumeration
            var receivers = people.ToArray();
            var assignments = new Assignment[santas.Length];

            int iterations = 0;
            do
            {
                shuffleAssignments(assignments, santas, receivers);
                if (iterations++ > _maxIterations)
                    throw new ImpossibleSantaException();
            } while (!isValid(assignments));

            return assignments;
        }

        private void shuffleAssignments(IList<Assignment> assignments, IList<Person> santas, IList<Person> people)
        {
            shuffle(people);
            for(var i = 0; i < assignments.Count; i++)
                assignments[i] = new Assignment(santas[i], people[i]);
        }

        private void shuffle<T>(IList<T> elements)
        {
            //Fischer-Yates
            var n = elements.Count;
            for (var i = 0; i < n; i++)
            {
                var j = _rng.Next(i, n);
                swap(elements, i, j);
            }
        }

        private void swap<T>(IList<T> elements, int i, int j)
        {
            var tmp = elements[i];
            elements[i] = elements[j];
            elements[j] = tmp;
        }

        private bool isValid(IEnumerable<Assignment> assignments)
        {
            foreach (var a in assignments)
            {
                if (!a.Santa.CanGiveTo(a.Receiver))
                    return false;
            }

            return true;
        }
    }
}
