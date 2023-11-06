using StringCalculation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleForCalculation
{
    internal class Program
    {
        private const string INVITATION_EXPRESSION = "Enter the expression:";
        private const string INVITATION_ARGUMENT = "Enter argument ";
        private const string BAD_ARGUMENT = "Incorrect argument";

        private const string RESULT = "Result";
        private const string QUIT = "quit";
        private const string END_MESSAGE = "Program end";

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine(INVITATION_EXPRESSION);

                    string expression = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(expression) || QUIT.Equals(expression.ToLower())) throw new CancelationException(END_MESSAGE);

                    CalculationTree tree = CalculationTree.Create(expression, Enumerable.Empty<char>());

                    List<double> variables = new List<double>();
                    for (int i = 0; i < tree.Dimensions; ++i) variables.Add(GetArgument(i + 1));

                    Console.WriteLine($"{RESULT}: {tree.Calculate(variables)}");
                }
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

        static double GetArgument(int index)
        {
            while (true)
            {
                Console.WriteLine($"{INVITATION_ARGUMENT}{index}:");
                string value = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(value) || QUIT.Equals(value.ToLower())) throw new CancelationException(END_MESSAGE);

                if (double.TryParse(value, out var result)) return result;
                Console.WriteLine($"{BAD_ARGUMENT}{index}:");
            }
        }
    }
}