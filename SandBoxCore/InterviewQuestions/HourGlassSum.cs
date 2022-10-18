using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxCore.InterviewQuestions
{
    public class HourGlassSum
    {
        private List<List<int>> arr = new List<List<int>>();



        public HourGlassSum()
        {
            arr.Add(new List<int> { 1, 2, 3, 4, 5, 6 });
            arr.Add(new List<int> { 1, 2, 3, 4, 5, 6 });
            arr.Add(new List<int> { 1, 2, 3, 4, 5, 6 });
            arr.Add(new List<int> { 1, 2, 3, 4, 5, 6 });
            arr.Add(new List<int> { 1, 2, 3, 4, 5, 6 });
            arr.Add(new List<int> { 1, 2, 3, 4, 5, 6 });
        }

        public int Run()
        {
            var xStart = 0;
            var yStart = 0;
            var sum = int.MinValue;

            do
            {
                var result = arr[xStart][yStart] + arr[xStart][yStart + 1] + arr[xStart][yStart + 2] + arr[xStart + 1][yStart + 1] + arr[xStart + 2][yStart] + arr[xStart + 2][yStart + 1] + arr[xStart + 2][yStart + 2];

                sum = Math.Max(result, sum);
                
                xStart++;
                if (xStart == 4)
                {
                    xStart = 0;
                    yStart++;
                }
            } while (yStart != 4);

            Console.WriteLine($"sum {sum}");
            return sum;
        }

    }
}
