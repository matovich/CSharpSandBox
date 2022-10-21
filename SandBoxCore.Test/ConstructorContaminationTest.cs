using NUnit.Framework;

namespace SandBox.Test
{
    [TestFixture]
    public class ConstructorContaminationTest
    {
        private readonly ConstructorContamination _target;

        public ConstructorContaminationTest()
        {
            _target = new ConstructorContamination();
        }

        [Test]
        public void OnlyAIsSetTrue()
        {
            _target.PropA = true;

            Assert.IsTrue(_target.PropA);
            Assert.IsFalse(_target.PropB);
        }

        [Test]
        public void OnlyBIsSetTrue()
        {
            _target.PropB = true;

            Assert.IsTrue(_target.PropB);
            Assert.IsFalse(_target.PropA);
        }
    }
}