using System;
using SandBoxCore;
using SandBoxCore.InterviewQuestions;

namespace ConsoleRunner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new RxNet().Run();
            Console.WriteLine("Observable Started");

            Console.ReadLine();
        }
    }
}
