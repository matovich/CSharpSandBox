// Paul Matovich  2014

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class QueueSampleTest
    {
        [TestMethod]
        public void CheckQueueIndexLocations()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(1, queue.ElementAt(0));
            Assert.AreEqual(2, queue.ElementAt(1));

            queue.Dequeue();
            Assert.AreEqual(2, queue.ElementAt(0));
            Assert.AreEqual(3, queue.ElementAt(1));
        }

        [TestMethod]
        public void CheckStackIndexLocations()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Assert.AreEqual(5, stack.ElementAt(0));
            Assert.AreEqual(4, stack.ElementAt(1));

            stack.Pop();
            Assert.AreEqual(4, stack.ElementAt(0));
            Assert.AreEqual(3, stack.ElementAt(1));
        }
    }
}