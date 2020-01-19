using System.Linq;
using System.Text;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class LicenseDasherSpecs
  {
    public static string LicenseKeyFormatting(string input, int charsInGroup)
    {
      var upInput = input.ToUpper();
      var buffer = new StringBuilder();
      var movedCharsLength = 0;
      for (var i = upInput.Length - 1; i >= 0; i--)
      {
        if (upInput[i] != '-')
        {
          buffer.Append(upInput[i]);
          movedCharsLength++;
          if (movedCharsLength > 0 && i != 0 && movedCharsLength % charsInGroup == 0)
          {
            buffer.Append("-");
          }
        }
      }
      return string.Join("", buffer.ToString().ToCharArray().Reverse());
    }

    [Theory]
    [InlineData("5F3Z-2e-9-w", 4, "5F3Z-2E9W")]
    public void CanExecute(string input, int groups, string expected)
    {
      var actual = LicenseKeyFormatting(input, groups);
      Assert.Equal(expected, actual);
    }
  }
}
