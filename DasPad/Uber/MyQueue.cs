using System.Collections.Generic;

namespace DasPad.Uber
{
  public class MyQueue
  {
    private readonly Stack<int> firstStack = new Stack<int>();
    private readonly Stack<int> secondStack = new Stack<int>();

    public MyQueue()
    {
    }

    private Stack<int> GetPrimaryStack()
    {
      return firstStack;
    }

    private Stack<int> GetSecondaryStack()
    {
      return secondStack;
    }

    private void SwapStacks(bool usePrimaryStackAsSource = true)
    {
      var sourceStack = (usePrimaryStackAsSource) ? GetPrimaryStack() : GetSecondaryStack();
      var targetStack = (!usePrimaryStackAsSource) ? GetPrimaryStack() : GetSecondaryStack();
      while (sourceStack.Count > 0)
      {
        targetStack.Push(sourceStack.Pop());
      }
    }

    public void Push(int x)
    {
      GetPrimaryStack().Push(x);
    }

    public int Pop()
    {
      SwapStacks();
      var toReturn = GetSecondaryStack().Pop();
      SwapStacks(false);
      return toReturn;
    }

    public int Peek()
    {
      SwapStacks();
      var toReturn = GetSecondaryStack().Peek();
      SwapStacks(false);
      return toReturn;
    }

    public bool Empty()
    {
      return (GetPrimaryStack().Count + GetSecondaryStack().Count) == 0;
    }
  }
}
