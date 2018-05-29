using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public static class Problems4
    {
        // What does this code do? Why?
        //      It creates a list of action delegates and prints 100 100 times. This is because i is a 
        //      single instance and despite how the code may be interpreted, it's current value in the for 
        //      loop when the delegate is created doesn't remain that value, and by the time the delegates 
        //      are actually executed the value of the single instance of i is 100.
        //
        //      If the intended behavior is to have 0-99 printed out, we'd create a new local instance of the
        //      current value of i for each iteration and use that value instead:
        public static void DoWork()
        {
            List<Action> workItems = new List<Action>();
            for (int i = 0; i < 100; i++)
            {
                var n = i; // persist the value of i at its current iteration
                Action f = () => System.Diagnostics.Debug.WriteLine(n);
                workItems.Add(f);
            }

            foreach (var f in workItems)
            {
                f();
            }
        }
    }
}
