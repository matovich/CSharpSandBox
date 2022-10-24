using NUnit.Framework;

namespace SandBoxCore.Test
{
    [TestFixture]
    public class NullBoolPlayTest
    {
        [Test]
        //[DeploymentItem("MainSandBox.dll")]
        public void NullBullPlayConstructorTest()
        {
            var target = new NullBoolPlay();

            Assert.IsTrue(target.LoadBool());
        }
    }
}