using System;
using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class DayOfTheWeekSpecs
  {
    /*
     * https://leetcode.com/problems/day-of-the-week/
     * Given a date, return the corresponding day of the week for that date.

The input is given as three integers representing the day, month and year respectively.

Return the answer as one of the following values {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}.

      Example 1:

    Input: day = 31, month = 8, year = 2019
    Output: "Saturday"
    Example 2:

    Input: day = 18, month = 7, year = 1999
    Output: "Sunday"
    Example 3:

    Input: day = 15, month = 8, year = 1993
    Output: "Sunday"

     *
     */

    public string DayOfTheWeek(int day, int month, int year)
    {
      var knownStart = DaysFromStart(26, 1, 2020);// new DateTime(26,1,2020);
      var unknownStart = DaysFromStart(day, month, year);
      var deltaDays = knownStart - unknownStart;
      var deltaWeekDays = deltaDays % 7;
      var baseDays = new[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
      return (deltaWeekDays > 0) ? baseDays[7 - deltaWeekDays] : baseDays[deltaWeekDays];
    }

    public int DaysFromStart(int day, int month, int year)
    {
      var toReturn = 0;
      for (var i = 1971; i < year; i++)
      {
        toReturn += 365;
        if (IsLeapYear(i))
        {
          toReturn++;
        }
      }
      var daysInMonth = new[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
      for (var i = 1; i < month; i++)
      {
        toReturn += daysInMonth[i - 1];
        if (i == 2 && IsLeapYear(year))
        {
          toReturn++;
        }
      }

      return toReturn + day;
    }

    public bool IsLeapYear(int year)
    {
      return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }

    [Theory]
    [InlineData("Saturday", 31, 8, 2019)]
    //[InlineData("Tuesday", 28, 1, 2019)]
    public void CanDayOfTheWeek(string expected, int day, int month, int year)
    {
      Assert.Equal(expected, DayOfTheWeek(day, month, year));
      //Assert.Equal(148, DaysFromStart(26, 01, 2020) - DaysFromStart(31, 08, 2019));
    }
  }
}
