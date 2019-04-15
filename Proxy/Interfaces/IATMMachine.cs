using Proxy.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Interfaces
{
    public interface IATMMachine
    {
        double TakeMoney(double amount);

        bool InsertMoney(double amount);

        bool InsertCard(string v);

        UserAccount CurrentUser();

        string ShowMoney();

        void Logout();
    }
}
