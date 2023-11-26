namespace StringCalculation.Calculation
{
    public abstract class ValueNode
    {
        protected object _value;
        public ValueNode(object value) { _value = value; }
    }
}