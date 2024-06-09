using ConsoleTables;

namespace RockPaperScissors.Library.Generators
{
    public class TableGenerator
    {
        public List<string> Cells = [];

        public TableGenerator(string[] cells)
        {
            Cells.AddRange(cells);
        }

        public void PrintTable()
        {
            Cells.Insert(0, "PC \\ User");

            var table = new ConsoleTable(Cells.ToArray());
            var resultCalculator = new ResultCalculator(Cells.Count - 1);

            for (int i = 0; i < Cells.Count - 1; i++)
            {
                var currentRow = new string[Cells.Count];
                currentRow[0] = Cells[i + 1];

                for (int j = 0; j < Cells.Count - 1; j++)
                {
                    currentRow[j + 1] = Enum.GetName(typeof(Result), resultCalculator.CalculateResult(i, j)) ?? string.Empty;
                }

                table.AddRow(currentRow.ToArray());
            }

            table.Write(Format.Alternative);
        }
    }
}