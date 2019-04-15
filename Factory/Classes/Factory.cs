using Factory.Interfaces;
using Factory.Permanents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Classes
{
    public class Factory : IFactory
    {
        private List<Clock> _clocks;

        public Factory()
        {
            _clocks = new List<Clock>();
            _clocks.Add(new Clock("Israel Standard Time"));
            _clocks.Add(new Clock("New-york Standard Time"));
            _clocks.Add(new Clock("Tokyo Standard Time"));
        }

        public IClock GetClock(string timeZone)
        {
            switch (timeZone)
            {
                case TimeZones.ISRAEL:
                    return _clocks.Find(x => x.TimeZone == "Israel Standard Time");
                case TimeZones.NEW_YORK:
                    return _clocks.Find(x => x.TimeZone == "New-york Standard Time");
                case TimeZones.TOKYO:
                    return _clocks.Find(x => x.TimeZone == "Tokyo Standard Time");
                default:
                    return null;
            }
        }
    }
}
