using System;
using System.Text;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.ArraysAndStringsSpecs
{
  public class LongestPalindromicSubstringSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/780/
     * Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

      Example 1:

      Input: "babad"
      Output: "bab"
      Note: "aba" is also a valid answer.
      Example 2:

      Input: "cbbd"
      Output: "bb"
     */

    /*
     * Notes:
      For s[i,j] to be a palindrome s[i+1, j-1] should be a palindrome and s[i] == s[j]
    */
    //TIP: DP tabulation need not always be based on it's head, it can be based on it's tail (in this case: s[i+1, j-1] ) So you might need to bound the inner iteration by outer iteration (i.e. j< i instead of j= i+1 in the for loop)

    public string LongestPalindrome(string input)
    {
      if (string.IsNullOrEmpty(input))
      {
        return "";
      }
      var dp = new bool[input.Length, input.Length];
      var longest = 0;
      var startIndex = 0;
      var endIndex = 0;
      for (var i = 0; i < input.Length; i++)
      {
        dp[i, i] = true;
        for (var j = 0; j < i; j++)
        {
          if (input[i] == input[j] && (i - j <= 2 || dp[j + 1, i - 1]))
          {
            dp[j, i] = true;
            if (i - j + 1 > longest)
            {
              longest = i - j + 1;
              startIndex = j;
              endIndex = i;
            }
          }
        }
      }
      return input.Substring(startIndex, endIndex - startIndex + 1);
    }

    [Theory]
    [InlineData("bababbdbababad", "babab")]
    [InlineData("dabcbac", "abcba")]
    [InlineData("cbbd", "bb")]
    public void CanGetLongestPlaindrome(string input, string expected)
    {
      Assert.Equal(expected, LongestPalindrome(input));
    }

    public string LongestPalindromeFromOthers(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        return "";
      }

      int len = s.Length;

      /*
      * solution 1: DP 1
      */
      //         bool[,] isPalindrome = new bool[len, len]; // [start, end]
      //         int start = 0;
      //         int longest = 1;

      //         // longest == 1
      //         for (int i = 0; i < len; i++) {
      //             isPalindrome[i, i] = true;
      //         }

      //         // longest == 2
      //         for (int i = 0; i < len - 1; i++) {
      //             if (s[i] != s[i + 1]) {
      //                 isPalindrome[i, i + 1] = false;
      //                 continue;
      //             }

      //             isPalindrome[i, i + 1] = true;
      //             start = i;
      //             longest = 2;
      //         }

      //         // i: start, j: end
      //         // since the dp formular dependson i+1 and j-1
      //         // i starts from the possible last position
      //         // j starts from the possible beginning position
      //         for (int i = len - 3; i >= 0; i--) {
      //             for (int j = i + 2; j < len; j++) {
      //                 int lenP = j - i + 1;
      //                 if (isPalindrome[i+1, j - 1] && s[i] == s[j]) {
      //                     isPalindrome[i, j] = true;
      //                     // if (longest < lenP) {
      //                     //     start = i;
      //                     //     longest = lenP;
      //                     // }
      //                 }

      //                 if (isPalindrome[i, j] && longest < lenP) {
      //                     start = i;
      //                     longest = lenP;
      //                 }
      //             }
      //         }

      //         return s.Substring(start, longest);

      /*
      * solution 2: DP 2
      */
      //         bool[,] isPalindrome = new bool[len, len]; // [start, end]

      //         // start == end
      //         for (int i = 0; i < len; i++) {
      //             isPalindrome[i, i] = true;
      //         }

      //         // case: lenP == 2
      //         // set true for isPalindrome[i + 1, j - 1]
      //         for (int i = 1; i< len; i++) {
      //             isPalindrome[i, i - 1] = true;
      //         }

      //         int start = 0;
      //         int lenP = 1;

      //         for (int l = 2; l <= len; l++) {
      //             for (int i = 0; i < len - l + 1 ; i++) { // start
      //                 int j = i + l - 1;
      //                 if (isPalindrome[i + 1, j - 1] && s[i] == s[j]) {
      //                     isPalindrome[i, j] = true;
      //                     if (l > lenP) {
      //                         lenP = l;
      //                         start = i;
      //                     }
      //                 }
      //             }
      //         }

      //         return s.Substring(start, lenP);

      /*
      * solution 3: Enumeration from the middle of palindrome
      */
      //         int start = 0;
      //         int longest = 0;

      //         for (int i = 0; i < len; i++) {
      //             int lenP = FindLongestPalindrome(s, i, i);
      //             if (longest < lenP) {
      //                 longest = lenP;
      //                 start = i - longest / 2;
      //             }

      //             lenP = FindLongestPalindrome(s, i, i + 1);
      //             if (longest < lenP) {
      //                 longest = lenP;
      //                 start = i - longest / 2 + 1;
      //             }
      //         }

      //         return s.Substring(start, longest);

      /*
      * solution 4: Manancher's Algorithm O(n)
      */
      string str = GenerateString(s);
      int lenStr = str.Length;
      int[] palindrome = new int[lenStr];
      palindrome[0] = 0;
      int mid = 0;
      int longest = 1;

      for (int i = 1; i < lenStr; i++)
      {
        int lenP = 0;

        if (i < mid + longest)
        {
          int mirror = mid - (i - mid);
          lenP = Math.Min(palindrome[mirror], mid + longest - i);
        }

        while (i - lenP - 1 >= 0 && i + lenP + 1 < lenStr)
        {
          if (str[i + lenP + 1] != str[i - lenP - 1])
          {
            break;
          }
          lenP++;
        }

        if (longest < lenP)
        {
          longest = lenP;
          mid = i;
        }

        palindrome[i] = lenP;
      }

      // longest - 1: remove the last #
      return s.Substring((mid - longest) / 2, longest);
    }

    private int FindLongestPalindrome(string s, int left, int right)
    {
      int len = s.Length;
      int longest = 0;

      // must check left and right before s[left] == s[right]
      // otherwise, s[left] might be out of bound if left == 0
      while (left >= 0 && right < len && s[left] == s[right])
      {
        // must before updating left and right
        // otherwise left == right will never happen
        longest += left == right ? 1 : 2;

        left--;
        right++;
      }

      return longest;
    }

    private string GenerateString(string s)
    {
      int len = s.Length;
      var sb = new StringBuilder();

      for (int i = 0; i < len; i++)
      {
        sb.Append("#");
        sb.Append(s[i]);
      }

      sb.Append("#");

      return sb.ToString();
    }
  }
}
