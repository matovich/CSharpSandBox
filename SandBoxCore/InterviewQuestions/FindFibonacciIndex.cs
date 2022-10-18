using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBoxCore.InterviewQuestions
{
    public class FindFibonacciIndex
    {
        public void Run()
        {
            Console.WriteLine($"Result should be 5: {fibonacciV2(4)}");
        }
        static int fibonacciV2(int num)
        {
            if (num < 2) return 1;

            var lastvalue = 1;
            var secondlastvalue = 1;
            var newValue = 0;

            for (int i = 1; i < num; i++)
            {
                newValue = lastvalue + secondlastvalue;
                secondlastvalue = lastvalue;
                lastvalue = newValue;
            }

            return newValue;
        }


        static int fibonacci(int num)
        {
            var fib = new List<int>();

            fib.Add(1);
            fib.Add(1);
            var lastvalue = 1;
            var otherlastvalue = 1;

            for (int i = 0; i < num; i++)
            {
                var result = lastvalue + otherlastvalue;
                fib.Add(result);
                lastvalue = otherlastvalue;
                otherlastvalue = result;
            }

            return fib[num];

        }


    }
}