using DasPad.Uber;
using Xunit;

namespace DasPad.Specs.UberSpecs
{
    public class MyQueueSpecs
    {
        [Fact]
        public void CanUseAsQueue()
        {
            var queue = new MyQueue();
            queue.Push(1);
            queue.Push(2);
            Assert.Equal(1, queue.Peek());
            Assert.Equal(1, queue.Pop());
            Assert.False(queue.Empty());
        }

        [Fact]
        public void CanUseAsQueue1()
        {
            var queue = new MyQueue();
            queue.Push(1);
            queue.Push(2);
            Assert.Equal(1, queue.Peek());
            queue.Push(3);
            Assert.Equal(1, queue.Peek());
            Assert.False(queue.Empty());
        }
    }
}