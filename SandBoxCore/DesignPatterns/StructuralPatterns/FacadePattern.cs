using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxCore.DesignPatterns.StructuralPatterns
{
    /// <summary>
    /// https://www.dofactory.com/net/facade-design-pattern
    /// </summary>
    public class FacadePattern
    {
        public void Run()
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// This may be the entrance to an assembly where the other sub system classes are internal to the assembly.
    /// </summary>
    public class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine($"{Environment.NewLine}MethodA() ---- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine($"{Environment.NewLine}MethodB() ---- ");
            two.MethodTwo();
            three.MethodThree();
        }
    }

    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    internal class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    internal class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }

    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    internal class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }

    /// <summary>
    /// The 'Subsystem ClassD' class
    /// </summary>
    internal class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }
}
