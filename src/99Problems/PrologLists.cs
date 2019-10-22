using System;
using System.Collections.Generic;
using System.Linq;

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
            return list
                .Take(list.Count / 2)
                .Select((i, idx) => new { Item1 = i, Item2 = _1_03(list, list.Count - idx) })
                .All(i => i.Item1.Equals(i.Item2));
        }

        /// <summary>
        /// Flatten a nested list structure.
        /// Transform a list, possibly holding lists as elements into a 'flat' list by replacing each list with its elements (recursively).
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<object> _1_07(List<object> list)
        {
            return list.SelectMany(i => i is List<object> nestedList ? _1_07(nestedList) : new List<object> { i }).ToList();
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
                if (!acc.Any() || !acc.Last().Last().Equals(i))
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
        public static List<Tuple<int, T>> _1_10<T>(List<T> list)
        {
            return _1_09(list).Select(i => new Tuple<int, T>(i.Count, i.First())).ToList();
        }

        /// <summary>
        /// Modified run-length encoding. Modify the result of problem 1.10 in such a way that if an element has no duplicates it is simply copied into the result list.
        /// Only elements with duplicates are transferred as [N,E] terms.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<object> _1_11<T>(List<T> list)
        {
            return _1_10(list).Select(i => i.Item1 > 1 ? (object)i : i.Item2).ToList();
        }

        /// <summary>
        /// Decode a run-length encoded list. Given a run-length code list generated as specified in problem 1.11. Construct its uncompressed version.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<object> _1_12(List<object> list)
        {
            return list.SelectMany(i => i is Tuple<int, object> term ? Enumerable.Repeat(term.Item2, term.Item1) : Enumerable.Repeat(i, 1)).ToList();
        }

        /// <summary>
        /// Run-length encoding of a list (direct solution). Implement the so-called run-length encoding data compression method directly.
        /// I.e. don't explicitly create the sublists containing the duplicates, as in problem 1.09, but only count them.
        /// As in problem 1.11, simplify the result list by replacing the singleton terms [1,X] by X.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<object> _1_13<T>(List<T> list)
        {
            return list
                .Aggregate(new List<Tuple<int, T>>(), (acc, i) =>
                {
                    if (!acc.Any() || !acc.Last().Item2.Equals(i))
                    {
                        acc.Add(new Tuple<int, T>(1, i));
                    }
                    else
                    {
                        acc[acc.Count - 1] = new Tuple<int, T>(acc.Last().Item1 + 1, i);
                    }

                    return acc;
                })
                .Select(i => i.Item1 > 1 ? (object)i : i.Item2)
                .ToList();
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
    }
}
