using StringCalculation.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculation.General
{
    public class ArgumentsContainer
    {
        private readonly Dictionary<string, ArgumentNode> _arguments = new Dictionary<string, ArgumentNode>();
        public ArgumentNode this[string name] => GetInstance(name);

        internal ArgumentsContainer() { }

        public bool Add(string name)
        { 
            if (Contains(name)) return false;
            _arguments.Add(name, new ArgumentNode(name));
            return true;
        }

        public void AddRange(IEnumerable<string> names)
        {
            foreach (string name in names) Add(name); 
        }

        public bool Contains(string name) => _arguments.ContainsKey(name);

        public string[] GetNames() => _arguments.Keys.ToArray();

        private ArgumentNode GetInstance(string name)
        {
            if (!Contains(name)) throw new ArgumentException($"Аргумент \"{name}\" не зарегистрирован");
            return _arguments[name];
        }
    }
}