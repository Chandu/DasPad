using System;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.DesignSpecs
{
  internal class MinStackSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-easy/98/design/562/
     * Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

      push(x) -- Push element x onto stack.
      pop() -- Removes the element on top of the stack.
      top() -- Get the top element.
      getMin() -- Retrieve the minimum element in the stack.

      Example:

      MinStack minStack = new MinStack();
      minStack.push(-2);
      minStack.push(0);
      minStack.push(-3);
      minStack.getMin();   --> Returns -3.
      minStack.pop();
      minStack.top();      --> Returns 0.
      minStack.getMin();   --> Returns -2.
     */

    public class MinStack
    {
      private Node head;

      public void Push(int x)
      {
        if (head == null)
          head = new Node(x, x);
        else
          head = new Node(x, Math.Min(x, head.min), head);
      }

      public void Pop()
      {
        head = head.next;
      }

      public int Top()
      {
        return head.val;
      }

      public int GetMin()
      {
        return head.min;
      }

      internal class Node
      {
        public int val;
        public int min;
        public Node next;

        internal Node(int val, int min) : this(val, min, null)
        {
        }

        internal Node(int val, int min, Node next)
        {
          this.val = val;
          this.min = min;
          this.next = next;
        }
      }
    }
  }
}
