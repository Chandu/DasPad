using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.SortSearchSpecs
{
  public class MeetingRoomsIISpecs
  {
    /*
     * https://techyield.blogspot.com/2019/11/leetcode-meeting-rooms-ii.html
     * LeetCode - Meeting Rooms II
      Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.
      Example 1:
      Input: [[0, 30],[5, 10],[15, 20]]
      Output: 2
      Example 2:
      Input: [[7,10],[2,4]]
      Output: 1
     */
    //Notes:
    /*
     * Thought process:
      The idea is to first sort the array based on start time, so we can examine the meetings as they take place in order (and be greedy).
      Suppose we have three meetings: [0, 30], [5, 10], and [15, 20] in sorted order. When we see the second meeting, we check if its start time is later than the first meeting's end time. It's not, so we need another room. We then compare the third meeting's start time with the minimum of first two meetings' end times. If there is a meeting that ends before the third meeting starts, then we don't need another room.
      So as we iterate through the array, we need to store each meeting's end time and get the minimum quickly. Min heap is a natural choice.
     */

    public class IntervalComparer : IComparer<int[]>
    {
      public int Compare(int[] x, int[] y)
      {
        return x[0].CompareTo(y[0]);
      }
    }

    public int MinMeetingRooms(int[][] intervals)
    {
      return 0;
    }

    [Theory]
    [InlineData("[[0, 30],[5, 10],[15, 20]]", 2)]
    public void CanMinMeetingRooms(string meetings, int expected)
    {
      //Assert.Equal(expected, MinMeetingRooms(meetings.AsArraysFromJsArrays()));
    }
  }
}
