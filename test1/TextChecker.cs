using System;
using System.Collections.Generic;
using System.Text;

namespace test1
{
	public sealed class TextChecker
	{
		#region Fields

		private static readonly char[] _cachedLettersRU = {'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е'};
		private static readonly char[] _cachedLettersEN = {'a', 'e', 'i', 'y', 'o', 'u'};

		private readonly int _minWordLen;
		private readonly int _maxWordLen;

		private readonly List<(char, int)> _temp = new List<(char, int)>(11);

		#endregion

		#region Check

		public TextChecker(int minWordLen, int maxWordLen)
		{
			_minWordLen = minWordLen;
			_maxWordLen = maxWordLen;
		}

		public void Check(string text)
		{
			if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
			{
				Console.WriteLine("Текст не найден");
				return;
			}

			var str = text.Split(' ');


			var lang = GetLang(text);

			char[] langChars;

			switch (lang)
			{
				case LangType.Russian:
				{
					langChars = _cachedLettersRU;
					break;
				}
				case LangType.English:
				{
					langChars = _cachedLettersEN;
					break;
				}
				default:
				{
					Console.WriteLine("Данный язык не поддерживается");
					return;
				}
			}

			ClearTemp(langChars);

			foreach (var s in str)
				if (s.Length <= _maxWordLen && s.Length >= _minWordLen)
					foreach (var ch in s)
						if (char.IsLetter(ch))
							for (var i = 0; i < langChars.Length; i++)
								if (langChars[i] == char.ToLower(ch))
								{
									var v = _temp[i];
									++v.Item2;
									_temp[i] = v;
								}

			var strBuider = new StringBuilder();


			_temp.Sort((f, s) => s.Item2.CompareTo(f.Item2));

			Console.WriteLine($"Язык: {lang.ToString()}");

			foreach (var (ch, value) in _temp) strBuider.Append($"{ch} ");

			Console.WriteLine(strBuider.ToString());
			strBuider.Clear();

			foreach (var (ch, value) in _temp) strBuider.Append($"{value} ");

			Console.WriteLine(strBuider.ToString());
		}

		private void ClearTemp(char[] array)
		{
			_temp.Clear();

			foreach (var e in array) _temp.Add((e, 0));
		}

		#endregion

		#region Lang

		private LangType GetLang(string text, int i = 0)
		{
			var t = text[i];
			if (!char.IsLetter(t) && i < text.Length)
				return GetLang(text, ++i);

			var charInt = (int) char.ToLower(t);

			if (charInt >= 97 && charInt <= 122)
				return LangType.English;


			if (charInt >= 1072 && charInt <= 1103)
				return LangType.Russian;

			return LangType.None;
		}

		private enum LangType
		{
			None,
			Russian,
			English
		}

		#endregion
	}
}