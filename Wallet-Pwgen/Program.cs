using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WalletPwgen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("WalletPwgen Password-Gen");
            Console.WriteLine("========================");
            Console.WriteLine("[1] Random PW-Gen");
            Console.WriteLine("[2 Exit\n");
            int selection = int.Parse(Console.ReadLine());

            if (selection == 1)
            {
                Console.WriteLine("\nEnter Password Length(min 15 Characters Suggested)");
                int length = int.Parse(Console.ReadLine());

                Console.WriteLine("\nInclude Uppercasee Letters? y/n");
                bool includeUppercase = Console.ReadLine().ToLower() == "y";

                Console.WriteLine("\nInclude Lowercase Letters? y/n");
                bool includeLowercase = Console.ReadLine().ToLower() == "y";

                Console.WriteLine("\nInclude Numbers? y/n");
                bool includeNumbers = Console.ReadLine().ToLower() == "y";

                Console.WriteLine("\nInclude Symbols? y/n");
                bool includeSymbols = Console.ReadLine().ToLower() == "y";

                Console.WriteLine("");
                Console.WriteLine("Generating Password...");
                Console.WriteLine("");

                string password = GeneratePassword(length, includeUppercase, includeLowercase, includeNumbers, includeSymbols);
                Console.WriteLine("Password: " + password);

                Console.ReadKey();
            }



            static string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSymbols)
            {
                const string UPPERCASE_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string LOWERCASE_LETTERS = "abcdefghijklmnopqrstuvwxyz";
                const string NUMBERS = "0123456789";
                const string SYMBOLS = "!@#$%^&*()-_=+[]{}|;':\",.<>/?\\";

                string characterSet = "";

                if (includeUppercase)
                {
                    characterSet += UPPERCASE_LETTERS;
                }
                
                if (includeLowercase)
                {
                    characterSet += LOWERCASE_LETTERS;
                }

                if (includeNumbers)
                {
                    characterSet += NUMBERS;
                }

                if (includeSymbols)
                {
                    characterSet += SYMBOLS;
                }

                StringBuilder password = new StringBuilder();
                Random random = new Random();

                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(characterSet.Length);
                    char character = characterSet[index];
                    password.Append(character);
                }

                return password.ToString();
            }

        }
    }
}