namespace Task2;
internal class Program
{
	private static void Main(string[] args)
	{
		const int pekars = 8;
		const int delivers = 5;

		const int fastPek = 3, slowPek = 6;
		const int goodDel = 3, badDel = 2;
		const int delay = 2;

		const int deliveryTime = 5;
		const int maxWaitTime = 10;
		const int workDay = 20;

		Random random = new Random();

		//var t = new System.Timers.Timer(10);
		//var a = new Order(1, 3);
		int smolTime = 10;

		Console.WriteLine("Начало работы");
		var workTimer = new System.Timers.Timer(workDay * 1000);
		workTimer.Elapsed += delegate {
			return;
		};

		var orders = new Stack<Order>();
		int number = 0;

		var orderTimer = new System.Timers.Timer(delay * 1000);
		orderTimer.Elapsed += delegate {
			orders.Push(new Order(number, maxWaitTime));
			number++;
		};
		orderTimer.AutoReset = true;

		var storageStack = new Stack<Order>();
		var pekarsList = new List<System.Timers.Timer>();
		for (int i = 0; i < pekars; i++)
		{
			int pekTime = random.Next(fastPek, slowPek + 1) * 1000;
			var pekar = new System.Timers.Timer(pekTime + i * smolTime);
			pekar.Elapsed += delegate {
				if (orders.Count > 0) {
					Order order = orders.Pop();
					order.Cook();
					order.ToStorage();
					storageStack.Push(order);
				}
			};
			pekar.AutoReset = true;
			pekarsList.Add(pekar);
		}

		var deliversList = new List<System.Timers.Timer>();
		for (int i = 0; i < delivers; i++)
		{
			int trunk = random.Next(badDel, goodDel + 1);
			var deliver = new System.Timers.Timer(deliveryTime * 1000 + i * smolTime);
			deliver.Elapsed += delegate {
				for (int j = 0; j < delivers; j++)
				{
					if (storageStack.Count > 0)
					{
						Order order = storageStack.Pop();
						order.ToDelivery();
						order.Close();
					}
				}
			};
			deliver.AutoReset = true;
			deliversList.Add(deliver);
		}

		workTimer.Start();
		orderTimer.Start();
		foreach (var p in pekarsList)
			p.Start();
		foreach (var d in deliversList)
			d.Start();
		Console.Read();
	}
}