namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word:");
            var word = Console.ReadLine();
            int mistakes = 0;
            string unguessed = new string('-', word.Length);


            while (mistakes <= word.Length && unguessed.Contains("-")) {
                {
                    Console.WriteLine(unguessed);
                    var guessCheck = char.TryParse(Console.ReadLine(), out char guess);

                    if (guessCheck)
                    {
                        if (word.Contains(guess))
                        {
                            char[] unguessedArray = unguessed.ToCharArray();

                            for (int i = 0; i < word.Length; i++)
                            {
                                if (word[i] == guess)
                                {
                                    unguessedArray[i] = guess; // Reveal the guessed letter
                                }
                            }

                            unguessed = new string(unguessedArray);
                        } else
                        {
                            Console.WriteLine("Incorrect");
                            mistakes++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
            }

            if (!unguessed.Contains("-"))
            {
                Console.WriteLine("Guessed!");
                Console.WriteLine(word);
                Console.WriteLine($"Mistakes: {mistakes}");
            }

        }
    }
}
