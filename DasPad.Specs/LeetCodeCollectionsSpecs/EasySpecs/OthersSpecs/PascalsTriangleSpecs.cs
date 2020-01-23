using System.Collections.Generic;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.OthersSpecs
{
    public class PascalsTriangleSpecs
    {
        /*
         * Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.

            In Pascal's triangle, each number is the sum of the two numbers directly above it.

            Example:

            Input: 5
            Output:
            [
                 [1],
                [1,1],
               [1,2,1],
              [1,3,3,1],
             [1,4,6,4,1]
            [1,5,10,10,5,1]
           [1,6,15,20,15,6,1]
          [1,7,21,35,35,21,7,1]
         [1,8,28,56,70,56,28,9,1]
         */

        public IList<IList<int>> Generate(int numRows)
        {
            var toReturn = new List<IList<int>>();

            for (var i = 0; i < numRows; i++)
            {
                if (i == 0)
                {
                    toReturn.Add(new[] { 1 });
                }
                else
                {
                    var newList = new List<int>();
                    for (var j = 0; j < i + 1; j++)
                    {
                        if (j == 0 || j == i)
                        {
                            newList.Add(1);
                        }
                        else
                        {
                            newList.Add(toReturn[i - 1][j - 1] + toReturn[i - 1][j]);
                        }
                    }
                    toReturn.Add(newList);
                }
            }
            return toReturn;
        }
    }
}