using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class EmailCheckerSpecs
  {
    public int NumUniqueEmails(string[] emails)
    {
      var hashSet = new HashSet<string>();
      foreach (var email in emails)
      {
        var atSymbol = email.IndexOf('@');
        var sb = new StringBuilder(email.Length);
        var i = 0;
        while (i < atSymbol)
        {
          var c = email[i];
          i++;
          if (c == '+')
          {
            break;
          }
          if (c == '.')
          {
            continue;
          }
          sb.Append(c);
        }
        sb.Append("@" + email.Substring(atSymbol + 1));
        hashSet.Add(sb.ToString());
      }
      return hashSet.Count;
    }

    [Fact]
    public void CanNumUniqueEmails()
    {
      //Assert.Equal(2, NumUniqueEmails(new[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" }));
      Assert.Equal(2, NumUniqueEmails(new[] { "test.email+alex@leetcode.com", "test.email.leet+alex@code.com" }));
    }
  }
}
