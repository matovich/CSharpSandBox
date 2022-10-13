using System.Linq;

namespace SandBoxCore
{
    public class InterviewQuestionOne
    {
        private List<int> stock_prices = new List<int>();

        public InterviewQuestionOne()
        {
            var random = new Random();

            for (int i = 0; i < 130; i++)
            {
                stock_prices.Add(random.Next(1, 113));
            }
        }

        public void Run()
        {
            int bestGain = 0;

            for (int i = 0; i < stock_prices.Count; i++)
            {
                var max = stock_prices.GetRange(i, stock_prices.Count - i).Max();
                var calculatedGain = max - stock_prices[i];
                if(bestGain < calculatedGain)
                {
                    bestGain = calculatedGain;
                }
            }

            Console.WriteLine($"Best Gain is {bestGain}");

            Console.WriteLine(String.Join(", ", stock_prices));
        }
    }
}
