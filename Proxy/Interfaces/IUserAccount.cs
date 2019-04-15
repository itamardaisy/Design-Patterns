using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Interfaces
{
    public interface IUserAccount
    {
        int AccountNumber { get; }

        double MoneyInAcount { get; set; }

        double TakeMoney(double amount);

        void InsertMoney(double amount);
    }
}
