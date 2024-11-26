
namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[]
            {
                "apple", "banana", "cherry", "dragonfruit", "elephant",
                "forest", "galaxy", "horizon", "iceberg", "jungle",
                "kitten", "lightning", "mountain", "nebula", "ocean",
                "planet", "quartz", "rainbow", "sunflower", "tiger",
                "umbrella", "volcano", "waterfall", "xylophone", "yacht",
                "zeppelin", "avocado", "bridge", "castle", "diamond"
            };
            Random rnd = new Random();
            var word = words[rnd.Next(31)];

            int mistakes = 0;
            const int maxMistakes = 7;
            string unguessed = new string('-', word.Length);

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine($"You have {maxMistakes} chances to guess the word.");

            while (mistakes < maxMistakes && unguessed.Contains("-"))
            {
                Console.WriteLine($"\nCurrent word: {unguessed}");
                Console.WriteLine($"Mistakes: {mistakes}/{maxMistakes}");
                Console.Write("Enter your guess: ");

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Invalid input! Please enter a single letter.");
                    continue;
                }

                char guess = char.ToLower(input[0]);

                if (word.Contains(guess))
                {
                    char[] unguessedArray = unguessed.ToCharArray();

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guess)
                        {
                            unguessedArray[i] = guess;
                        }
                    }

                    unguessed = new string(unguessedArray);
                    Console.WriteLine("Correct guess!");
                }
                else
                {
                    Console.WriteLine("Incorrect guess!");
                    mistakes++;
                }
            }

            if (!unguessed.Contains("-"))
            {
                Console.WriteLine($"\nCongratulations! You guessed the word: {word}");
                Console.WriteLine($"Total mistakes: {mistakes}");
            }
            else
            {
                Console.WriteLine("\nGame Over!");
                Console.WriteLine($"The correct word was: {word}");
            }

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
