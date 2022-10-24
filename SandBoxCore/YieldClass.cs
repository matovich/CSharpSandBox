using System.Collections.Generic;

namespace SandBoxCore
{
    public class YieldClass
    {
        public IEnumerable<Thing> GetThing()
        {
            for (int i = 0; i < 10; i++)
                yield return new Thing {Name = "Paul"};
        }
    }

    public class Thing
    {
        public string Name { get; set; }
    }
}