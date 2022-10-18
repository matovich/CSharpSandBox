using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxCore.InterviewQuestions
{
    public class ReverseArray
    {
        private static object arr;

        public static List<int> reverseArray(List<int> a)
        {
            //var stack = new Stack<int>();

            //a.ForEach(x => stack.Push(x));
            
            //return stack.ToList<int>();

            return a.Reverse<int>().ToList();
        }
    }
}
