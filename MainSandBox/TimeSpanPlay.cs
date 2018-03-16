using System;

namespace SandBox
{
    public class TimeSpanPlay
    {
        public int Get5000Milliseconds()
        {
            //TimeSpan ts = new TimeSpan(0, 0, 5);
            //return (int)ts.TotalMilliseconds;

            return (int) TimeSpan.FromSeconds(5).TotalMilliseconds;
        }
    }
}