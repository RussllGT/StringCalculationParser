using StringCalculation._ver2.Nodes.Arguments;

namespace StringCalculation._ver2
{
    public interface IValueRequest
    {
        ValueNode2 GetValue(string variable);
    }
}