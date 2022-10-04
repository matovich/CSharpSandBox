using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class IntMathTest
    {
        private IntMath _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new IntMath();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var result = _target.GetHundreds(599);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void IsEvenHundredsReturnsTrueFor697()
        {
            var result = _target.IsEvenHundreds(697);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEvenHundredsReturnsTrueFor5697()
        {
            var result = _target.IsEvenHundreds(5697);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEvenHundredsReturnsFalseFor397()
        {
            var result = _target.IsEvenHundreds(397);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEvenHundredsReturnsFalseFor2397()
        {
            var result = _target.IsEvenHundreds(2397);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEvenHundredsReturnsTrueFor97_Because0IsEven()
        {
            var result = _target.IsEvenHundreds(97);
            Assert.IsTrue(result);
        }
    }
}