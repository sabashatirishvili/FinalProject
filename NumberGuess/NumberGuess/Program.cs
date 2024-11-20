namespace NumberGuess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a range");
            Console.WriteLine("From:");
            var fromCheck = int.TryParse(Console.ReadLine(), out int from);
            Console.WriteLine("To:");
            var toCheck = int.TryParse(Console.ReadLine(), out int to);

            Random rnd = new Random();
            int random = rnd.Next(from, to);

            if (fromCheck && toCheck) {
                int tries = 0;
                while (true)
                {
                    Console.WriteLine("Enter a guess:");
                    var guessCheck = int.TryParse(Console.ReadLine(), out int guess);

                    if (guess < from || guess > to)
                    {
                        Console.WriteLine("Out of range");
                        break;
                    }

                    if (guessCheck) {
                        if (guess == random)
                        {
                            Console.WriteLine("Correct!");
                            Console.WriteLine($"Tries: {tries}");
                            break;
                        } else if (guess < random)
                        {
                            Console.WriteLine("Higher");
                            tries++;
                        } else if (guess > random)
                        {
                            Console.WriteLine("Lower");
                            tries++;
                        }
                    } else
                    {
                        Console.WriteLine("Invalid Number");
                    }
                }
            } else
            {
                Console.WriteLine("Invalid Numbers");
            }

        }
    }
}
