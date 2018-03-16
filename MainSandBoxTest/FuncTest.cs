using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class FuncTest
    {
        [TestMethod]
        public void Function_Test_for_methods_that_takes_a_Func_parameter()
        {
            var myFunc = new MyFunction();

            myFunc.Process("Hello World", s => s.ToUpper());

            Assert.AreEqual("HELLO WORLD", myFunc.Name);
        }
    }
}