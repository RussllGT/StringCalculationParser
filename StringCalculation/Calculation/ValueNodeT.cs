namespace StringCalculation.Calculation
{
    public class ValueNode<T> : ValueNode
    {
        public T Value => (T)_value;
        public ValueNode(T value) : base(value) { }
    }
}