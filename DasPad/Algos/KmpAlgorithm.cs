namespace DasPad.Algos
{
  public static class KmpAlgorithm
  {
    public static int[] CreateLps(string input)
    {
      if (input.Length < 1)
      {
        return System.Array.Empty<int>();
      }

      var lps = new int[input.Length];
      lps[0] = 0;
      var lengthOfPrefixMatchedSoFar = 0;
      var indexInString = 1;
      while (indexInString < input.Length)
      {
        if (input[indexInString] == input[lengthOfPrefixMatchedSoFar])
        {
          lps[indexInString] = ++lengthOfPrefixMatchedSoFar;
          indexInString++;
        }
        else
        {
          if (lengthOfPrefixMatchedSoFar != 0)
          {
            lengthOfPrefixMatchedSoFar = lps[lengthOfPrefixMatchedSoFar - 1];
          }
          else
          {
            lps[indexInString] = 0;
            indexInString++;
          }
        }
      }
      return lps;
    }

    public static int FindPatternIndex(string input, string pattern)
    {
      if (input.Length < pattern.Length)
      {
        return -1;
      }
      var lps = CreateLps(pattern);
      var foundIndex = -1;
      var patIndex = 0;
      var inputIndex = 0;
      while (inputIndex < input.Length && patIndex < pattern.Length)
      {
        if (input[inputIndex] == pattern[patIndex])
        {
          if (patIndex == pattern.Length - 1)
          {
            return (inputIndex - pattern.Length + 1);
          }
          else
          {
            patIndex++;
            inputIndex++;
          }
        }
        else
        {
          if (patIndex != 0)
          {
            patIndex = lps[patIndex - 1];
          }
          else
          {
            inputIndex++;
          }
        }
      }
      return foundIndex;
    }
  }
}
