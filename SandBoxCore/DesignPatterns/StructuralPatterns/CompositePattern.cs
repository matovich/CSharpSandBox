using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxCore.DesignPatterns.StructuralPatterns
{
    public class CompositePattern
    {
        public void Run()
        {
            // Create a tree structure
            var root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));
            var comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));
            root.Add(comp);

            // Add and remove a leaf
            Leaf leaf = new Leaf("Should not see this leaf");
            root.Add(leaf);
            root.Add(new Leaf("Leaf C"));
            root.Remove(leaf);

            leaf.Add(new Leaf("Should fail to add"));

            // Recursively display tree
            root.Display(1);

            // Wait for user
            Console.ReadKey();
        }
    }


    public abstract class CompositeComponent
    {
        protected string name;
        public CompositeComponent(string name)
        {
            this.name = name;
        }
        public abstract void Add(CompositeComponent c);
        public abstract void Remove(CompositeComponent c);
        public abstract void Display(int depth);
    }

    public class Composite : CompositeComponent
    {
        List<CompositeComponent> children = new();
        public Composite(string name) : base(name)
        {
        }
        public override void Add(CompositeComponent component)
        {
            children.Add(component);
        }
        public override void Remove(CompositeComponent component)
        {
            children.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            // Recursively display child nodes
            foreach (var component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    public class Leaf : CompositeComponent
    {
        public Leaf(string name)
            : base(name)
        {
        }
        public override void Add(CompositeComponent c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }
        public override void Remove(CompositeComponent c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}
