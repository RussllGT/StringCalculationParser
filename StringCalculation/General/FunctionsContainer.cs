using StringCalculation.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation.General
{
    public class FunctionsContainer
    {
        private readonly Dictionary<string,Type> _functions = new Dictionary<string,Type>();
        public FunctionNode this[string name] => GetInstance(name);

        internal FunctionsContainer() { }

        public bool Add(FunctionNode node) => Add(node.Name, node.GetType());

        private bool Add(string name, Type type)
        {
            if (Contains(name)) return false;
            _functions.Add(name, type);
            return true;
        }

        public bool Contains(string name) => _functions.ContainsKey(name);

        private FunctionNode GetInstance(string name)
        {
            if (!Contains(name)) throw new ArgumentException($"Функция \"{name}\" не зарегистрирована");

            ConstructorInfo constructor = _functions[name].GetConstructor(new Type[] { });
            if (constructor.Invoke(new object[] { }) is FunctionNode result) return result;

            throw new ArgumentException($"Объект зарегистрированный под именем \"{name}\" не является функцией");
        }
    }
}