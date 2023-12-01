using System;
namespace Task3
{
	public class Storage : IStorage
	{
		List<int> data;

		public Storage(int length)
		{
			data = new List<int>(length);
		}

		public int Length => data.Count;

		public int this[int i]
		{
			get { return data[i]; }
			set { data[i] = value; }
		}

		public void Add(out IStorage sum, in IStorage other)
		{
			//if (Length != other.) throw new Exception("Different length");
			var dum = new Storage(Length);
			for (int i = 0; i < Length; i++)
			{
				int a = this[i];
				int b = other[i];
				dum.data.Add(a + b);
			}
			sum = dum;
		}

		public void DelValue(in int value)
		{
			while (data.Contains(value))
				data.Remove(value);
		}

		public void FindMax(out int max)
		{
			max = data.Max();
		}

		public void FindValue(out List<int> indexes, in int value)
		{
			indexes = new List<int>();
			for (int i = 0; i < data.Count; i++)
			{
				if (data[i] == value)
					indexes.Add(i);
			}
		}

		public void InputData(in int[] data)
		{
			if (data.Length > this.data.Capacity) throw new IndexOutOfRangeException();
			this.data.Clear();
			for (int i = 0; i < data.Length; i++)
				this.data.Add(data[i]);

		}

		public void InputDataRandom()
		{
			Random random = new Random();
			data.Clear();
			for (int i = 0; i < data.Capacity; i++)
				data.Add(random.Next(0, 10));
		}

		public void Print(in int start, in int end)
		{
			for (int i = start; i <= end; i++)
				Console.Write($"{this[i]} ");
			Console.WriteLine();
		}

		public void Sort()
		{
			data.Sort();
		}
	}
}

