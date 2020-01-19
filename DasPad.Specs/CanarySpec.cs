using Xunit;

namespace DasPad.Specs
{
  public class CanarySpec
  {
    [Fact]
    public void PassingTest()
    {
      Assert.Equal(4, Add(2, 2));
    }

    private int Add(int x, int y)
    {
      return x + y;
    }
  }
}
