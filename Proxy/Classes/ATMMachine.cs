using Proxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Classes
{
    public class ATMMachine : IATMMachine
    {
        private IList<UserAccount> _users;

        private UserAccount _currentUser;

        public ATMMachine()
        {
            _users = new List<UserAccount>();
            _users.Add(new UserAccount(12345, 20000, "Itamar"));
            _users.Add(new UserAccount(23456, 20000, "Yoav"));
            _users.Add(new UserAccount(34567, 20000, "Ron"));
            _users.Add(new UserAccount(45678, 20000, "Ben"));
            _users.Add(new UserAccount(56789, 20000, "Maya"));
            _users.Add(new UserAccount(67890, 20000, "Holly"));
            _users.Add(new UserAccount(78901, 20000, "Izeek"));
            _users.Add(new UserAccount(89012, 20000, "David"));
            _currentUser = null;
        }

        public UserAccount CurrentUser()
        {
            if (_currentUser != null)
            {
                return _currentUser;
            }
            else
            {
                return null;
            }
        }

        public bool InsertCard(string cardNumber)
        {
            if (cardNumber.Length < 4)
            {
                return false;
            }
            else
            {
                int afterCastNumber = default(int);
                int.TryParse(cardNumber, out afterCastNumber);
                if (afterCastNumber is default(int) || afterCastNumber < 0)
                {
                    return false;
                }
                else
                {
                    var user = _users.First(x => x.AccountNumber == afterCastNumber);
                    if (user != null)
                    {
                        _currentUser = user;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool InsertMoney(double amount)
        {
            if (amount > 0)
            {
                _currentUser.InsertMoney(amount);
                return true;
            }
            else
            {
                return false;
            }
        }

        public double TakeMoney(double amount)
        {
            if (amount < _currentUser.MoneyInAcount)
            {
                return _currentUser.TakeMoney(amount);
            }
            else
            {
                return -1;
            }
        }

        public void Logout() => _currentUser = null;

        public string ShowMoney()
        {
            return $"Money in account: {_currentUser.MoneyInAcount}";
        }
    }
}
