using DasPad.Uber;
using Xunit;

namespace DasPad.Specs.UberSpecs
{
  public class PermutatorSpecs
  {
    [Fact]
    public void CanPermute()
    {
      string str = "ABC";
      int n = str.Length;
      var result = Permutator.Permute(str);
      Assert.Equal(result, new[] {
      "ABC",
      "ACB",
      "BAC",
      "BCA",
      "CBA",
      "CAB"
      });
    }
  }
}
