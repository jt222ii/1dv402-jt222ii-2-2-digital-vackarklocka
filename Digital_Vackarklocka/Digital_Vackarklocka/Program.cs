using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Vackarklocka
{
    class Program
    {
        private static string HorizontalLine = "\n|=================================================================|";
        static void Main(string[] args)
        {

            AlarmClock test1 = new AlarmClock();                       //test 1 kollar standardkonstruktorn så att det blir 0:00
            ViewTestHeader("\n Test 1 \nTest av standardkonstruktorn.");
            Console.WriteLine(test1.ToString());

            AlarmClock test2 = new AlarmClock(9, 42);                   //test två kollar konstruktorn så att det blir 9:42 - eftersom vi skickat med 9 och 42
            ViewTestHeader("\n Test 2 \nTest av konstruktorn med två parametrar (9, 42)");
            Console.WriteLine(test2.ToString());

            AlarmClock test3 = new AlarmClock(13, 24, 7, 35);           //test 3 kollar så att konstruktorn även kan ta emot värden för alarmet (med de värden vi skickar med ska det bli 13:24 <7:35>)
            ViewTestHeader("\n Test 3 \nTest av konstruktorn med fyra parametrar, (13, 24, 7, 35)");
            Console.WriteLine(test3.ToString());

            AlarmClock test4 = new AlarmClock(23, 58, 7, 35);           //test 4 skickar med värden och sätter klockan till 23:58 och alarmet till 7:35. 
            ViewTestHeader("\n Test 4 \nStäller befintligt AlarmClock-objekt till 23:58 och låter den gå 13 'minuter' ");
            Run(test4, 13);                                             //Kör sedan Run-metoden som loopar igenom så många gånger vi skickar med att den ska göra. I detta fallet 13 ggr                                                                                         

            AlarmClock test5 = new AlarmClock(6, 12, 6, 15);            //test 5 gör som 4 fast låter klockan gå endast 6 minuter och förbi en tid då "larmet" är ställt - programmet ska då skriva ut alarmet.
            ViewTestHeader("\n Test 5 \nStäller befintligt AlarmClock-objekt till 6:12 och låter den gå 6 'minuter' ");
            Run(test5, 6);

            AlarmClock test6 = new AlarmClock(); //testar klockans timmar och minuter och alarmets timmar och minuter. Jag tilldelar värden som kommer ge fel för att se att så att ArgumentException kastas
            ViewTestHeader("\n Test 6 \nTestar egenskaperna så att undantag kastas då tid och alarmtid \ntilldelas felaktiga värden.");
            try
            { test6.Hour = 24; }                   
            catch (ArgumentException wrong)
            { ViewErrorMessage(wrong.Message); }
            try
            { test6.Minute = 60; }
            catch (ArgumentException wrong)
            { ViewErrorMessage(wrong.Message); }
            try
            { test6.AlarmHour = 25; }
            catch (ArgumentException wrong)
            { ViewErrorMessage(wrong.Message); }
            try
            { test6.AlarmMinute = 60; }
            catch (ArgumentException wrong)
            { ViewErrorMessage(wrong.Message); }

            
            ViewTestHeader("\n Test 7 \nTestar konstruktorer så att undantag kastas då tid och alarmtid \ntilldelas felaktiga värden."); // samma test som ovan fast genom konstruktorer som sedan skickar värdena till egenskaperna som på sin tur kommer kasta undantag.
            try
            { AlarmClock test7 = new AlarmClock(24, 0); }
            catch (ArgumentException wrong)
            { ViewErrorMessage(wrong.Message); }
            try
            { AlarmClock test7 = new AlarmClock(0, 60); }
            catch (ArgumentException wrong)
            { ViewErrorMessage(wrong.Message); }
            try
            { AlarmClock test7 = new AlarmClock(0, 0, 24, 0); }
            catch (ArgumentException wrong)
            { ViewErrorMessage(wrong.Message); }
            try
            { AlarmClock test7 = new AlarmClock(0, 0, 0, 60); }
            catch (ArgumentException wrong)
            { ViewErrorMessage(wrong.Message); }
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
                    Console.WriteLine("Beeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeep!");
                }
                else
                {
                    Console.Write(" ");
                    Console.WriteLine(test.ToString());
                }
                Console.ResetColor();
            }
        }
        private static void ViewErrorMessage(string message)        //skriver ut error-meddelandet som från början kom från AlarmClock.cs
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void ViewTestHeader(string header)  //Skriver ut vilket test som körs samt linjen som avskiljer dem
        {
            Console.WriteLine(HorizontalLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(header);
            Console.ResetColor();
        }

    }
}
