using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDelegates
{
    class SaveToFile
    {
        public void Subscribe(PublisherList myList)
        {
            myList.change += new PublisherList.ChangeHandler(SomethingHasChanged);
        }
        public void unSubscribe(PublisherList myList)
        {
            myList.change -= new PublisherList.ChangeHandler(SomethingHasChanged);
        }
        // The method that implements the      
        // delegated functionality      
        public void SomethingHasChanged(
            object myList, ListEventArgs myEvent)
        {
            FileStream fileStream = new FileStream("file.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine("This is called when the event fires");
            streamWriter.WriteLine("Event fired at: {0}", myEvent.currentTime);
            foreach (Object item in myEvent.myList)
            {
                streamWriter.WriteLine("   {0}", item);
            }
            streamWriter.Flush();            
            streamWriter.Close();            
            fileStream.Close();
        }
    }
}
