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
        public AlarmClock()
            : this(0, 0) //anropar konstruktorn med 2 parameterfält 
        {
            // "Ingen tilldelning får ske i konstruktorns kropp, som måste vara tom."
            //"Denna konstruktor måste därför anropa den konstruktor i klassen som har två parametrar." - uppgiften
        }
        public AlarmClock(int hour, int minute)
            : this(hour, minute, 0, 0)//anropar konstruktorn med 4 parameterfält                                                                       
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
        public bool TickTock() //Bool som returnerar true eller false. Kollar om antal minuter är mindre än 59 minuter. Stämmer det så ökar den antal minuter med ett.
        // annars sätter den minuter till 0 och kollar om timmen är mindre än 23. Stämmer det så ökar timmens värde med ett. Annars sätts det till 0.
        {
            if (Minute < 59)
            { Minute++; }
            else
            {
                Minute = 0;
                if (Hour < 23)
                { Hour++; }
                else
                { Hour = 0; }
            }
            return (Hour == AlarmHour && Minute == AlarmMinute);

        }
        public override string ToString()  //skriver ut klockslaget och inställd alarmtid. Override för att det redan finns en "ToString()" i "Object" och jag säger då att jag inte vill använda mig av den utan den jag skapar här.
        {
            string time = string.Format("{0}:{1:00} <{2:00}:{3:00}>", _hour, _minute, _alarmHour, _alarmMinute); //string.format blev smidigare - betydligt mindre kod. 

            //StringBuilder time = new StringBuilder();       //stringbuilder kan lägga till text och istället för att man skickar tillbaka ett nytt objekt kan man returnera samma objekt med modifierade värden
            //time.AppendFormat("{0,4}:", _hour);
            //if(_minute<10)
            //{ 
            //    time.AppendFormat("0{0}", _minute); 
            //}
            //else
            //{ 
            //    time.AppendFormat("{0}", _minute);
            //}
            //time.AppendFormat("<{0}:", _alarmHour);
            //if(_alarmMinute<10)
            //{ 
            //    time.AppendFormat("0{0}>", _alarmMinute);       //AppendFormat fungerar som så att använda string format fast för append istället. 
            //}                                                  //Ex) "time.AppendFormat("0{0}", _minute);  " hade skrivits "time.Append("0"); time.Append(_minute);" för att få samma resultat som utan Format
            //else                                              //returnerar StringBuilder objektet som har fått sitt värde av time.AppendFormat
            //{
            //    time.AppendFormat("{0}>", _alarmMinute);
            //}
            return time.ToString();
        }
    }
}
