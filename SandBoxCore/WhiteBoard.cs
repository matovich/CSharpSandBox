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
            string time = "12:01:00am";
            
            Console.WriteLine($"{DateTime.Parse(time).ToString("HH:mm:ss")}");


            PlusMinus(new List<int> { -4, 3, -9, 0, 4, 1 });
        }

        private void PlusMinus(List<int> arr)
        {
            double pos = 0;
            double neg = 0;
            double zero = 0;

            foreach (var v in arr)
            {
                switch (v)
                {
                    case > 0:
                        pos++;
                        break;
                    case < 0:
                        neg++;
                        break;
                    default:
                        zero++;
                        break;
                }
            }

            var posPercent = pos / arr.Count;
            var negPercent = neg / arr.Count;
            var zeroPercent = zero / arr.Count;

            Console.WriteLine(string.Format("{0:0.000000}", posPercent));
            Console.WriteLine(string.Format("{0:0.000000}", negPercent));
            Console.WriteLine(string.Format("{0:0.000000}", zeroPercent));

        }

    }
}