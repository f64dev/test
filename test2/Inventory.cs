using System.Collections.Generic;

namespace test2
{
	public class Inventory
	{
		private readonly float _weight;
		public List<Item> Items { get; } = new List<Item>();
		
		public Inventory(float weight)
		{
			_weight = weight;
		}


		public void Fill(List<Item> items)
		{
			items.Sort((f, s) => s.Value.CompareTo(f.Value));

			Items.Clear();

			var w = 0;

			foreach (var item in items)
			{
				if (w + item.Weight <= _weight)
				{
					Items.Add(item);
					w += item.Weight;
				}
			}
		}
	}
}