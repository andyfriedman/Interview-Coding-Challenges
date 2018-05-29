using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class Problems2
    {
        public static class Producer
        {
            public static event EventHandler Produce;
        }

        public class Consumer
        {
            public Consumer()
            {
                Producer.Produce += new EventHandler(Consume);
            }

            private void Consume(object sender, EventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("I'm consuming");
            }
        }

        private void DoWork()
        {
            // What is the problem with this code?
            //      Aside from the obvious that it doesn't do anything, the Consumer constructor
            //      creates a new instance of an event handler, which doesn't get properly
            //      released when the object is nullified. This results in memory not being
            //      reclaimed on GC.
            //
            //      One solution is to keep a local instance of the event handler and implement
            //      IDispose and decrement the handler from Producer on Dispose.
            for (int i = 0; i < 100; i++)
            {
                Consumer consumer = new Consumer();
                consumer = null;
            }

            GC.Collect();
            // How many consumers do we have?
            // Why?
            //      There will be 100 instances of consumers in memory, since they still hang on to event 
            //      handler references via the Consume method.
            //      
            //      The one solution above was to properly decrement the event handler instance count.
            //      Another "solution" is to change the Consume method to static. This will still 
            //      leave all the event handler instances in memory but the consumer instances will be released.
        }
    }
}
