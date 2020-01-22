using System.Collections.Generic;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.MathSpecs
{
  public class FizzBuzzSpecs
  {
    /*
     * Write a program that outputs the string representation of numbers from 1 to n.

      But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”. For numbers which are multiples of both three and five output “FizzBuzz”.

      Example:

      n = 15,

      Return:
      [
          "1",
          "2",
          "Fizz",
          "4",
          "Buzz",
          "Fizz",
          "7",
          "8",
          "Fizz",
          "Buzz",
          "11",
          "Fizz",
          "13",
          "14",
          "FizzBuzz"
      ]
     */

    public IList<string> FizzBuzz(int n)
    {
      var toReturn = new List<string>();
      for (var i = 1; i <= n; i++)
      {
        if (i % 15 == 0)
        {
          toReturn.Add("FizzBuzz");
        }
        else if (i % 5 == 0)
        {
          toReturn.Add("Buzz");
        }
        else if (i % 3 == 0)
        {
          toReturn.Add("Fizz");
        }
        else
        {
          toReturn.Add(i.ToString());
        }
      }
      return toReturn;
    }
  }
}
