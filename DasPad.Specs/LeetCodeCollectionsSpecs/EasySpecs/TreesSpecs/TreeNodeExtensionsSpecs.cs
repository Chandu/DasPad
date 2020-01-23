using Xunit;
using DasPad.Specs.Models;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.TreesSpecs
{
  public class TreeNodeExtensionsSpecs
  {
    [Theory]
    [InlineData("1, 2, 3, 4, 5, 6")]
    [InlineData("1, 2, 3, null, null, 5, 6")]
    [InlineData("5, 2, 3, null, null, 2, 4, 3, 1")]
    public void CanSerializeAndDeserialize(string ser)
    {
      Assert.Equal(ser, ser.AsTreeNode().AsString());
    }

    [Fact]
    public void CanSerializeEmpty()
    {
      string[] a = new string[0];
      Assert.Equal("", a.AsTreeNode().AsString());
      Assert.Equal("", "".AsTreeNode().AsString());
    }
  }
}
