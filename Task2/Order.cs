using System;
namespace Task2
{
	public class Order
	{
		public enum Status
		{
			Open,
			Cooking,
			Storage,
			Delivery,
			Closed,
			Failed,
		}

		int number;
		System.Timers.Timer timer;
		public Status status { get; private set; }

		public Order(int number, int maxWait)
		{
			this.number = number;

			timer = new System.Timers.Timer(maxWait * 1000);
			timer.Elapsed += delegate {
				if (status != Status.Closed)
				{
					status = Status.Failed;
					Console.WriteLine($"Заказ {number} просрочен");
				}
			};

			timer.Start();
			status = Status.Open;
			Console.WriteLine($"Заказ {number} открыт");
		}

		public void Cook()
		{
			if (status != Status.Failed)
				status = Status.Cooking;
			Console.WriteLine($"Заказ {number} готовится");
		}

		public void ToStorage()
		{
			if (status != Status.Failed)
				status = Status.Storage;
			Console.WriteLine($"Заказ {number} на складе");
		}

		public void ToDelivery()
		{
			if (status != Status.Failed)
				status = Status.Delivery;
			Console.WriteLine($"Заказ {number} в доставке");
		}

		public void Close()
		{
			timer.Stop();
			if (status != Status.Failed)
				status = Status.Closed;
			Console.WriteLine($"Заказ {number} завершён");
		}
	}
}

