using DasPad.Specs.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs
{
    public static class MiscSpecs
    {
        public static T[] AsArray<T>(params T[] args)
        {
            return args;
        }

        public class TwoNumbers
        {
            [Fact]
            public void TwoSumSpec()
            {
                Assert.Equal(AsArray(1, 2), TwoSum(AsArray(3, 4, 2), 6));
                Assert.Equal(AsArray(0, 2), TwoSum(AsArray(3, 2, 3), 6));
            }

            public int[] TwoSum(int[] nums, int target)
            {
                if (nums.Length < 1)
                {
                    return System.Array.Empty<int>();
                }
                var complementDict = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    var cur = nums[i];
                    var complement = target - cur;
                    if (complementDict.ContainsKey(complement))
                    {
                        return new[]
                        {
              complementDict[complement],
              i
            };
                    }
                    else
                    {
                        complementDict[cur] = i;
                    }
                }
                return System.Array.Empty<int>();
            }
        }

        public class AddTwoNumbersAsLinkedList
        {
            public ListNode AddTwoNumbers(ListNode first, ListNode second)
            {
                var f = first;
                var s = second;
                var carryFwd = 0;
                ListNode toReturn = null;
                ListNode current = null;
                while (f != null && s != null)
                {
                    var sum = f.val + s.val + carryFwd;
                    var remainder = sum % 10;
                    carryFwd = sum / 10;
                    if (current == null)
                    {
                        current = new ListNode(remainder);
                        toReturn = current;
                    }
                    else
                    {
                        current.next = new ListNode(remainder);
                        current = current.next;
                    }

                    f = f.next;
                    s = s.next;
                }

                while (f != null && current != null)
                {
                    var sum = f.val + carryFwd;
                    var remainder = sum % 10;
                    carryFwd = sum / 10;
                    current.next = new ListNode(remainder);
                    current = current.next;
                    f = f.next;
                }
                while (s != null && current != null)
                {
                    var sum = s.val + carryFwd;
                    var remainder = sum % 10;
                    carryFwd = sum / 10;
                    current.next = new ListNode(remainder);
                    current = current.next;
                    s = s.next;
                }
                if (carryFwd > 0 && current != null)
                {
                    current.next = new ListNode(carryFwd);
                }

                return toReturn;
            }

            public ListNode AsListNode(int num)
            {
                var remainder = num % 10;
                int leftOver = num / 10;
                var toReturn = new ListNode(remainder);
                var beginWith = toReturn;
                while (leftOver > 0)
                {
                    remainder = leftOver % 10;
                    leftOver = leftOver / 10;
                    beginWith.next = new ListNode(remainder);
                    beginWith = beginWith.next;
                }
                return toReturn;
            }

            public string ToString(ListNode listNode)
            {
                if (listNode == null)
                {
                    return "";
                }
                return ToString(listNode.next) + listNode.val.ToString();
            }

            [Fact]
            public void AddListsSpec()
            {
                var first = new ListNode(2)
                {
                    next = new ListNode(4)
                    {
                        next = new ListNode(3)
                    }
                };

                var second = new ListNode(5)
                {
                    next = new ListNode(6)
                    {
                        next = new ListNode(4)
                    }
                };
                Assert.Equal(807.ToString(), ToString(AddTwoNumbers(first, second)));

                var other = new ListNode(1)
                {
                    next = first
                };
                Assert.Equal(3886.ToString(), ToString(AddTwoNumbers(other, second)));
                Assert.Equal(10.ToString(), ToString(AddTwoNumbers(new ListNode(5), new ListNode(5))));
                var node99 = AsListNode(99);
                var node1 = AsListNode(1);
                Assert.Equal(100.ToString(), ToString(AddTwoNumbers(node99, node1)));
            }
        }

        public class LongestSubstringWithOutRepeating
        {
            public int LengthOfLongestSubstring(string s)
            {
                var visitedSeqCharsSet = new HashSet<char>();
                var leftBar = 0;
                var rightBar = 0;
                var inputLength = s.Length;
                var answer = 0;
                while (leftBar < inputLength && rightBar < inputLength)
                {
                    if (!visitedSeqCharsSet.Contains(s[rightBar]))
                    {
                        visitedSeqCharsSet.Add(s[rightBar]);
                        rightBar++;
                        answer = Math.Max(answer, rightBar - leftBar);
                    }
                    else
                    {
                        visitedSeqCharsSet.Remove(s[leftBar]);
                        leftBar++;
                    }
                }
                return answer;
            }

            [Theory]
            [InlineData("abcabcbb", 3)]
            public void LengthOfLongestSubstringSpecs(string input, int expected)
            {
                Assert.Equal(expected, LengthOfLongestSubstring(input));
            }
        }
    }
}