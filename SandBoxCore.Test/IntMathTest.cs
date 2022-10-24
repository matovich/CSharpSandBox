using NUnit.Framework;

namespace SandBoxCore.Test
{
    [TestFixture]
    public class IntMathTest
    {
        private IntMath _target;

        [SetUp]
        public void Setup()
        {
            _target = new IntMath();
        }

        [Test]
        public void TestMethod1()
        {
            var result = _target.GetHundreds(599);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void IsEvenHundredsReturnsTrueFor697()
        {
            var result = _target.IsEvenHundreds(697);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEvenHundredsReturnsTrueFor5697()
        {
            var result = _target.IsEvenHundreds(5697);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEvenHundredsReturnsFalseFor397()
        {
            var result = _target.IsEvenHundreds(397);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsEvenHundredsReturnsFalseFor2397()
        {
            var result = _target.IsEvenHundreds(2397);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsEvenHundredsReturnsTrueFor97_Because0IsEven()
        {
            var result = _target.IsEvenHundreds(97);
            Assert.IsTrue(result);
        }
    }
}