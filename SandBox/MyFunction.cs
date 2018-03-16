using System;

namespace SandBox
{
    public class MyFunction
    {
        public string Name { get; set; }

        public void Process(string s, Func<string, string> func)
        {
            Name = func(s);
        }
    }
}