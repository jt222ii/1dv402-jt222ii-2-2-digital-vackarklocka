using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Vackarklocka
{
    class AlarmClock
    {
        private int _alarmHour;
        private int _alarmMinute;
        private int _hour;
        private int _minute;

        //Get är för att läsa ett värde. Set är för att ändra ett värde. 
        //EX) När Program.cs behöver värdet på _alarmHour så används get. 
        //    Men när program.cs skickar in värden så används set.
        public int AlarmHour  // Alarmets timmar. Se ovan för förklaring av get set
        {
            get { return _alarmHour; }
            set
            {
                if (value < 0 || value > 23)
                { throw new ArgumentException("alarmets timmar är inte inom det rätta intervallet 0-23"); }
                _alarmHour = value;
            }
        }
        public int AlarmMinute  // Alarmets minuter. Se ovan för förklaring av get set
        {
            get { return _alarmMinute; } 
            set
            {
                if (value < 0 || value > 59)
                { throw new ArgumentException("alarmets minuter är inte inom det rätta intervallet 0-59"); }
                _alarmMinute = value;
            }
        }
        public int Hour // Klockans timmar. Se ovan för förklaring av get set
        {
            get { return _hour; }
            set
            {
                if (value < 0 || value > 23)
                { 
                    throw new ArgumentException("klockans timmar är inte inom det rätta intervallet 0-23"); 
                }
                _hour = value; 
            }
        }
        public int Minute   // Klockans minuter. Se ovan för förklaring av get set
        {
            get { return _minute; }
            set
            {
                if (value < 0 || value > 59)
                { throw new ArgumentException("klockans minuter är inte inom det rätta intervallet 0-59"); }
                _minute = value;
            }
        }

        
        //konstruktorerna ser till att objekten blir korrekt initierade
        public AlarmClock(): this(0,0) //anropar konstruktorn med 2 parameterfält 
        {
            // "Ingen tilldelning får ske i konstruktorns kropp, som måste vara tom."
            //"Denna konstruktor måste därför anropa den konstruktor i klassen som har två parametrar." - uppgiften
        }
        public AlarmClock(int hour, int minute):this (hour,minute,0,0)//anropar konstruktorn med 4 parameterfält                                                                       
        {                                                           
            //Ingen tilldelning får ske i konstruktorns kropp, som måste vara tom. Denna konstruktor måste därför anropa den 
            //konstruktor i klassen som har fyra parametrar.
        }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute) //tilldelar värden till objekten och skickar tillbaka dem via de andra två konstruktorerna
        {
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        }
        public bool TickTock() //varje gång ticktock anropas ökas minuten med 1. Om antal minuter överstiger 59 sätts minuter till 0 och our får +1. Hour testas då om det är mer än 23. 
                               // stämmer det sätts timtalet till 0. Sedan testas det om timmen och minuten stämmer med alarmets timme och minut. 
        {
            _minute++;
            if (_minute>59)
            { _hour++; _minute = 0; }
            if(_hour>23)
            { Hour = 0; }
            if (_hour == _alarmHour && _minute == _alarmMinute)
            { return true; }
            else
                return false;
        }
        public string ToString()  //skriver ut klockslaget och inställd alarmtid
        {
            StringBuilder time = new StringBuilder();       //stringbuilder kan lägga till text och istället för att man skickar tillbaka ett nytt objekt kan man returnera samma objekt med modifierade värden
            time.AppendFormat("{0,4}:", _hour);
            if(_minute<10)
            { 
                time.AppendFormat("0{0}", _minute); 
            }
            else
            { 
                time.AppendFormat("{0}", _minute);
            }
            time.AppendFormat("<{0}:", _alarmHour);
            if(_alarmMinute<10)
            { 
                time.AppendFormat("0{0}>", _alarmMinute);
            }
            else
            {
                time.AppendFormat("{0}>", _alarmMinute);
            }
                                                             //AppendFormat fungerar som så att använda string format fast för append istället. 
                                                            //Ex) "time.AppendFormat("0{0}", _minute);  " hade skrivits "time.Append("0"); time.Append(_minute);" för att få samma resultat som utan Format
            return time.ToString();                        //returnerar StringBuilder objektet som har fått sitt värde av time.AppendFormat
        }
    }
}
