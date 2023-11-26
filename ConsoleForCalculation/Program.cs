using ConsoleForCalculation;
using ConsoleForCalculation.Double;
using StringCalculation;
using StringCalculation._ver4.Calculation.Nodes;
using StringCalculation._ver4.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ConsoleForCalculation
{
    internal class Program
    {
        private const string INVITATION_EXPRESSION = "Enter the expression:";
        private const string INVITATION_ARGUMENT = "Enter argument ";
        //private const string BAD_ARGUMENT = "Incorrect argument";

        private const string RESULT = "Result";
        private const string QUIT = "quit";
        private const string END_MESSAGE = "Program end";

        static void Main(string[] args)
        {
            try
            {
                while (true) Run();
            }
            catch (CancelationException ce)
            {
                Console.WriteLine(ce.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        static void Run()
        {
            Console.WriteLine(INVITATION_EXPRESSION);

            string expression = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(expression) || QUIT.Equals(expression.ToLower())) throw new CancelationException(END_MESSAGE);

            ExpressionManager manager = ExpressionManager.Instance;
            manager.Functions.Add("+", typeof(AdditionNode));
            manager.Functions.Add("-", typeof(SubstractionNode));
            manager.Functions.Add("*", typeof(MultiplyNode));
            manager.Functions.Add("/", typeof(DivisionNode));
            manager.Functions.Add("Pow", typeof(PowerNode));

            CalculationTree4 tree = manager.CreateTree(expression, new string[] { });

            Dictionary<string, string> arguments = new Dictionary<string, string>();
            foreach (string name in tree.Arguments)
            {
                arguments.Add(name, GetArgument(name));
            }

            ValueNode4 value = tree.Calculate(arguments);
            if (value is  ValueNode4<double> dValue) Console.WriteLine($"{RESULT}: {dValue.Value}");
            else throw new ArgumentException($"Некорректный результат");
        }

        static string GetArgument(string name)
        {
            Console.WriteLine($"{INVITATION_ARGUMENT} \"{name}\":");
            string result = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(result) || QUIT.Equals(result.ToLower())) throw new CancelationException(END_MESSAGE);

            return result;
        }
    }
}

//static void Main(string[] args)
//{
//    try
//    {
//        while (true)
//        {
//            Console.WriteLine(INVITATION_EXPRESSION);

//            string expression = Console.ReadLine();
//            if (string.IsNullOrWhiteSpace(expression) || QUIT.Equals(expression.ToLower())) throw new CancelationException(END_MESSAGE);

//            CalculationTree tree = CalculationTree.Create(expression, Enumerable.Empty<char>());

//            List<double> variables = new List<double>();
//            for (int i = 0; i < tree.Dimensions; ++i) variables.Add(GetArgument(i + 1));

//            Console.WriteLine($"{RESULT}: {tree.Calculate(variables)}");
//        }
//    }
//    catch (CancelationException ce)
//    {
//        Console.WriteLine(ce.Message);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.ToString());
//    }
//    finally
//    {
//        Console.ReadLine();
//    }
//}

//static double GetArgument(int index)
//{
//    while (true)
//    {
//        Console.WriteLine($"{INVITATION_ARGUMENT}{index}:");
//        string value = Console.ReadLine();
//        if (string.IsNullOrWhiteSpace(value) || QUIT.Equals(value.ToLower())) throw new CancelationException(END_MESSAGE);

//        if (double.TryParse(value, out var result)) return result;
//        Console.WriteLine($"{BAD_ARGUMENT}{index}:");
//    }
//}