﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace SandBoxCore.Test
{
    [TestFixture]
    public class LinqPlayTest
    {
        private readonly Func<LinqPlay> _targetMaker = () => new LinqPlay();

        [Test]
        public void Gets_a_list_of_numbers_as_strings()
        {
            LinqPlay target = _targetMaker();
            IEnumerable<string> result = target.GetLineNumberStrings();
            Assert.AreEqual(10, result.Count());

            // the linq ForEach may be deprecated in future versions
            // http://blogs.msdn.com/b/ericlippert/archive/2009/05/18/foreach-vs-foreach.aspx
            // http://social.msdn.microsoft.com/Forums/en-US/winappswithcsharp/thread/758f7b98-e3ce-41e5-82a2-109f1df446c2
            result.ToList().ForEach(s => Trace.WriteLine(s));
        }

        [Test]
        public void TimeUsingSkip()
        {
            var target = _targetMaker();

            var timer = new Stopwatch();

            timer.Start();
            target.UsingSkip().ToList();
            timer.Stop();

            Console.WriteLine("Skip Time {0}", timer.ElapsedTicks);
        }

        [Test]
        public void TimeUsingIndexer()
        {
            var target = _targetMaker();

            var timer = new Stopwatch();

            timer.Start();
            target.UsingIndexer().ToList();
            timer.Stop();

            Console.WriteLine("Indexer Time {0}", timer.ElapsedTicks);
        }



        [Test]
        public void TimeUsingArray()
        {
            var target = _targetMaker();

            var timer = new Stopwatch();

            timer.Start();
            target.UsingArray().ToList();
            timer.Stop();

            Console.WriteLine("Array Time {0}", timer.ElapsedTicks);
        }
        
        [Test]
        public void TimeUsingImprovedArray()
        {
            var target = _targetMaker();

            var timer = new Stopwatch();

            timer.Start();
            target.UsingImprovedArray().ToList();
            timer.Stop();

            Console.WriteLine("Improved Array Time {0}", timer.ElapsedTicks);
        }

        [Test]
        public void TimeUsingImprovedArrayWithToListGuard()
        {
            var target = _targetMaker();

            var timer = new Stopwatch();

            timer.Start();
            target.UsingImprovedArrayWithToListGuard().ToList();
            timer.Stop();

            Console.WriteLine("Improved Array with to list guard Time {0}", timer.ElapsedTicks);
        }

        [Test]
        public void TimeUsingElementAt()
        {
            var target = _targetMaker();

            var timer = new Stopwatch();

            timer.Start();
            target.UsingElementAt().ToList();
            timer.Stop();

            Console.WriteLine("ElementAt() time {0}", timer.ElapsedTicks);
        }
    }
}