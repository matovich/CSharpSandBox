﻿

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SandBoxCore.Test
{
    [TestFixture]
    public class QueueSampleTest
    {
        [Test]
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

        [Test]
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