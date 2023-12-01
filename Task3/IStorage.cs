using System;
namespace Task3
{
	public interface IStorage
	{
		void InputData(in int[] data);
		void InputDataRandom();
		void Print(in int start, in int end);
		void FindValue(out List<int> indexes, in int value);
		void DelValue(in int value);
		void FindMax(out int max);
		//void Add(out IStorage sum, in IStorage other);
		void Sort();
		int Length { get; }
		public int this[int i] { get; set; }
	}
}

