namespace Task1;
internal class Program
{
	private static void Main(string[] args)
	{
		// Input
		Console.Write("How many rows? ");
		int rows = 0;
		Int32.TryParse(Console.ReadLine(), out rows);
		var matrix = new List<List<int>>();

		for (int i = 0; i < rows; i++)
		{
			string? line = Console.ReadLine();
			if (line != null)
			{
				string[] strNums = line.Split(' ');
				var nums = new List<int>();
				foreach (var sn in strNums)
				{
					if (sn == "") continue;
					int num = 0;
					bool parsed = Int32.TryParse(sn, out num);
					nums.Add(num);
				}
				matrix.Add(nums);
			}
		}

		// Processing
		int maxRow = 0;
		foreach (var row in matrix)
		{
			if (row.Count > maxRow)
				maxRow = row.Count;
		}
		foreach (var row in matrix)
		{
			for (int delta = maxRow - row.Count; delta > 0; delta--)
				row.Add(0);
		}

		Console.WriteLine();

		// Output
		Console.WriteLine("Output: ");
		foreach (var row in matrix)
		{
			foreach (var num in row)
				Console.Write($"{num} ");
			Console.WriteLine();
		}

		Console.WriteLine();

		// Methods
		MatrixStats.Max(in matrix, out int max);
		MatrixStats.Min(in matrix, out int min);
		MatrixStats.RowSums(in matrix, out List<int> rowSums);
		Console.WriteLine($"Min: {min}, Max: {max}");
		for (int i = 0; i < rowSums.Count; i++)
			Console.WriteLine($"Row {i} sum: {rowSums[i]}");
	}
}