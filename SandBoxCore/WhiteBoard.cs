using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBoxCore
{
    public class WhiteBoard
    {
        public void Run()
        {
            int[] input = { 1, 3, 4, 1, 6 };


            var result = solution(input);

            if(result != 2)
            {
                throw new Exception("Sorry");
            }

            Console.WriteLine(result);
        }


        public int solution(int[] A)
        {
            for (int i = 1; i < int.MaxValue; i++)
            {
                if (!A.Contains(i))
                    return i;
            }

            return 1;



            //var sorted = new List<int>(A).OrderBy(x => x).ToList();

            //var startIndex = sorted.FindIndex(x => x == 1);

            //var v1 = 0;

            //for (int i = startIndex; i < A.Length - startIndex; i++)
            //{
            //    if (sorted[1] == v1 + 1) { v1 = sorted[i]; }
            //    else
            //    {
            //        return v1;
            //    }

            //}


            //return 1;

        }


    }
}