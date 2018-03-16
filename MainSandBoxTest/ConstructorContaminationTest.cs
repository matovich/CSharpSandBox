using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class ConstructorContaminationTest
    {
        private readonly ConstructorContamination _target;

        public ConstructorContaminationTest()
        {
            _target = new ConstructorContamination();
        }

        [TestMethod]
        public void OnlyAIsSetTrue()
        {
            _target.PropA = true;

            Assert.IsTrue(_target.PropA);
            Assert.IsFalse(_target.PropB);
        }

        [TestMethod]
        public void OnlyBIsSetTrue()
        {
            _target.PropB = true;

            Assert.IsTrue(_target.PropB);
            Assert.IsFalse(_target.PropA);
        }
    }
}