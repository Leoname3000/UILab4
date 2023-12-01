using System;
namespace Task1
{
	public static class MatrixStats
	{
		public static void Max(in List<List<int>> matrix, out int max)
		{
			max = Int32.MinValue;
			foreach (var row in matrix)
				foreach (var num in row)
					if (num > max)
						max = num;
		}

		public static void Min(in List<List<int>> matrix, out int min)
		{
			min = Int32.MaxValue;
			foreach (var row in matrix)
				foreach (var num in row)
					if (num < min)
						min = num;
		}

		public static void RowSums(in List<List<int>> matrix, out List<int> rowSums)
		{
			rowSums = new List<int>();
			foreach (var row in matrix)
			{
				int rowSum = 0;
				foreach (var num in row)
					rowSum += num;
				rowSums.Add(rowSum);
			}
		}
	}
}

