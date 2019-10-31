using System;
using System.Collections.Generic;
using System.Linq;
using _99Problems.Models;

namespace _99Problems
{
    /// <summary>
    /// A list is either empty or it is composed of a first element (head) and a tail, which is a list itself.
    /// In Prolog we represent the empty list by the atom [] and a non-empty list by a term [H|T] where H denotes the head and T denotes the tail.
    /// </summary>
    public static class PrologLists
    {
        /// <summary>
        /// Find the last element of a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T _1_01<T>(List<T> list)
        {
            return list.LastOrDefault();
        }

        /// <summary>
        /// Find the last but one element of a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T _1_02<T>(List<T> list)
        {
            return list.ElementAtOrDefault(list.Count - 2);
        }

        /// <summary>
        /// Find the K'th element of a list. The first element in the list is number 1.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static T _1_03<T>(List<T> list, int index)
        {
            return list.ElementAtOrDefault(index - 1);
        }

        /// <summary>
        /// Find the number of elements of a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int _1_04<T>(List<T> list)
        {
            return list.Count;
        }

        /// <summary>
        /// Reverse a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> _1_05<T>(List<T> list)
        {
            return list.AsEnumerable().Reverse().ToList();
        }

        /// <summary>
        /// Find out whether a list is a palindrome. A palindrome can be read forward or backward; e.g. [x,a,m,a,x].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool _1_06<T>(List<T> list)
        {
            return list.SequenceEqual(_1_05(list));
        }

        /// <summary>
        /// Flatten a nested list structure.
        /// Transform a list, possibly holding lists as elements into a 'flat' list by replacing each list with its elements (recursively).
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> _1_07<T>(List<ValueOrList<T>> list)
        {
            return list.SelectMany(i => i.HasValue1 ? new List<T> { i.Value1 } : _1_07(i.Value2)).ToList();
        }

        /// <summary>
        /// Eliminate consecutive duplicates of list elements.
        /// If a list contains repeated elements they should be replaced with a single copy of the element. The order of the elements should not be changed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> _1_08<T>(List<T> list)
        {
            return list.Aggregate(new List<T>(), (acc, i) =>
            {
                if (!acc.Any() || !acc.Last().Equals(i))
                {
                    acc.Add(i);
                }

                return acc;
            });
        }

        /// <summary>
        /// Pack consecutive duplicates of list elements into sublists. If a list contains repeated elements they should be placed in separate sublists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<List<T>> _1_09<T>(List<T> list)
        {
            return list.Aggregate(new List<List<T>>(), (acc, i) =>
            {
                if (!acc.Any() || !acc.Last().First().Equals(i))
                {
                    acc.Add(new List<T> { i });
                }
                else
                {
                    acc.Last().Add(i);
                }

                return acc;
            });
        }

        /// <summary>
        /// Run-length encoding of a list. Use the result of problem 1.09 to implement the so-called run-length encoding data compression method.
        /// Consecutive duplicates of elements are encoded as terms [N,E] where N is the number of duplicates of the element E.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<(int, T)> _1_10<T>(List<T> list)
        {
            return _1_09(list).Select(i => (i.Count, i.First())).ToList();
        }

        /// <summary>
        /// Modified run-length encoding.
        /// Modify the result of problem 1.10 in such a way that if an element has no duplicates it is simply copied into the result list.
        /// Only elements with duplicates are transferred as [N,E] terms.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<ValueOrTerm<T>> _1_11<T>(List<T> list)
        {
            return _1_10(list).Select(i => i.Item1 > 1 ? new ValueOrTerm<T>(i) : new ValueOrTerm<T>(i.Item2)).ToList();
        }

        /// <summary>
        /// Decode a run-length encoded list. Given a run-length code list generated as specified in problem 1.11. Construct its uncompressed version.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> _1_12<T>(List<ValueOrTerm<T>> list)
        {
            return list.SelectMany(i => i.HasValue2 ? Enumerable.Repeat(i.Value2.Item2, i.Value2.Item1) : Enumerable.Repeat(i.Value1, 1)).ToList();
        }

        /// <summary>
        /// Run-length encoding of a list (direct solution). Implement the so-called run-length encoding data compression method directly.
        /// I.e. don't explicitly create the sublists containing the duplicates, as in problem 1.09, but only count them.
        /// As in problem 1.11, simplify the result list by replacing the singleton terms [1,X] by X.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<ValueOrTerm<T>> _1_13<T>(List<T> list)
        {
            return list.Aggregate(new List<ValueOrTerm<T>>(), (acc, i) =>
            {
                var lastValueOrTerm = acc.LastOrDefault();

                if (!acc.Any()
                    || (lastValueOrTerm.HasValue1 && !lastValueOrTerm.Value1.Equals(i))
                    || (lastValueOrTerm.HasValue2 && !lastValueOrTerm.Value2.Item2.Equals(i)))
                {
                    acc.Add(new ValueOrTerm<T>(i));
                }
                else
                {
                    acc[acc.Count - 1] = new ValueOrTerm<T>(lastValueOrTerm.HasValue1 ? 2 : lastValueOrTerm.Value2.Item1 + 1, i);
                }

                return acc;
            });
        }

        /// <summary>
        /// Duplicate the elements of a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> _1_14<T>(List<T> list)
        {
            return list.SelectMany(i => Enumerable.Repeat(i, 2)).ToList();
        }

