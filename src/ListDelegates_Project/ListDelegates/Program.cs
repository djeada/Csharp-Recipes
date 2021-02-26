using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new clock         
            PublisherList myList = new PublisherList();
            // Create the display and tell it to         
            // subscribe to the clock just created         
            DisplayChanges dc = new DisplayChanges();
            dc.Subscribe(myList);
            // Create a Log object and tell it         
            // to subscribe to the clock         
            SaveToFile sf = new SaveToFile();
            sf.Subscribe(myList);
            myList.Add(3);
            myList.Add(5);
            myList.Add(7);
            myList[1] = 9;
            Thread.Sleep(1000);
            myList.Clear();
            dc.unSubscribe(myList);
            sf.unSubscribe(myList);
            myList.Add(8);
            Console.ReadKey();
        }
    }
}
