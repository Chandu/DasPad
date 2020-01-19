using System;
using System.Linq;

namespace DasPad
{
  public class Program
  {
    private static void Main(String[] args)
    {
      var data = new[]
    {
        1,
        2,
        3,
        4,
        5,
        6
      };

      SwapNumbers(data);
      data.ToList().ForEach(Console.WriteLine);

      Console.WriteLine("Bonjour!!!");
    }

    private static void SwapNumbers(int[] inputArray)
    {
      var temp = inputArray[0];
      inputArray[0] = inputArray[inputArray.Length - 1];
      inputArray[inputArray.Length - 1] = temp;
    }
  }
}