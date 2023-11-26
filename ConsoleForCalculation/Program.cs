using ConsoleForCalculation.Double;
using StringCalculation.Calculation;
using StringCalculation.General;
using System;
using System.Collections.Generic;

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
            manager.Functions.Add(new AdditionNode());
            manager.Functions.Add(new SubstractionNode());
            manager.Functions.Add(new MultiplyNode());
            manager.Functions.Add(new DivisionNode());
            manager.Functions.Add(new PowerNode());

            CalculationTree tree = manager.CreateTree(expression, new string[] { });

            while (IsArguments(tree, out Dictionary<string, string> arguments))
            {
                ValueNode value = tree.Calculate(arguments);
                if (value is ValueNode<double> dValue) Console.WriteLine($"{RESULT}: {dValue.Value}");
                else throw new ArgumentException($"Некорректный результат");
                if (arguments.Count == 0) break;
            }
            ExpressionManager.Instance = null;
        }

        static bool IsArguments(CalculationTree tree, out Dictionary<string, string> arguments)
        {
            arguments = new Dictionary<string, string>();
            try
            {
                foreach (string name in tree.Arguments)
                {
                    arguments.Add(name, GetArgument(name));
                }
            }
            catch (CancelationException)
            {
                Console.WriteLine("Ввод аргументов отменён");
                return false;
            }
            return true;
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