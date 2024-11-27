namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double product = 0;
            bool firstRun = true;
            while (true)
            {
                Console.WriteLine("Enter a number:");
                var firstCheck = double.TryParse(Console.ReadLine(), out var num1);
                Console.WriteLine("Enter a second number:");
                var secondCheck = double.TryParse(Console.ReadLine(), out var num2);
                if (!firstRun)
                {
                    num1 = product;
                }
                Console.WriteLine("Enter an operation (0 to exit):");
                var operation = Console.ReadLine();

                if (firstCheck && secondCheck) {
                    if (operation == "0")
                    {
                        break;
                    }
                    switch (operation)
                    {
                        case "+":
                            product = Calculator.Add(num1, num2);
                            Console.WriteLine($"{num1} + {num2} = {Calculator.Add(num1, num2)}");
                            break;
                        case "-":
                            product = Calculator.Subtract(num1, num2);
                            Console.WriteLine($"{num1} - {num2} = {Calculator.Subtract(num1, num2)}");
                            break;
                        case "*":
                            product = Calculator.Multiply(num1, num2);
                            Console.WriteLine($"{num1} * {num2} = {Calculator.Multiply(num1, num2)}");
                            break;
                        case "/":
                            if (num2 == 0)
                            {
                                Console.WriteLine("Cannot divide by zero");
                            }
                            else
                            {
                                product = Calculator.Divide(num1, num2);
                                Console.WriteLine($"{num1} / {num2} = {Calculator.Divide(num1, num2)}");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Operation");
                            break;
                    }
                } else {
                    Console.WriteLine("Invalid Numbers");
                }
                Console.WriteLine("Continue operating on the product? (yes/no)");
                var response = Console.ReadLine();

                if (response != "yes")
                {
                    firstRun = true;
                }
                else
                {
                    firstRun = false; 
                }
            }
        }
    }

    public class Calculator
    {
        public static double Add(double x, double y) { 
            return x + y;
        }
        public static double Subtract(double x, double y)
        {
            return x - y;
        }
        public static double Multiply(double x, double y)
        {
            return x * y;
        }
        public static double Divide(double x, double y)
        {
            return x / y;
        }
    }
}
