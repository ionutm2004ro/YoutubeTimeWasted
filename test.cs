using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeTimeWasted
{
    class test
    {
        public void run() {
            TimeSpan t1 = TimeSpan.Parse("1:00:00");
            TimeSpan t2 = TimeSpan.Parse("10:40:00");
            TimeSpan t3 = t1.Add(t2);
            Console.WriteLine(t3);
        }
    }
}
