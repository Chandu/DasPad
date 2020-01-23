using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
    public class MostCommonWordSpecs
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var input = paragraph.ToLower();
            var words = new List<string>();
            var index = 0;
            var buffer = "";
            while (index < paragraph.Length)
            {
                if (!(input[index] >= 'a' && input[index] <= 'z'))
                {
                    if (buffer.Length > 0)
                    {
                        words.Add(buffer);
                        buffer = "";
                    }
                }
                else
                {
                    buffer += input[index];
                }
                index++;
            }

            if (buffer.Length > 0)
            {
                words.Add(buffer);
            }
            var wordsMap = new Dictionary<string, int>();
            var bannedList = banned.ToList();
            foreach (var word in words)
            {
                if (!bannedList.Contains(word))
                {
                    if (!wordsMap.ContainsKey(word))
                    {
                        wordsMap[word] = 0;
                    }
                    wordsMap[word]++;
                }
            }
            return wordsMap.OrderByDescending(a => a.Value).Select(a => a.Key).FirstOrDefault();
        }

        [Fact]
        public void CanMostCommonWord()
        {
            Assert.Equal("ball", MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new[] { "hit" }));
            Assert.Equal("bob", MostCommonWord("Bob", new string[0]));
        }
    }
}