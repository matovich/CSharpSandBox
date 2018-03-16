using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class ParamsTest
    {
        [TestMethod]
        public void Concatenate_joins_strings()
        {
            var target = new Params();
            string result = target.Concatenate(0, "a", "b", "c");
            Assert.AreEqual("abc0", result);
        }
    }
}