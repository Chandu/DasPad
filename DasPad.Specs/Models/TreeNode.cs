namespace DasPad.Specs.Models
{
  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x)
    {
      val = x;
    }

    public override string ToString()
    {
      return val.ToString();
    }
  }
}
