using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxCore.DesignPatterns.CreationalPatterns
{
    /// <summary>
    /// Creation Pattern.
    /// </summary>
    public class Singleton
    {
        /// <summary>
        /// From Jon Skeet   https://csharpindepth.com/Articles/Singleton
        /// </summary>
        private static readonly Lazy<Singleton> lazySingleton = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance { get { return lazySingleton.Value; } }

        private Singleton() { }

        public void SayHello()
        {
            Console.WriteLine("Hello from Singleton");
        }

    }
}
