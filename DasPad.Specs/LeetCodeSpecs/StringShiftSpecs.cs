using System.Text;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class StringShiftSpecs
  {
    public bool RotateString(string A, string B)
    {
      return RotateStringKMP(A, B);
    }

    //Tip:
    /*
     * Intuition
       All rotations of A are contained in A+A. Thus, we can simply check whether B is a substring of A+A. We also need to check A.length == B.length

      KMP algorithm is a textbook algorithm that does string matching in linear time, which is faster than brute force.
     */

    //Revisit: KMP
    public bool RotateStringKMP(string A, string B)
    {
      var lpsB = new int[B.Length];
      lpsB[0] = 0;
      var lengthOfPrefixMatchedSoFar = 0;
      var indexInString = 1;
      while (indexInString < B.Length)
      {
        if (B[indexInString] == B[lengthOfPrefixMatchedSoFar])
        {
          lpsB[indexInString] = ++lengthOfPrefixMatchedSoFar;
          indexInString++;
        }
        else
        {
          if (lengthOfPrefixMatchedSoFar != 0)
          {
            lengthOfPrefixMatchedSoFar = lpsB[lengthOfPrefixMatchedSoFar - 1];
          }
          else
          {
            lpsB[indexInString] = 0;
            indexInString++;
          }
        }
      }
      var foundIndex = -1;
      var patIndex = 0;
      var inputIndex = 0;
      var input = A + A;
      var pattern = B;
      while (inputIndex < input.Length && patIndex < pattern.Length)
      {
        if (input[inputIndex] == pattern[patIndex])
        {
          if (patIndex == pattern.Length - 1)
          {
            return (inputIndex - pattern.Length + 1) >= 0;
          }
          else
          {
            patIndex++;
            inputIndex++;
          }
        }
        else
        {
          if (patIndex != 0)
          {
            patIndex = lpsB[patIndex - 1];
          }
          else
          {
            inputIndex++;
          }
        }
      }
      return foundIndex >= 0;
    }

    public bool RotateStringBruteForce(string A, string B)
    {
      if (string.IsNullOrEmpty(A) && string.IsNullOrEmpty(B))
      {
        return true;
      }
      if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B) || (A.Length != B.Length))
      {
        return false;
      }
      var i = 0;
      var sb = new StringBuilder(A);
      while (i <= A.Length - 2)
      {
        i++;
        var temp = sb[0];
        var j = 0;
        while (j < A.Length - 1)
        {
          sb[j] = sb[j + 1];
          j++;
        }
        sb[A.Length - 1] = temp;

        if (sb.ToString() == B)
        {
          return true;
        }
      }
      return false;
    }

    [Theory]
    [InlineData("abcde", "cdeab", true)]
    [InlineData("mndqvdqktyxknfdtklxapbkuxuzwubpiwmqgickuwqishkrgzu", "rgzumndqvdqktyxknfdtklxapbkuxuzwubpiwmqgickuwqishk", true)]
    public void CabRotateString(string A, string B, bool expected)
    {
      Assert.Equal(expected, RotateString(A, B));
    }
  }
}
