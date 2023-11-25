using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver2.Nodes.Arguments
{
    public class VariableNode2 : BaseNode2
    {
        private readonly string _name;

        private VariableValuesContainer _container;

        public VariableNode2(string name) { _name = name; }

        public void RegisterContainer(VariableValuesContainer container)
        {
            if (_container is null) _container = container;
            else throw new ArgumentNullException("Переменная уже привязана");
        }

        public override BaseNode2 Calculate() => _container[_name];
    }
}
