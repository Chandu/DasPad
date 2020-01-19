using DasPad.Uber;
using Xunit;

namespace DasPad.Specs.UberSpecs
{
  public class PascalTriangleSpecs
  {
    [Fact]
    public void CanGenerate()
    {
      var result = PascalTriangle.Generate(4);
      Assert.Equal(4, result.Count);
    }
  }
}