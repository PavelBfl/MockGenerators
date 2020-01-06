using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockGenerators.StringGenerators
{
	/// <summary>
	/// Генератор уникальных значений для типа <see cref="string"/>
	/// </summary>
	public class StringUniqueGenerator : ValueUniqueGenerator<string>
	{
		public StringUniqueGenerator(StringGenerator baseGenerator)
			: base(baseGenerator)
		{
			StringBaseGenerator = baseGenerator ?? throw new NullReferenceException();
		}

		/// <summary>
		/// Базовый генератор
		/// </summary>
		public StringGenerator StringBaseGenerator { get; } = null;

		protected override string Increment(string value)
		{
			var chars = value.ToCharArray();
			Increment(chars);
			return new string(chars);
		}

		private char[] Increment(char[] chars)
		{
			for (var i = chars.Length - 1; i >= 0; i--)
			{
				if (chars[i] == StringBaseGenerator.UsedChars.Last())
				{
					chars[i] = StringBaseGenerator.UsedChars.First();
				}
				else
				{
					if (TryIndexOf(StringBaseGenerator.UsedChars, chars[i], out var usedIndex))
					{
						chars[i] = StringBaseGenerator.UsedChars[++usedIndex];
						return chars;
					}
					else
					{
						throw new Exception();
					}
				} 
			}

			if (chars.Length < StringBaseGenerator.MaxLength)
			{
				var result = new char[chars.Length + 1];
				for (int i = 0; i < result.Length; i++)
				{
					result[i] = StringBaseGenerator.UsedChars.First();
				}
				return result;
			}
			else
			{
				throw new ArgumentOutOfRangeException();
			}
		}

		private bool TryIndexOf<T>(IEnumerable<T> collection, T findItem, out int index)
		{
			var currentIndex = 0;
			foreach (var item in collection)
			{
				if (EqualityComparer<T>.Default.Equals(item, findItem))
				{
					index = currentIndex;
					return true;
				}
				currentIndex++;
			}

			index = -1;
			return false;
		}
	}
}
