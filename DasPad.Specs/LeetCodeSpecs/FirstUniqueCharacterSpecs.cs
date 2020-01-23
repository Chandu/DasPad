using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
    public class FirstUniqueCharacterSpecs
    {
        public int FirstUniqChar(string s)
        {
            IDictionary<char, List<int>> charsMap = new Dictionary<char, List<int>>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!charsMap.ContainsKey(s[i]))
                {
                    charsMap[s[i]] = new List<int>();
                }
                charsMap[s[i]].Add(i);
            }
            var first = charsMap.Where(a => a.Value.Count() == 1).Select(a => a.Value.First());
            return (first.Count() > 0) ? first.First() : -1;
        }

        [Theory]
        [InlineData("leetcode", 0)]
        [InlineData("loveleetcode", 2)]
        public void CanFirstUniqChar(string input, int position)
        {
            Assert.Equal(position, FirstUniqChar(input));
        }
    }
}