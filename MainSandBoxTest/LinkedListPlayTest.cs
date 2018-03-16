using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class LinkedListPlayTest
    {
        [TestMethod]
        public void CreatesLinkedList()
        {
            LinkedListPlay target = TargetMaker();

            Assert.IsNotNull(target.TheLinkedList);
        }

        [TestMethod]
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

        [TestMethod]
        public void InsertMissingElementsWhileInForLoop()
        {
            LinkedListPlay target = TargetMaker();
            target.AddFiveElements();
            target.InsertBetween();

            Assert.AreEqual(10, target.TheLinkedList.Count);
        }

        [TestMethod]
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