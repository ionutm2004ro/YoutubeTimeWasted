using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Format:
[optional line "WATCHED"]
Video time in [hh:m]m:ss
[optional line #2 "...Sx • Ey..."]
Video name
User
views
time posted
empty line
[optional line "yesterday/last week"]
empty line
     */

namespace YoutubeTimeWasted
{
    class youtubeTimeFromFile
    {
        public void run()
        {
            Dictionary<String, TimeSpan> dict =  new Dictionary<String, TimeSpan>();
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"C:\Users\USER\Desktop\day13month5.txt", Encoding.Default, true);
            String timeLine,userLine;
            int lineCount = 0;
            while ((timeLine = file.ReadLine()) != null)
            {
                lineCount++;
                if (timeLine == "WATCHED") {
                    timeLine = file.ReadLine();
                    lineCount++;
                }
                

                //format time
                if (timeLine.Length == 4)
                {
                    timeLine = "00:0" + timeLine;
                }
                else if (timeLine.Length == 5) {
                    timeLine = "00:" + timeLine;
                }

                userLine = file.ReadLine();//video name
                lineCount++;
                if (userLine.Contains('•')) {//is part of a season
                    userLine = file.ReadLine();//video name
                    lineCount++;
                }
                userLine = file.ReadLine();//user name
                lineCount++;

                //init user time
                if (!dict.ContainsKey(userLine)) {
                    dict[userLine]=TimeSpan.Parse("00:00:00");
                }
                //add video time to user name
                try
                {
                    dict[userLine] = dict[userLine].Add(TimeSpan.Parse(timeLine));
                }
                catch (Exception e) {
                    Console.WriteLine("line "+lineCount.ToString()+ ": "+ timeLine + userLine);
                    throw e;
                }

                //junk lines
                timeLine = file.ReadLine();//views
                lineCount++;
                timeLine = file.ReadLine();//time posted
                lineCount++;
                try
                {
                    timeLine = file.ReadLine();//empty line
                    lineCount++;
                    timeLine = file.ReadLine();//possibly empty line
                    lineCount++;
                    if (timeLine != "")
                    {
                        timeLine = file.ReadLine();
                        lineCount++;
                    }
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception e) { }
#pragma warning restore CS0168 // Variable is declared but never used
            }

            file.Close();
            TimeSpan total = TimeSpan.Parse("00:00:00");
            //foreach (KeyValuePair<string, TimeSpan> entry in dict)
            foreach (KeyValuePair<string, TimeSpan> entry in dict.OrderBy(key => key.Value))
            {
                // do something with entry.Value or entry.Key
                Console.WriteLine("{0,30}{1,30}",entry.Key + ":" ,entry.Value.ToString());
                total = total.Add(entry.Value);
            }
            Console.WriteLine("{0,30}{1,30}","Total: ",total.ToString());

        }
    }
}
