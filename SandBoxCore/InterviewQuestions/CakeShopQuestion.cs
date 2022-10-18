using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
My cake shop is so popular, I'm adding some tables and hiring wait staff so folks can have a cute sit-down cake-eating experience.

I have two registers: one for take-out orders, and the other for the other folks eating inside the cafe. All the customer orders get combined into one list for the kitchen, where they should be handled first-come, first-served.

Recently, some customers have been complaining that people who placed orders after them are getting their food first. Yikes—that's not good for business!

To investigate their claims, one afternoon I sat behind the registers with my laptop and recorded:

The take-out orders as they were entered into the system and given to the kitchen. (takeOutOrders)
The dine-in orders as they were entered into the system and given to the kitchen. (dineInOrders)
Each customer order (from either register) as it was finished by the kitchen. (servedOrders)
Given all three arrays, write a method to check that my service is first-come, first-served. All food should come out in the same order customers requested it.

We'll represent each customer order as a unique integer.

As an example,

  Take Out Orders: [1, 3, 5]
  Dine In Orders: [2, 4, 6]
  Served Orders: [1, 2, 4, 6, 5, 3]
would not be first-come, first-served, since order 3 was requested before order 5 but order 5 was served first.

But,

  Take Out Orders: [17, 8, 24]
  Dine In Orders: [12, 19, 2]
  Served Orders: [17, 8, 12, 19, 24, 2]
would be first-come, first-served.
 */


namespace SandBoxCore.InterviewQuestions
{
    public class CakeShopQuestion
    {
        private List<int> TakeOut;
        private List<int> DineIn;
        private List<int> Served;


        public CakeShopQuestion()
        {
            //LoadNotServedInOrder();
            LoadServedInOrder();
        }

        private void LoadServedInOrder()
        {
            TakeOut = new List<int> { 17, 8, 24, 9};
            DineIn = new List<int> { 12, 19, 2 };
            Served = new List<int> { 17, 8, 12, 19, 24, 2 };
        }

        private void LoadNotServedInOrder()
        {
            TakeOut = new List<int> { 1, 3, 5 };
            DineIn = new List<int> { 2, 4, 6 };
            Served = new List<int> { 1, 2, 4, 6, 5, 3 };
        }

        public void Run()
        {
            IndexTrackSolution();
        }

        public void IndexTrackSolution()
        {
            var takeOutIndex = 0;
            var dineInIndex = 0;

            bool notServedInOrder = false;

            foreach (var order in Served)
            {
                if(takeOutIndex < TakeOut.Count && TakeOut[takeOutIndex] == order)
                {
                    takeOutIndex++;
                    continue;
                }
                if(dineInIndex < DineIn.Count && DineIn[dineInIndex] == order)
                {
                    dineInIndex++;
                    continue;
                }
                notServedInOrder = true;
                break;
            }

            if(takeOutIndex != TakeOut.Count || dineInIndex != DineIn.Count)
            {
                Console.WriteLine("The last orders were not served.");
            }

            ReportResult(notServedInOrder);
        }

        /// <summary>
        /// This uses extra memory space for the queues assuming we were not able to initially store the data in a queue.
        /// </summary>
        public void QueueSolution()
        {
            var takeOutQueue = new Queue<int>();
            var dineInQueue = new Queue<int>();

            TakeOut.ForEach(i => takeOutQueue.Enqueue(i));
            DineIn.ForEach(i => dineInQueue.Enqueue(i));

            bool notServedInOrder = false;


            foreach (var order in Served)
            {
                if (takeOutQueue.Count > 0 && takeOutQueue.Peek() == order)
                {
                    takeOutQueue.Dequeue();
                    continue;
                }
                if (dineInQueue.Count > 0 && dineInQueue.Peek() == order)
                {
                    dineInQueue.Dequeue();
                    continue;
                }

                notServedInOrder = true;
                break;
            }

            ReportResult(notServedInOrder);
        }

        public void ReportResult(bool notServedInOrder)
        {
            if (notServedInOrder)
            {
                Console.WriteLine("Not served in order");
            }
            else
            {
                Console.WriteLine("Server in order");
            }
        }
    }
}
