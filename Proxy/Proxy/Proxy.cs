using ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Proxy
{
    public class Proxy<T> : DynamicObject where T : class, new()
    {
        private readonly T _subject;

        private Dictionary<string, int> _methodCallCount;

        public Proxy(T subject)
        {
            _methodCallCount = new Dictionary<string, int>();
            _subject = subject;
        }

        public static I As<I>() where I : class
        {
            if (!typeof(I).IsInterface)
            {
                throw new ArgumentException("I must be an interface type!");
            }
            else
            {
                return new Proxy<T>(new T()).ActLike<I>();
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                // On logout the Proxy will print the usage of the method of the proxy.
                if (binder.Name == "Logout")
                {
                    Console.WriteLine(this.ToString());
                }
                if (_methodCallCount.ContainsKey(binder.Name))
                {
                    _methodCallCount[binder.Name]++;
                }
                else
                {
                    _methodCallCount.Add(binder.Name, 1);
                }
                result = _subject.GetType().GetMethod(binder.Name).Invoke(_subject, args);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The dictionary Methods invokation counter: ");
            foreach (var method in _methodCallCount)
            {
                sb.AppendLine($"{method.Key} ---> {method.Value}");
            }
            return sb.ToString();
        }
    }
}
