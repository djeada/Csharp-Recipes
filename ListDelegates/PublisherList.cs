using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDelegates
{
    /* ======================= Event Publisher =============================== */
    // Our subject -- it is this class that other classes   
    // will observe. This class publishes one event:   
    // SecondChange. The observers subscribe to that event.public
    class PublisherList : ArrayList
    {
        public delegate void ChangeHandler(object myList, ListEventArgs listChange);

        public event ChangeHandler change;

        public void OnSthHappened(ListEventArgs e) {
            if (change != null)
                change(this, e);
        }

        override public int Add(object value)
        {
            ListEventArgs ev = new ListEventArgs(this, DateTime.Now);
            OnSthHappened(ev);
            return base.Add(value);
        }
        override public void Clear()
        {
     
            ListEventArgs ev = new ListEventArgs(this, DateTime.Now);
            OnSthHappened(ev);
            base.Clear();
        }

        override public object this[int i]
        {
            get {
                return base[i];
            }
            set {
                ListEventArgs ev = new ListEventArgs(this, DateTime.Now);
                OnSthHappened(ev);
                base[i] = value;
            }
        }
    }
}
