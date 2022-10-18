using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxCore.DesignPatterns.StructuralPatterns
{
    public class DecoratorPattern
    {
        public void Run()
        {
            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            Console.WriteLine($"Only called DoSomething() on ConcreteDecoratorB{Environment.NewLine}");
            // Operation is only called on d2
            d2.DoSomething();

            // Wait for user
            Console.ReadKey();
        }
    }


    public abstract class Component
    {
        public abstract void DoSomething();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    public class ConcreteComponent : Component
    {
        public override void DoSomething()
        {
            Console.WriteLine($"ConcreteComponent.DoSomething() executed{Environment.NewLine}");
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    public abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void DoSomething()
        {
            if (component != null)
            {
                component.DoSomething();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorA' class
    /// </summary>
    public class ConcreteDecoratorA : Decorator
    {
        public override void DoSomething()
        {
            base.DoSomething();
            Console.WriteLine($"ConcreteDecoratorA.DoSomething() executed{Environment.NewLine}");
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorB' class
    /// </summary>
    public class ConcreteDecoratorB : Decorator
    {
        public override void DoSomething()
        {
            base.DoSomething();
            AddedBehavior();
            Console.WriteLine($"ConcreteDecoratorB.DoSomething() executed{Environment.NewLine}");
        }
        void AddedBehavior()
        {
            Console.WriteLine($"ConcreteDecoratorB.AddedBehavior() executed{Environment.NewLine}");
        }
    }
}
