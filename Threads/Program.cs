using System;
using System.Threading; 

namespace Threads
{
 
    class Program
    {
        static int GLOBAL_VALUE = 0;
        static readonly object locker = new object();
        public static void Increment(){
            try {
                int tmp;
                Console.WriteLine ("Hello from " + Thread.CurrentThread.Name);
                for(int i = 0; i < 10; i++){
                    lock (locker) {
                        tmp = GLOBAL_VALUE; 
                        tmp++;
                        Console.WriteLine(i);
                        GLOBAL_VALUE = tmp;
                     }
                    }
                Thread.Sleep(10);
            }
            catch (Exception ex){
                if(ex.InnerException is ThreadAbortException) {
                    Console.WriteLine("Thread " + Thread.CurrentThread.Name + " Aborted!"); 
                }
                else {
                   Console.WriteLine(ex.GetType());
                }
              }  
        }
        public static void Decrement(int max){
            try{
                int tmp; 
                Console.WriteLine ("Hello from " + Thread.CurrentThread.Name);
                for(int i = max; i >= 0; i--){
                     lock (locker) {
                        tmp = GLOBAL_VALUE; 
                        Console.WriteLine(i);
                        tmp--;
                        GLOBAL_VALUE = tmp;
                     }
                }
            }
            catch (Exception ex){
                 if(ex.InnerException is ThreadAbortException){                    
                    Console.WriteLine("Thread " + Thread.CurrentThread.Name + " Aborted!");
                }
                else {
                   Console.WriteLine(ex.GetType());
                }
              }  
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "main";
            Thread increment1 = new Thread(Increment); 
            increment1.Name = "increment1";
            Thread increment2 = new Thread (new ThreadStart (Increment));
            increment2.Name = "increment2";
            increment1.Start();
            increment2.Start();

            Thread decrement1 = new Thread ( () => Decrement (5) );
            decrement1.Name = "decrement1";
            decrement1.Start();

            Thread decrement2 = new Thread (delegate()
            {
                 Decrement (10);
            });
            decrement2.Name = "decrement2";
            decrement2.Start();

            //increment1.Abort();
            //decrement2.Abort();

            increment1.Join();
            increment2.Join();
            decrement1.Join();
            decrement2.Join();

            Console.WriteLine("GLOBAL:" + GLOBAL_VALUE);
            Console.WriteLine("Main thread at the end");
        }
    }
}
