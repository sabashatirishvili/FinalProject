﻿using System.IO;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ATM");
            var filepath = Path.Combine(folderPath, "balance.txt");
            if (!File.Exists(filepath) ) {
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write)) {
                    using (StreamWriter sw = new StreamWriter(fs)) {
                        sw.WriteLine(0);
                    }
                };
            }

            

            while (true)
            {
                Console.WriteLine("Enter an operation (check, deposit, withdraw, transfer):");
                var operation = Console.ReadLine();

                switch (operation)
                {
                    case "check":
                        CheckBalance(filepath);
                        break;
                    case "deposit":
                        Deposit(filepath);
                        break;
                    case "withdraw":
                        Withdraw(filepath);
                        break;
                    case "transfer":
                        Console.WriteLine("Recipient:");
                        var name = Console.ReadLine();
                        Console.WriteLine("Enter an amount:");
                        var amountCheck = double.TryParse(Console.ReadLine(), out var amount);
                        Transfer(filepath, name, amount);
                        break;
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            
        }

        static void CheckBalance(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) 
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine("Balance: ");
                    Console.WriteLine("$" + sr.ReadToEnd());
                    
                }
            }
        }

        static void Deposit(string path)
        {
            Console.WriteLine("Enter an amount");
            var amountCheck = double.TryParse(Console.ReadLine(), out double amount);

            if (amountCheck) 
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        var content = sr.ReadToEnd();
                        double currentBalance = double.Parse(content);

                        currentBalance += amount;

                        fs.SetLength(0);

                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(currentBalance);
                            Console.WriteLine($"${amount} deposited, Current Balance: ${currentBalance}, Press Enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
            } else
            {
                Console.WriteLine("Invalid Input)");
            }
        }

        static void Withdraw(string path)
        {
            Console.WriteLine("Enter an amount");
            var amountCheck = double.TryParse(Console.ReadLine(), out double amount);

            if (amountCheck)
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        var content = sr.ReadToEnd();
                        double currentBalance = double.Parse(content);

                        currentBalance -= amount;

                        fs.SetLength(0);

                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(currentBalance);
                            Console.WriteLine($"${amount} withdrew, Current Balance: ${currentBalance}, Press Enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
            } else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        static void Transfer (string path, string name, double amount)
        {
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ATM");
            var filepath = Path.Combine(folderPath, name + ".txt");

            if (!File.Exists(filepath))
            {
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("0");
                    }
                }
            }

            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var content = sr.ReadToEnd().Replace(" ", "");
                    double currentBalance = double.Parse(content);

                    currentBalance += amount;

                    fs.SetLength(0);

                    using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        using (StreamReader reader = new StreamReader(fstream))
                        {
                            var tempBalance = reader.ReadToEnd().Replace(" ", "");
                            double balance = double.Parse(tempBalance);

                            balance -= amount;


                            using (StreamWriter writer = new StreamWriter(fstream))
                            {
                                writer.WriteLine(balance);
                            }
                        }
                    }

                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(currentBalance);
                        Console.WriteLine($"Deposit completed. New Balance: {currentBalance}");
                    }
                }
            }

        }

    }

}
