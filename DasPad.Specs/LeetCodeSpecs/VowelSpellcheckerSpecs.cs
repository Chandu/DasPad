using Xunit;
using System.Linq;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class VowelSpellcheckerSpecs
  {
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
      if(!queries.Any())
      {
        return queries;
      }
      if(!wordlist.Any())
      {
        return wordlist;
      }
      for(var i=0; i< queries.Length; i++)
      {
        var query = queries[i];
        if (wordlist.Contains(query))
        {

        }
      }
      return queries;

    }

    private static T[] AsArray<T>(params T[] parameters) => parameters;

    [Fact]
    public void CanSpellChecker()
    {
      //Assert.Equal(AsArray("kite", "KiTe", "KiTe", "Hare", "hare", "", "", "KiTe", "", "KiTe"), Spellchecker(AsArray("KiTe", "kite", "hare", "Hare"), AsArray("kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto")));
    }
  }
}
