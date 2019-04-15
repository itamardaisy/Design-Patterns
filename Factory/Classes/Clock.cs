using Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Classes
{
    public class Clock : IClock
    {
        private string _timeZone;

        public Clock(string timeZone)
        {
            _timeZone = timeZone;
        }

        public string TimeZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler ClockTicker;

        public TimeSpan ClockTickNow()
        {
            var info = TimeZoneInfo.FindSystemTimeZoneById(this._timeZone);
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(localServerTime, info);
            return localTime.TimeOfDay;
        }
    }
}
