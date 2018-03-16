using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class RunningAssemblyFinderTest
    {
        private readonly Func<RunningAssemblyFinder> _target = () => new RunningAssemblyFinder();

        [TestMethod]
        public void ProcessFinder_finds_a_process()
        {
            var target = new RunningAssemblyFinder();

            Assert.IsTrue(target.IsRunning("devenv"));
        }

        /// <summary>  </summary>
        [TestMethod, Owner("Paul"), TestCategory("Unit"), TestCategory("Proven")]
        public void ProcessFinder_returns_false_if_assembly_is_not_running()
        {
            Assert.IsFalse(_target().IsRunning("Blablabla"));
        }

        /// <summary>  </summary>
        [TestMethod, Owner("Paul"), TestCategory("Unit"), TestCategory("Proven")]
        public void AssemblyFinder_gets_id_of_running_assembly()
        {
            RunningAssemblyFinder target = _target();

            Trace.WriteLine(String.Format("Visual Studio Process Id is: {0}", target.GetId("devenv")));
        }
    }
}