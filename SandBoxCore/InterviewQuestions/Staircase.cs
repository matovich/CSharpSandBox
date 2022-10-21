using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxCore.InterviewQuestions
{
    public class Staircase
    {
        public void Run()
        {
            int input = 6;

            for (int i = 1; i < input +1; i++)
            {
                var spaces = Enumerable.Repeat<string>(" ", input - i);
                var blocks = Enumerable.Repeat<string>("#", i);
                Console.Write(string.Join("", spaces));
                Console.WriteLine(string.Join("", blocks));
            }
        }
    }
}
