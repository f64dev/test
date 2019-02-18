using System;
using System.Collections.Generic;
using System.Linq;

namespace test2
{
	internal class Program
	{
		private static List<Item> GetRandomitemList(int count)
		{
			var list = new List<Item>(count);
			var random = new Random();

			foreach (var i in Enumerable.Range(0, count)) list.Add(new Item {Name = $"Item{i}", Price = random.Next(0, 100), Weight = random.Next(1, 6)});

			return list;
		}


		public static void Main(string[] args)
		{
			var itemsCount = 0;
			while (itemsCount == 0)
			{
				Console.WriteLine("Количество сгенерированных предметов:");
				if (int.TryParse(Console.ReadLine(), out var n))

					itemsCount = n;
			}

			var items = GetRandomitemList(itemsCount);
			foreach (var item in items) Console.WriteLine($"Name:{item.Name} Price:{item.Price} Weight{item.Weight}");


			var inventoryWeight = 0;
			while (inventoryWeight == 0)
			{
				Console.WriteLine("Емкость инвентаря:");
				if (int.TryParse(Console.ReadLine(), out var n))

					inventoryWeight = n;
			}


			var inventory = new Inventory(inventoryWeight);
			inventory.Fill(items);

			foreach (var item in inventory.Items) Console.WriteLine($"Name:{item.Name} Price:{item.Price} Weight{item.Weight}");
			
			Console.ReadLine();
		}
	}
}