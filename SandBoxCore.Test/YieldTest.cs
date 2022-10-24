using System.Linq;
using NUnit.Framework;

namespace SandBoxCore.Test
{
    [TestFixture]
    public class YieldTest
    {
        [Test]
        public void YieldTestMethod()
        {
            var target = new YieldClass();
            Assert.AreEqual("Paul", target.GetThing().FirstOrDefault().Name);
            Assert.AreEqual(10, target.GetThing().Count());
        }

        [Test]
        public void TestName()
        {
        }
    }
}