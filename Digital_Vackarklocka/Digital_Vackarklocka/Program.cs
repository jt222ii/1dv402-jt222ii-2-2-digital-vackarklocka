using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Vackarklocka
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock test1 = new AlarmClock();
            Console.WriteLine(test1.ToString());

            AlarmClock test2 = new AlarmClock(9, 42);
            Console.WriteLine(test2.ToString());

            AlarmClock test3 = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(test3.ToString());

            AlarmClock test4 = new AlarmClock(23, 58, 7, 35);
            ViewTestHeader("\n Test 4 \nStäller AlarmClock-objektet till 23:58 och låter den gå 13 'minuter' ");
            Run(test4, 13);
        }
        private static void Run(AlarmClock test, int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                if (test.TickTock())
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("♫");
                    Console.Write(test.ToString());
                    Console.WriteLine("beeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeep");
                }
                else
                {
                    Console.Write(" ");
                    Console.WriteLine(test.ToString()); 
                }
                Console.ResetColor();
            }
        }
        private static void ViewErrorMessage(string message)
        {

        }
        private static void ViewTestHeader(string header)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(header);
            Console.ResetColor();
        }

    }
}
