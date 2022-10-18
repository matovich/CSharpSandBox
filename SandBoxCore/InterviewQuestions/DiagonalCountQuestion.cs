using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxCore.InterviewQuestions
{
    public class DiagonalCountQuestion
    {
        private List<List<int>> arr = new List<List<int>>();

        public DiagonalCountQuestion()
        {
            arr.Add(new List<int> { 11, 2, 4 });
            arr.Add(new List<int> { 4, 5, 6 });
            arr.Add(new List<int> { 10, 8, -12 });
        }


        public int Run()
        {
            var left = 0;
            var right = 0;
            var count = 0;
            var rightCount = arr.Count - 1;
            do
            {
                left += arr[count][rightCount - count];
                right += arr[count][count];
                count++;
            } while (count < arr.Count);

            Console.WriteLine($"Result Left: {left}, Right: {right}");

            return Math.Abs(left - right);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var input = nums.ToList<int>();
            int index1;
            int index2;
            for (int i = 0; i < target; i++)
            {
                index1 = input.IndexOf(i);
                index2 = input.FindIndex(index1 + 1, (r => r == target - i));
                if (index1 != -1 && index2 != -1 && index1 != index2)
                {
                    return new int[2] { index1, index2 };
                }

            }


            return null;
        }





    }
}
