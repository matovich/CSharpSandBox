using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class IntMathTest
    {
        private IntMath _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new IntMath();
        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var result = _target.GetHundreds( 599 );
        //    Assert.AreEqual( 5, result );
        //}

        //[TestMethod]
        //public void  IsEvenHundredsReturnsTrueFor697()
        //{
        //    var result = _target.IsEvenHundreds( 697 );
        //    Assert.IsTrue( result );

        //}

        //[TestMethod]
        //public void IsEvenHundredsReturnsFalseFor397()
        //{
        //    var result = _target.IsEvenHundreds( 397 );
        //    Assert.IsFalse( result );
        //}
    }
}