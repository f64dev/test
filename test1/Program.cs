using System;

namespace test1
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var min = 0;
			var max = 0;


			while (min == 0)
			{
				Console.WriteLine("Минимальная длина проверяемых слов:");
				
				if (int.TryParse(Console.ReadLine(), out var ch))
					min = ch;
			}

			
			while (max == 0)
			{
				Console.WriteLine("Максимальная длина проверяемых слов:");
				
				if (int.TryParse(Console.ReadLine(), out var ch))
					max = ch;
			}

			var textChecker = new TextChecker(min, max);
			
			Console.WriteLine("Текст для проверки:");

			textChecker.Check(Console.ReadLine());

			Console.ReadLine();
		}
	}
}