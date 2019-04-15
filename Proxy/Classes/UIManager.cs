using Proxy.Interfaces;
using Proxy.Permanents;
using Proxy.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Classes
{
    public class UIManager
    {
        private IATMMachine _atmMachine;

        public UIManager()
        {
            _atmMachine = Proxy<ATMMachine>.As<IATMMachine>();
        }

        public void CommandParser(string command)
        {
            switch (command.Split(' ')[0])
            {
                case UICommands.INSERT_CARD:
                    TakeCardNumberFromUser(command.Split(' ')[1]);
                    break;
                case UICommands.INSERT_MONEY:
                    TakeNumberFromUser(command.Split(' ')[1]);
                    break;
                case UICommands.TAKE_MONEY:
                    TakeNumberFromUser(command.Split(' ')[1]);
                    break;
                case UICommands.MONEY_IN_ACCOUNT:
                    ShowUserMoney();
                    break;
                case UICommands.LOGOUT:
                    Logout();
                    break;
            }
        }

        private void ShowUserMoney()
        {
            Console.WriteLine(_atmMachine.ShowMoney());
        }

        private void Logout()
        {
            Console.WriteLine($"Good bye {_atmMachine.CurrentUser().Name}");
            _atmMachine.Logout();
            Console.WriteLine("\nWelcome to ATM machine!");
        }

        private void TakeCardNumberFromUser(string cardNumberFromUser)
        {
            if (_atmMachine.InsertCard(cardNumberFromUser))
            {
                Console.WriteLine($"Welcome {_atmMachine.CurrentUser().Name}!");
            }
            else
            {
                Console.WriteLine("Please insert a valid number");
            }
        }

        private void TakeNumberFromUser(string amountFromUser)
        {
            double amount = default(double);
            double.TryParse(amountFromUser, out amount);
            if (amount != default(double))
            {
                _atmMachine.InsertMoney(amount);
            }
            else
            {
                Console.WriteLine("Please insert a valid number");
            }
        }
    }
}
