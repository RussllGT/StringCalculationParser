using StringCalculation._ver4.Calculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.General
{
    public class ArgumentsContainer
    {
        private readonly Dictionary<string, ArgumentNode4> _arguments = new Dictionary<string, ArgumentNode4>();
        public ArgumentNode4 this[string name] => GetInstance(name);

        internal ArgumentsContainer() { }

        public bool Add(string name)
        { 
            if (Contains(name)) return false;
            _arguments.Add(name, new ArgumentNode4(name));
            return true;
        }

        public void AddRange(IEnumerable<string> names)
        {
            foreach (string name in names) Add(name); 
        }

        public bool Contains(string name) => _arguments.ContainsKey(name);

        public string[] GetNames() => _arguments.Keys.ToArray();

        private ArgumentNode4 GetInstance(string name)
        {
            if (!Contains(name)) throw new ArgumentException($"Аргумент \"{name}\" не зарегистрирован");
            return _arguments[name];
        }
    }
}