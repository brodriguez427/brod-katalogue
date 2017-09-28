using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a math problem. Use +, -, /, or *");
            string input = Console.ReadLine();
            string trimmedInput = input.Replace(" ", "");
            char[] formula = trimmedInput.ToCharArray();
            char symbol;
            double number1;
            double number2;
            double answer;
            symbol = formula[1];
            number1 = formula[0] - 48;
            number2 = formula[2] - 48;

            if (symbol == '*')
            {
                answer = number1 * number2;
                Console.Write(answer);
            }
            else if (symbol == '+')
            {
                answer = number1 + number2;
                Console.Write(answer);
            }
            else if (symbol == '-')
            {
                answer = number1 - number2;
                Console.Write(answer);
            }
            else if (symbol == '/')
            {
                answer = number1 / number2;

            }
            else
            {
                Console.WriteLine("Nope.");
            }

            Console.ReadLine();
            



        }
    }
}
