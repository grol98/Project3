using System;
using ConsoleTables;

namespace Project3
{
    public class Table
    {
        public static void OutputTable(string[] steps)
        {
            String[] header = new String[steps.Length + 1];

            header[0] = "PC|User";
            for (int i = 0; i < steps.Length; i++)
            {
                header[i + 1] = steps[i];
            }

            var table = new ConsoleTable(header);

            for (int i = 0; i < steps.Length; i++)
            {
                table.AddRow(CreateRow(i, steps));
            }

            table.Write();
            Console.WriteLine();
        }

        static String[] CreateRow(int n, String[] steps)
        {
            String[] s = new String[steps.Length + 1];
            s[0] = steps[n];

            for (int i = 0; i < steps.Length; i++)
            {
                int result = Winner.CheckWinner(i, n, steps.Length / 2);

                if (result == 1) s[i + 1] = "WIN";
                else if (result == 0) s[i + 1] = "DRAW";
                else s[i + 1] = "LOSE";
            }
            return s;
        }
    }
}
