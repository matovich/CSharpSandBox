using System.Collections.Generic;
using System.Linq;

namespace SandBoxCore
{
    public class LinkedListPlay

    {
        public LinkedListPlay()
        {
            TheLinkedList = new LinkedList<int>();
        }

        public LinkedList<int> TheLinkedList { get; set; }

        public void AddFiveElements()
        {
            for (int i = 0; i < 10; i += 2)
                TheLinkedList.AddLast(i);
        }

        public void InsertBetween()
        {
            for (int i = 0; i < TheLinkedList.Count; i++)
            {
                int valueToAdd = i + 1;
                if (TheLinkedList.ElementAt(i) % 2 == 0)
                    TheLinkedList.AddAfter(TheLinkedList.Find(i), valueToAdd);
            }

            // Foreach doesn't allow changing the list while stepping 
            //foreach (int i in TheLinkedList)
            //{
            //    TheLinkedList.AddAfter(TheLinkedList.Find(i), 7);
            //}
        }
    }
}