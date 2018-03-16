using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class YieldTest
    {
        [TestMethod]
        public void YieldTestMethod()
        {
            var target = new YieldClass();
            Assert.AreEqual("Paul", target.GetThing().FirstOrDefault().Name);
            Assert.AreEqual(10, target.GetThing().Count());
        }

        [TestMethod]
        public void TestName()
        {
        }
    }
}