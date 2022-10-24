using System;
using NUnit.Framework;

namespace SandBoxCore.Test
{
    [TestFixture]
    public class TimeSpanPlayTest
    {
        private readonly Func<TimeSpanPlay> _targetMaker = () => new TimeSpanPlay();

        [Test]
        public void GetFiveSeconds_returns_5000_milliseconds()
        {
            TimeSpanPlay target = _targetMaker();
            Assert.AreEqual(5000, target.Get5000Milliseconds());
        }
    }
}