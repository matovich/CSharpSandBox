using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class NullBullPlayTest
    {
        [TestMethod]
        [DeploymentItem("MainSandBox.dll")]
        public void NullBullPlayConstructorTest()
        {
            var target = new NullBullPlay();

            Assert.IsTrue(target.LoadBool());
        }
    }
}