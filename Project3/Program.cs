using System;

namespace Project3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3 || (args.Length % 2) == 0)
            {
                Console.WriteLine("\nThe number of moves must be odd and more than 2");
                return;
            }

            for (int i = 0; i < args.Length - 1; i++)
            {
                if (Array.IndexOf(args, args[i], i + 1) > 0)
                {
                    Console.WriteLine("\nMoves should not be repeated");
                    return;
                }
            }

            Play(args);
        }

        static void Play(String[] steps)
        {
            int computerStep;
            Boolean flag = true;
            Random rnd = new Random();

            while (flag)
            {
                computerStep = rnd.Next(steps.Length);
                byte[] key = Key.GenerateKey();
                OutMenu(steps, computerStep, key);

                flag = inputChoice(steps, computerStep, key);
            }
        }

        static void OutMenu(String[] steps, int computerStep, byte[] key)
        {
            Console.WriteLine("\nHMAC: " + BitConverter.ToString(Hmac.GenerateHMAC(key, steps[computerStep])).Replace("-", string.Empty));

            Console.WriteLine("\nAvailable moves:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine(i + 1 + " - " + steps[i]);
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help\n");
            Console.Write("Enter you move: ");
        }

        static Boolean inputChoice(String[] steps, int computerStep, byte[] key)
        {
            String sChoice = Console.ReadLine();
            try
            {
                int choice = Convert.ToInt32(sChoice);

                if (choice == 0) return false;
                else if (choice > 0 && choice <= steps.Length) CorrectChoice(steps, computerStep, choice, key);
                else Console.WriteLine("Choose from the options presented.");
            }
            catch (FormatException)
            {
                if (sChoice == "?") Table.OutputTable(steps);
                else Console.WriteLine("Choose from the options presented.");
            }
            return true;
        }
        static void CorrectChoice(String[] steps, int computerStep, int choice, byte[] key)
        {
            Console.WriteLine("\nYou move: " + steps[choice - 1]);
            Console.WriteLine("Computer move: " + steps[computerStep]);
            int result = Winner.CheckWinner(choice - 1, computerStep, steps.Length / 2);

            if (result == 0) Console.WriteLine("It is draw.");
            else if (result == 1) Console.WriteLine("You win!");
            else Console.WriteLine("You lose.");

            Console.WriteLine("\nHMAC key: " + BitConverter.ToString(key).Replace("-", string.Empty));
        }
    }
}
