using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class CanRewardStudentSpecs
  {
    /*
     * You are given a string representing an attendance record for a student. The record only contains the following three characters:
      'A' : Absent.
      'L' : Late.
      'P' : Present.
      A student could be rewarded if his attendance record doesn't contain more than one 'A' (absent) or more than two continuous 'L' (late).

      You need to return whether the student could be rewarded according to his attendance record.

      Example 1:
      Input: "PPALLP"
      Output: True
      Example 2:
      Input: "PPALLL"
      Output: False
     */

    public bool CheckRecord(string s)
    {
      var absents = 0;
      var lates = 0;
      for (var i = 0; i < s.Length; i++)
      {
        var c = s[i];
        if (c == 'L')
        {
          lates++;
        }
        else
        {
          if (c == 'A')
          {
            absents++;
          }
          lates = 0;
        }

        if (absents > 1 || lates > 2)
        {
          return false;
        }
      }
      if (absents > 1 || lates > 2)
      {
        return false;
      }
      return true;
    }

    [Theory]
    [InlineData("LALL", true)]
    [InlineData("LPLPLPLPLPL", true)]
    [InlineData("LLPLLPLPPLLPLPLPPPLPLPLPPPLPPP", true)]
    public void CanCheckRecord(string input, bool expected)
    {
      Assert.Equal(expected, CheckRecord(input));
    }
  }
}
