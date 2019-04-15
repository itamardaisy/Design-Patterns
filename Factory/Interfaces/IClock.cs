using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Interfaces
{
    public interface IClock
    {
        string TimeZone { get; set; }

        TimeSpan ClockTickNow();

        event EventHandler ClockTicker;
    }
}
