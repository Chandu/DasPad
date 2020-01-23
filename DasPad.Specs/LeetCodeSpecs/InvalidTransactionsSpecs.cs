using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class InvalidTransactionsSpecs
  {
    /*
     * A transaction is possibly invalid if:
      the amount exceeds $1000, or;
      if it occurs within (and including) 60 minutes of another transaction with the same name in a different city.
      Each transaction string transactions[i] consists of comma separated values representing the name, time (in minutes), amount, and city of the transaction.

      Given a list of transactions, return a list of transactions that are possibly invalid.  You may return the answer in any order.

      Example 1:

      Input: transactions = ["alice,20,800,mtv","alice,50,100,beijing"]
      Output: ["alice,20,800,mtv","alice,50,100,beijing"]
      Explanation: The first transaction is invalid because the second transaction occurs within a difference of 60 minutes, have the same name and is in a different city. Similarly the second one is invalid too.
      Example 2:

      Input: transactions = ["alice,20,800,mtv","alice,50,1200,mtv"]
      Output: ["alice,50,1200,mtv"]
      Example 3:

      Input: transactions = ["alice,20,800,mtv","bob,50,1200,mtv"]
      Output: ["bob,50,1200,mtv"]
     */

    public class Transaction
    {
      public string Name;
      public string City;
      public int Time;
      public double Amount;
    }

    public IList<string> InvalidTransactions(string[] transactions)
    {
      var txns = transactions.Select(a =>
       {
         var data = a.Split(',').Select(b => b.Trim()).ToArray();
         var txn = new Transaction()
         {
           Name = data[0],
           City = data[3],
           Time = int.Parse(data[1]),
           Amount = double.Parse(data[2]),
         };
         return (a, txn);
       });
      return txns.Where(b =>
      {
        return b.txn.Amount > 1000 || txns.Any(c =>
        {
      var hasSameName = c.txn.Name == b.txn.Name;
      var timeDelta = Math.Abs(b.txn.Time - c.txn.Time);
      var withinTime = timeDelta <= 60 && timeDelta >= 0;
      var isDifferentCity = c.txn.City != b.txn.City;
      return hasSameName && withinTime && isDifferentCity;
    });
      }).Select(b => b.a).ToList();
    }

    [Fact]
    public void CanFindInvalidTransactions()
    {
      Assert.Equal(AsArray("alice,20,800,mtv", "alice,50,100,beijing").ToList(), InvalidTransactions(AsArray("alice,20,800,mtv", "alice,50,100,beijing")));
      Assert.Equal(AsArray("alice,50,1200,mtv").ToList(), InvalidTransactions(AsArray("alice,20,800,mtv", "alice,50,1200,mtv")));
      Assert.Equal(AsArray("bob,656,1366,bangkok", "alex,596,1390,amsterdam").ToList(), InvalidTransactions(AsArray("alex,676,260,bangkok", "bob,656,1366,bangkok", "alex,393,616,bangkok", "bob,820,990,amsterdam", "alex,596,1390,amsterdam")));
    }
  }
}
