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
            // 28, 8, 96, 2     NO
            // 
            // 0, 3, 4, 2  YES

            // 43, 2, 70, 2   NO

            Console.WriteLine($"{kangaroo(43, 2, 70, 2)}");
        }

        private void DoSomething()
        {


        }

        public static string kangaroo(int x1, int v1, int x2, int v2)
        { 
            if(v1 == v2 && x1 != x2)
            {
                return "NO";
            }

            if (x1 < x2 && v1 < v2)
            {
                return "NO";
            }

            if (x1 > x2 && v1 < v2)
            {
                var p1 = x1 + v1;
                var p2 = x2 + v2;

                do
                {
                    if (p1 == p2)
                    {
                        return "YES";
                    }
                    p1 = p1 + v1;
                    p2 = p2 + v2;
                } while (p1 >= p2);

                return "NO";
            }

            if (x1 < x2 && v1 > v2)
            {
                var p1 = x1 + v1;
                var p2 = x2 + v2;

                do
                {
                    if (p1 == p2)
                    {
                        return "YES";
                    }
                    p1 = p1 + v1;
                    p2 = p2 + v2;
                } while (p1 <= p2);

                return "NO";
            }

            if (x1 > x2 && v1 > v2)
            {
                return "NO";
            }

            return "YES";
        }

    }
}