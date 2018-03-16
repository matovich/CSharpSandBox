using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class PasswordEncodingTest
    {
        private readonly PasswordEncoding _target = new PasswordEncoding();

        [TestMethod]
        public void EncodesPassword()
        {
            string result = _target.EncodePw("cpn", "GEhc246*");
            Assert.AreEqual("Y3BuOkdFaGMyNDYq", result);
        }

        [TestMethod]
        public void EncodesPassword2()
        {
            string result = _target.EncodePw("", "");
            Assert.AreEqual("Og==", result);
        }

        [TestMethod]
        public void EncodesPassword3()
        {
            string result = _target.EncodePw("ReallyLongUserName", "ReallyLongPassword");
            Assert.AreEqual("UmVhbGx5TG9uZ1VzZXJOYW1lOlJlYWxseUxvbmdQYXNzd29yZA==", result);
        }

        [TestMethod]
        public void Encode()
        {
            string result = _target.Encode(string.Empty);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Encode2()
        {
            string result = _target.Encode("P");
            Assert.AreEqual("UA==", result);
        }

        [TestMethod]
        public void Encode3()
        {
            string result = _target.Encode("A");
            Assert.AreEqual("QQ==", result);
        }

        [TestMethod]
        public void Encode4()
        {
            string result = _target.Encode("PA");
            Assert.AreEqual("UEE=", result);
        }

        [TestMethod]
        public void UnEncode()
        {
            string result = _target.UnEncode("UEE=");
            Assert.AreEqual("PA", result);
        }

        [TestMethod]
        public void UnEncode2()
        {
            string result = _target.UnEncode("UmVhbGx5TG9uZ1VzZXJOYW1lOlJlYWxseUxvbmdQYXNzd29yZA==");
            Assert.AreEqual("ReallyLongUserName:ReallyLongPassword", result);
        }

        [TestMethod]
        public void UnEncode3()
        {
            string result = _target.UnEncode("Y3BuOkdFaGMyNDYq"); //Y3BuOkdFaGMyNDYq
            Assert.AreEqual("cpn:GEhc246*", result);
        }
    }
}