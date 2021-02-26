using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDelegates
{
    class DisplayChanges
    {
        public void Subscribe(PublisherList myList) {
            myList.change += new PublisherList.ChangeHandler(SomethingHasChanged);
        }
        public void unSubscribe(PublisherList myList)
        {
            myList.change -= new PublisherList.ChangeHandler(SomethingHasChanged);
        }
        // The method that implements the      
        // delegated functionality      
        public void SomethingHasChanged(
            object myList, ListEventArgs myEvent)      {
            Console.WriteLine("This is called when the event fires");
            Console.WriteLine("Event fired at: {0}", myEvent.currentTime);
            foreach (Object item in myEvent.myList)
            {
                Console.WriteLine("   {0}", item);
            }
        }
    }
}
