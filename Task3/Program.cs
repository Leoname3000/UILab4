namespace Task3;
internal class Program
{
	private static void Main(string[] args)
	{
		Storage storage = new Storage(10);

		storage.InputDataRandom();
		//storage.InputData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });
		Console.Write("Storage:  ");
		storage.Print(0, storage.Length - 1);

		storage.Sort();
		Console.Write("Sorted:   ");
		storage.Print(0, storage.Length - 1);

		int toDelete = 6;
		Console.Write($"Delete {toDelete}: ");
		storage.DelValue(toDelete);
		storage.Print(0, storage.Length - 1);

		storage.FindMax(out int max);
		Console.WriteLine($"Max: {max}");

		int toFind = 0;
		Console.Write($"Found {toFind} at: ");
		storage.FindValue(out List<int> idx, toFind);
		foreach (var i in idx) Console.Write($"{i} ");
		Console.WriteLine("\n");

		Storage first = new Storage(9);
		first.InputData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
		Console.Write("First:  ");
		first.Print(0, first.Length - 1);

		Storage second = new Storage(9);
		second.InputData(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 });
		Console.Write("Second: ");
		second.Print(0, second.Length - 1);

		IStorage sum;
		first.Add(out sum, second);
		Console.Write("Sum:    ");
		sum.Print(0, sum.Length - 1);
	}
}