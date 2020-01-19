using System.Collections.Generic;

namespace DasPad.Uber
{
  public static class PascalTriangle
  {
    public static IList<IList<int>> Generate(int numRows)
    {
      var toReturn = new List<IList<int>>();

      for (var i = 0; i < numRows; i++)
      {
        if (i == 0)
        {
          toReturn.Add(new List<int>()
          {
            1
          });
        }
        else if (i == 1)
        {
          toReturn.Add(new List<int>()
          {
            1, 1
          });
        }
        else
        {
          var prevList = toReturn[i - 1];
          var curList = new List<int>();
          curList.Add(1);
          for (int l = 0, r = 1; l < prevList.Count - 1 && r < prevList.Count; l++, r++)
          {
            curList.Add(prevList[l] + prevList[r]);
          }
          curList.Add(1);
          toReturn.Add(curList);
        }
      }
      return toReturn;
    }
  }
}
