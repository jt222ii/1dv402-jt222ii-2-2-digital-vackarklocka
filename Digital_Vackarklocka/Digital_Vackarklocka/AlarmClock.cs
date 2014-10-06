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

        public int AlarmHour
        {
            get { return _alarmHour; }
            set
            {
                if (value < 0 || value > 23)
                { throw new ArgumentException("Talet är inte inom det rätta intervallet 0-23"); }
                _alarmHour = value;
            }
        }
        public int AlarmMinute
        {
            get { return _alarmMinute; }
            set
            {
                if (value < 0 || value > 59)
                { throw new ArgumentException("Talet är inte inom det rätta intervallet 0-59"); }
                _alarmMinute = value;
            }
        }
        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value < 0 || value > 23)
                { 
                    throw new ArgumentException("Talet är inte inom det rätta intervallet 0-23"); 
                }
                _hour = value; 
            }
        }
        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 0 || value > 59)
                { throw new ArgumentException("Talet är inte inom det rätta intervallet 0-59"); }
                _minute = value;
            }
        }

        //metoder här
        public AlarmClock(): this(0,0)
        {
            // "Ingen tilldelning får ske i konstruktorns kropp, som måste vara tom."
            //"Denna konstruktor måste därför anropa den konstruktor i klassen som har två parametrar." - uppgiften
        }
        public AlarmClock(int hour, int minute):this (hour,minute,0,0)
        {

        }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        }
        public bool TickTock()
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
        public string ToString()
        {
            StringBuilder time = new StringBuilder();
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

            return time.ToString();
        }
    }
}
