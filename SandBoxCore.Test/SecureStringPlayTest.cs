using System.Collections.Generic;
using System.Linq;
using System.Security;
using NUnit.Framework;

namespace SandBox.Test
{
    [TestFixture]
    public class SecureStringPlayTest
    {
        private readonly SecureStringPlay _target = new SecureStringPlay();

        [Test]
        public void GetPassword()
        {
            string result = _target.GetPassword();
            Assert.AreEqual("password0", result);
        }

        [Test]
        public void GetPasswordCharacterArray()
        {
            IEnumerable<char> result = _target.GetCharacterArray();
            Assert.AreEqual(10, result.Count());
        }

        [Test]
        public void GetPasswordHandlesEmptySecureString()
        {
            string result = _target.GetPassword(new SecureString());
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetCharacterArray()
        {
            IEnumerable<char> result = _target.GetCharacterArray();
            Assert.AreEqual(10, result.Count());
        }

        [Test]
        public void GetCharacterArrayWithCorrectCharacters()
        {
            IEnumerable<char> result = _target.GetCharacterArray();
            Assert.AreEqual('p', result.ElementAt(0));
            Assert.AreEqual('a', result.ElementAt(1));
            Assert.AreEqual('s', result.ElementAt(2));
            Assert.AreEqual('s', result.ElementAt(3));
            Assert.AreEqual('w', result.ElementAt(4));
            Assert.AreEqual('o', result.ElementAt(5));
            Assert.AreEqual('r', result.ElementAt(6));
            Assert.AreEqual('d', result.ElementAt(7));
            Assert.AreEqual('0', result.ElementAt(8));
        }
    }
}