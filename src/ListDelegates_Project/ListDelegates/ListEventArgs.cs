using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDelegates
{
    class ListEventArgs : EventArgs
    {
        public ListEventArgs(ArrayList myList, DateTime currentTime) {
            this.myList = myList;
            this.currentTime = currentTime;
        }
        public readonly ArrayList myList;
        public readonly DateTime currentTime;
        
    }
}
