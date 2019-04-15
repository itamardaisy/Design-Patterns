using Proxy.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            UIManager _uIManager = new UIManager();
            while (true)
            {
                Console.Write("===>  ");
                _uIManager.CommandParser(Console.ReadLine());
            }
        }
    }
}
