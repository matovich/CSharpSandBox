using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class TimeSpanPlayTest
    {
        private readonly Func<TimeSpanPlay> _targetMaker = () => new TimeSpanPlay();

        [TestMethod]
        public void GetFiveSeconds_returns_5000_milliseconds()
        {
            TimeSpanPlay target = _targetMaker();
            Assert.AreEqual(5000, target.Get5000Milliseconds());
        }
    }
}