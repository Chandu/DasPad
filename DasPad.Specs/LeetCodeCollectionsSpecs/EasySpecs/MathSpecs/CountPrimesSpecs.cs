using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.MathSpecs
{
  public class CountPrimesSpecs
  {
    /*
     * Count the number of prime numbers less than a non-negative number, n.

        Example:

        Input: 10
        Output: 4
        Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.

     */

    public int CountPrimes(int n)
    {
      //if (n < 2)
      //{
      //  return n / 2;
      //}

      //var count = 0;
      //for (var j = 2; j <= n; j++)
      //{
      //  //if (IsPrimeUsingNBy2(j))
      //  //if (IsPrimeUsingSquareRootLimit(j))
      //  if(IsPrimeBySieveOfEratosthenes(j))
      //  {
      //    count++;
      //  }
      //}

      //return count;

      return GetPrimesBySieveOfEratosthenes(n);
    }

    private bool IsPrimeUsingNBy2(int n)
    {
      for (var i = 2; i <= Math.Ceiling(n / 2d); i++)
      {
        if (n % i == 0)
        {
          return false;
        }
      }
      return true;
    }

    private bool IsPrimeUsingSquareRootLimit(int n)
    {
      for (var i = 2; i * i <= n; i++)
      {
        if (n % i == 0)
        {
          return false;
        }
      }
      return true;
    }

    //TODO: (CV) Memorize Find Primes - Algorithm
    public int GetPrimesBySieveOfEratosthenes(int n)
    {
      var isPrime = new bool[n];
      for (int i = 2; i < n; i++)
      {
        isPrime[i] = true;
      }
      // Loop's ending condition is i * i < n instead of i < sqrt(n)
      // to avoid repeatedly calling an expensive function sqrt().
      for (int i = 2; i * i < n; i++)
      {
        if (!isPrime[i]) continue;
        for (int j = i * i; j < n; j += i)
        {
          isPrime[j] = false;
        }
      }
      int count = 0;
      for (int i = 2; i < n; i++)
      {
        if (isPrime[i]) count++;
      }
      return count;
    }

    [Theory]
    [InlineData(10, 4)]
    public void CanCountPrimes(int input, int expected)
    {
      Assert.Equal(expected, CountPrimes(input));
    }
  }
}
