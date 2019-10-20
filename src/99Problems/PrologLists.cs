﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}