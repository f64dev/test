namespace test2
{
	public class Item
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public int Weight { get; set; }
		public float Value => Price / Weight;
	}
}