        /// <summary>
        /// Duplicate the elements of a list a given number of times.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static List<T> _1_15<T>(List<T> list, int times)
        {
            var count = Math.Max(0, times);

            return list.SelectMany(i => Enumerable.Repeat(i, count)).ToList();
        }

        /// <summary>
        /// Drop every N'th element from a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<T> _1_16<T>(List<T> list, int number)
        {
            return list.Where((_, idx) => (idx + 1) % number != 0).ToList();
        }

        /// <summary>
        /// Split a list into two parts; the length of the first part is given.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static (List<T>, List<T>) _1_17<T>(List<T> list, int length)
        {
            var part1 = list.Take(length).ToList();
            var part2 = list.Skip(length).ToList();

            return (part1, part2);
        }

        /// <summary>
        /// Extract a slice from a list.
        /// Given two indices, I and K, the slice is the list containing the elements between the I'th and K'th element of the original list (both limits included).
        /// Start counting the elements with 1.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        /// <returns></returns>
        public static List<T> _1_18<T>(List<T> list, int fromIndex, int toIndex)
        {
            var index = Math.Max(0, fromIndex - 1);
            var count = Math.Min(list.Count, toIndex - Math.Max(0, fromIndex - 1));

            return list.GetRange(index, count);
        }

        /// <summary>
        /// Rotate a list N places to the left. Use the predefined predicates length/2 and append/3, as well as the result of problem 1.17.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="places"></param>
        /// <returns></returns>
        public static List<T> _1_19<T>(List<T> list, int places)
        {
            var parts = _1_17(list, places < 0 ? list.Count + places : places);

            return parts.Item2.Concat(parts.Item1).ToList();
        }

        /// <summary>
        /// Remove the K'th element from a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static (T, List<T>) _1_20<T>(List<T> list, int index)
        {
            var parts = _1_17(list, index - 1);

            return (_1_03(list, index), parts.Item1.Concat(parts.Item2.Skip(1)).ToList());
        }

        /// <summary>
        /// Insert an element at a given position into a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static List<T> _1_21<T>(List<T> list, int index, T element)
        {
            var parts = _1_17(list, index - 1);

            parts.Item1.Add(element);

            return parts.Item1.Concat(parts.Item2).ToList();
        }

        /// <summary>
        /// Create a list containing all integers within a given range.
        /// </summary>
        /// <param name="fromRange"></param>
        /// <param name="toRange"></param>
        /// <returns></returns>
        public static List<int> _1_22(int fromRange, int toRange)
        {
            var count = Math.Max(0, toRange - Math.Max(0, fromRange - 1));

            return Enumerable.Range(fromRange, count).ToList();
        }

        /// <summary>
        /// Extract a given number of randomly selected elements from a list. The selected items shall be put into a result list.
        /// Use the built-in random number generator random/2 and the result of problem 1.20.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static List<T> _1_23<T>(List<T> list, int count, int seed)
        {
            var random = new Random(seed);

            return Enumerable.Range(0, Math.Max(0, count)).Aggregate((list, new List<T>()), (acc, _) =>
            {
                if (!acc.list.Any())
                {
                    return acc;
                }

                var parts = _1_20(acc.list, random.Next(1, acc.list.Count));

                acc.Item2.Add(parts.Item1);

                return (parts.Item2, acc.Item2);
            }).Item2;
        }

        /// <summary>
        /// Lotto: Draw N different random numbers from the set 1..M.
        /// The selected numbers shall be put into a result list. Combine the solutions of problems 1.22 and 1.23.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="maxValue"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static List<int> _1_24(int count, int maxValue, int seed)
        {
            return _1_23(_1_22(1, maxValue), count, seed);
        }

        /// <summary>
        /// Generate a random permutation of the elements of a list. Use the solution of problem 1.23.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static List<T> _1_25<T>(List<T> list, int seed)
        {
            return _1_23(list, list.Count, seed);
        }

        /// <summary>
        /// Generate the combinations of K distinct objects chosen from the N elements of a list.
        /// In how many ways can a committee of 3 be chosen from a group of 12 people?
        /// We all know that there are C(12,3) = 220 possibilities (C(N,K) denotes the well-known binomial coefficients).
        /// For pure mathematicians, this result may be great. But we want to really generate all the possibilities (via backtracking).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static List<List<T>> _1_26<T>(List<T> list, int length)
        {
            if (length == 0 || !list.Any())
            {
                return new List<List<T>>();
            }

            if (length == 1)
            {
                return list.Select(i => new List<T> { i }).ToList();
            }

            var parts = _1_17(list, 1);

            return _1_26(parts.Item2, length - 1).Select(i => parts.Item1.Concat(i).ToList()).Concat(_1_26(parts.Item2, length)).ToList();
        }

        /// <summary>
        /// Group the elements of a set into disjoint subsets.
        /// In how many ways can a group of 9 people work in 3 disjoint subgroups of 2, 3 and 4 persons?
        /// Write a predicate that generates all the possibilities via backtracking.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<List<List<T>>> _1_27a<T>(List<T> list)
        {
            return _1_26(list, 2).Aggregate(new List<List<List<T>>>(), (acc, c1) =>
            {
                var diff = list.Except(c1).ToList();

                _1_26(diff, 3).Select(c2 => new List<List<T>> { c1, c2, diff.Except(c2).ToList() }).ToList().ForEach(acc.Add);

                return acc;
            });
        }
    }
}
