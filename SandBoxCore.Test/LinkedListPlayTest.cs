using NUnit.Framework;

namespace SandBox.Test
{
    [TestFixture]
    public class LinkedListPlayTest
    {
        [Test]
        public void CreatesLinkedList()
        {
            LinkedListPlay target = TargetMaker();

            Assert.NotNull(target.TheLinkedList);
        }

        [Test]
        public void HoldsFiveElements()
        {
            LinkedListPlay target = TargetMaker();
            target.AddFiveElements();

            Assert.AreEqual(5, target.TheLinkedList.Count);

            int expected = 0;
            foreach (int i in target.TheLinkedList)
            {
                Assert.AreEqual(expected, i);
                expected += 2;
            }
        }

        [Test]
        public void InsertMissingElementsWhileInForLoop()
        {
            LinkedListPlay target = TargetMaker();
            target.AddFiveElements();
            target.InsertBetween();

            Assert.AreEqual(10, target.TheLinkedList.Count);
        }

        [Test]
        public void InsertSequentialMissingElementsWhileInForeLoop()
        {
            LinkedListPlay target = TargetMaker();
            target.AddFiveElements();
            target.InsertBetween();

            int expected = 0;
            foreach (int i in target.TheLinkedList)
            {
                Assert.AreEqual(expected, i);
                expected++;
            }
        }

        private LinkedListPlay TargetMaker()
        {
            return new LinkedListPlay();
        }
    }
}