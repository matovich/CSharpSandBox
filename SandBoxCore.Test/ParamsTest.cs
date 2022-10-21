using NUnit.Framework;
namespace SandBox.Test
{
    [TestFixture]
    public class ParamsTest
    {
        [Test]
        public void Concatenate_joins_strings()
        {
            var target = new Params();
            string result = target.Concatenate(0, "a", "b", "c");
            Assert.AreEqual("abc0", result);
        }
    }
}