using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeTimeWasted
{
    class Program
    {
        static void Main(string[] args)
        {
            youtubeTimeFromFile prg =  new youtubeTimeFromFile();
            //test prg = new test();
            prg.run();
            Console.ReadKey();
        }
    }
}
