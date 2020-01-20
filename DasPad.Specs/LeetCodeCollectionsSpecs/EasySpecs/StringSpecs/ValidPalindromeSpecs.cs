using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.StringSpecs
{
  public class ValidPalindromeSpecs
  {
    /*
     * Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

      Note: For the purpose of this problem, we define empty string as valid palindrome.

      Example 1:

      Input: "A man, a plan, a canal: Panama"
      Output: true
      Example 2:

      Input: "race a car"
      Output: false
     */

    public bool IsPalindrome(string input)
    {
      if (input == null || input.Trim().Length == 0)
      {
        return true;
      }

      var s = input.ToLower();

      var left = 0;
      var right = s.Length - 1;
      while (left < right)
      {
        if (!char.IsLetterOrDigit(s[left]))
        {
          left++;
          continue;
        }
        else if (!char.IsLetterOrDigit(s[right]))
        {
          right--;
          continue;
        }
        else if (s[left] != s[right])
        {
          return false;
        }
        left++;
        right--;
      }
      return true;
    }

    [Theory]
    [InlineData("aba", true)]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData(",.", true)]
    [InlineData("9;8'4P?X:1Q8`dOfJuJXD6FF,8;`Y4! YBy'Wb:ll;;`;\"JI0c2uvD':!LAk:s\"!'0.!2B55.T1VI?00Du?1,l``RFsc?Y?9vD5 K'3'1b!N8hn:'l. R:9:o`m1r.M2mrJ?`Wjv1`G6i6G`1vjW`?Jrm2M.r1m`o:::R .l':nh8N!b1'3'K 5Dv9?Y?csFR``l,1?uD00?IV1T.55B2!.0'!\"s:kAL!:'Dvu2c0IJ\";`;;ll9bW'yBY !4Y`;8,FF6DXJuJfOd`8Q1:X?P4'8;9", false)]
    public void CanVerifyIsPalindrome(string input, bool expected)
    {
      Assert.Equal(expected, IsPalindrome(input));
      //Assert.True(Enumerable.Range('a', 26).Contains('z'));
    }
  }
}
