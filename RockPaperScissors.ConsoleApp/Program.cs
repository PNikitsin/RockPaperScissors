using RockPaperScissors.Library;
using RockPaperScissors.Library.Generators;

namespace RockPaperScissors.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = ["rock", "paper", "scissors", "lizard", "spock"];
            }

            if (!IsOddOrEmpty(args) || !IsDistinct(args))
                return;

            bool end = false;

            while (!end)
            {
                var hashGenerator = new HashGenerator();
                var aiTurn = new Random().Next(args.Length);
                var hmacKey = hashGenerator.GenerateKey();
                var hmac = hashGenerator.CheckValue(args[aiTurn], hmacKey);
                var table = new TableGenerator(args);

                Console.WriteLine("HMAC: " + hmac + "\n");
                Console.WriteLine("Available moves:");

                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine(i + 1 + " - " + args[i]);
                }

                Console.WriteLine("0 - exit");
                Console.WriteLine("? - help");
                Console.Write("Enter your move: ");

                var userTurn = Console.ReadLine();

                switch (userTurn)
                {
                    case "0":
                        end = true;
                        continue;
                    case "?":
                        table.PrintTable();
                        continue;
                }

                if (!int.TryParse(userTurn, out int userTurnInt) || userTurnInt < 1 || userTurnInt > args.Length)
                {
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine("Your move: " + args[userTurnInt - 1]);
                Console.WriteLine("Computer move: " + args[aiTurn]);

                var resultCalculator = new ResultCalculator(args.Length);
                var result = resultCalculator.CalculateResult(aiTurn, userTurnInt - 1);

                Console.WriteLine(result);


                Console.WriteLine("HMAC key: " + hmacKey + "\n");
                Console.WriteLine("Press any key to play again");

                Console.ReadKey();

                Console.Clear();
            }
        }

        static bool IsDistinct(string[] args)
        {
            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Error. Data must not be repeated.");
                return false;
            }

            return true;
        }

        static bool IsOddOrEmpty(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Not enough parameters!");
                return false;
            }

            if (args.Length % 2 == 0)
            {
                Console.WriteLine("There must be an odd number of parameters!");
                return false;
            }

            return true;
        }
    }
}