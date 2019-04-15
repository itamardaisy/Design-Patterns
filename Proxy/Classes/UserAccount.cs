using Proxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Classes
{
    public class UserAccount : IUserAccount
    {
        private int _accountNumber;
        private string _name;
        private double _moneyInAccount;

        public UserAccount(int accountNumber, double moneyInAccount, string name)
        {
            _name = name;
            _accountNumber = accountNumber;
            _moneyInAccount = moneyInAccount;
        }

        public string Name
        {
            get => _name;
        }

        public int AccountNumber
        {
            get { return this._accountNumber; }
        }

        public double MoneyInAcount
        {
            get
            {
                return _moneyInAccount;
            }
            set
            {
                _moneyInAccount = value;
            }
        }

        public void InsertMoney(double amount)
        {
            _moneyInAccount += amount;
        }

        public double TakeMoney(double amount)
        {
            _moneyInAccount -= amount;
            return amount;
        }
    }
}
