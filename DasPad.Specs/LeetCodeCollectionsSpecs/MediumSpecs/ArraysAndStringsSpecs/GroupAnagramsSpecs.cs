using System;
using System.Collections.Generic;
using System.Linq;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.ArraysAndStringsSpecs
{
  public class GroupAnagramsSpecs
    {
        /*
         * https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/778/
         * Given an array of strings, group anagrams together.

            Example:

            Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
            Output:
            [
              ["ate","eat","tea"],
              ["nat","tan"],
              ["bat"]
            ]
            Note:

            All inputs will be in lowercase.
            The order of your output does not matter.
         */

        //Intuition: Two strings are anagrams if and only if their character counts(respective number of occurrences of each character) are the same.
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var hashMap = new Dictionary<string, IList<string>>();
            for (var i = 0; i < strs.Length; i++)
            {
                var ints = new int[26];

                for (var j = 0; j < strs[i].Length; j++)
                {
                    int index = strs[i][j] - 'a';
                    ints[index]++;
                }
                var key = string.Join("|", ints);
                if (!hashMap.ContainsKey(key))
                {
                    hashMap[key] = new List<string>();
                }
                hashMap[key].Add(strs[i]);
            }
            return hashMap.Select(a => a.Value).ToList();
        }

        /*
         * Time: O(nmlogm) where m is the longest string. n for the outer loop. mlogm for the sort(assuming Quick/Merge sort)
         **/

        public IList<IList<string>> GroupAnagramsIntuitive(string[] strs)
        {
            var hashMap = new Dictionary<string, IList<string>>();
            for (var i = 0; i < strs.Length; i++)
            {
                var chars = strs[i].ToCharArray();
                Sort(chars);
                var key = string.Join("", chars);
                if (!hashMap.ContainsKey(key))
                {
                    hashMap[key] = new List<string>();
                }
                hashMap[key].Add(strs[i]);
            }
            return hashMap.Select(a => a.Value).ToList();
        }

        public void Sort(char[] input)
        {
            Array.Sort(input);
        }
    }
}