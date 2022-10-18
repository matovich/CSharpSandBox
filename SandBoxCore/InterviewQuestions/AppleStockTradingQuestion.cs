using System.Diagnostics;

/* 
Writing programming interview questions hasn't made me rich yet ... so I might give up and start trading Apple stocks all day instead.
First, I wanna know how much money I could have made yesterday if I'd been trading Apple stocks all day.

So I grabbed Apple's stock prices from yesterday and put them in an array called stockPrices, where:

The indices are the time (in minutes) past trade opening time, which was 9:30am local time.
The values are the price (in US dollars) of one share of Apple stock at that time.
So if the stock cost $500 at 10:30am, that means stockPrices[60] = 500.

Write an efficient method that takes stockPrices and returns the best profit I could have made from one purchase and one sale of one share of Apple stock yesterday.

For example:

  int[] stockPrices = { 10, 7, 5, 8, 11, 9 };

// Returns 6 (buying for $5 and selling for $11)
GetMaxProfit(stockPrices);

C#
No "shorting"—you need to buy before you can sell. Also, you can't buy and sell in the same time step—at least 1 minute has to pass.

*/

namespace SandBoxCore.InterviewQuestions
{
    public class AppleStockTradingQuestion
    {
        private List<int> stock_prices = new List<int>();

        public AppleStockTradingQuestion()
        {
            var random = new Random();
            for (int i = 0; i < 130; i++)
            {
                stock_prices.Add(random.Next(1, 113));
            }
        }

        public void Run()
        {
            var gain = FirstTry();

            Console.WriteLine($"Best Gain is {gain}");

            var gain2 = Better();

            Console.WriteLine($"Best Gain is {gain2}");
            Console.WriteLine(string.Join(" ", stock_prices));

            FirstTry();
            Better();
            FirstTry();
            Better();
        }

        private int FirstTry()
        {
            var sw = Stopwatch.StartNew();
            int bestGain = 0;

            for (int i = 0; i < stock_prices.Count; i++)
            {
                var max = stock_prices.GetRange(i, stock_prices.Count - i).Max();
                var calculatedGain = max - stock_prices[i];
                if (bestGain < calculatedGain)
                {
                    bestGain = calculatedGain;
                }
            }

            sw.Stop();
            Console.WriteLine($"First try stop watch {sw.Elapsed}");
            return bestGain;
        }

        private int Better()
        {
            var sw = Stopwatch.StartNew();
            var low = int.MaxValue;
            var gain = 0;

            foreach(var currentPrice in stock_prices)
            {
                low = Math.Min(low, currentPrice);
                gain = Math.Max(gain, currentPrice - low);
            }

            sw.Stop();
            Console.WriteLine($"Better stop watch {sw.Elapsed}");

            return gain;
        }
    }
}
