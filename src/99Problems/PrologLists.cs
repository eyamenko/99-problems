﻿using System;
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
                .Select((i, idx) => new { Item = i, Index = idx })
                .All(x => x.Item.Equals(list[list.Count - (x.Index + 1)]));
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
            return list.Aggregate(new List<List<T>>(), (acc, i1) =>
            {
                var sublist = acc.LastOrDefault();

                if (sublist == null || !sublist.All(i2 => i2.Equals(i1)))
                {
                    acc.Add(new List<T> { i1 });
                }
                else
                {
                    sublist.Add(i1);
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
    }
}
