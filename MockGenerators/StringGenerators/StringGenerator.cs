using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockGenerators.StringGenerators
{
	/// <summary>
	/// Генератор значений типа <see cref="string"/>
	/// </summary>
	public class StringGenerator : ValueGenerator, IValueGenerator<string>
	{
		/// <summary>
		/// Значение по умолчанию для максимальной длины генерируемой строки
		/// </summary>
		private const int DEFAULT_MAX_LENGTH = 10;
		/// <summary>
		/// Генерация символов используемых для создания строки
		/// </summary>
		/// <returns>Коллекция генерируемых символов</returns>
		private static IEnumerable<char> GetDefaultChars()
		{
			const int MIN_ASCII_CHAR = 33;
			const int MAX_ASCII_CHAR = 126;

			for (int i = MIN_ASCII_CHAR; i <= MAX_ASCII_CHAR; i++)
			{
				yield return (char)i;
			}
		}

		public StringGenerator(Random random)
			: base(random)
		{
			UsedChars = GetDefaultChars().ToArray();
		}
		public StringGenerator(Random random, IEnumerable<char> usedChars, int maxLength)
			: base(random)
		{
			UsedChars = usedChars?.Distinct().ToArray() ?? throw new NullReferenceException();
			MaxLength = maxLength >= 0 ? maxLength : throw new ArgumentOutOfRangeException();
		}
		public StringGenerator(Random random, IEnumerable<char> usedChars)
			: this(random, usedChars, DEFAULT_MAX_LENGTH)
		{
			
		}
		public StringGenerator(Random random, int maxLength)
			: this(random, GetDefaultChars(), DEFAULT_MAX_LENGTH)
		{

		}

		/// <summary>
		/// Максимальная длина генерируемой строки
		/// </summary>
		public int MaxLength { get; } = DEFAULT_MAX_LENGTH;
		/// <summary>
		/// Коллекция используемых символов при генерации
		/// </summary>
		public IReadOnlyList<char> UsedChars { get; } = null;

		/// <summary>
		/// Генерировать новое значение
		/// </summary>
		/// <returns>Новое сгенерированое значение</returns>
		public string Generate()
		{
			var chars = new char[Random.Next(MaxLength + 1)];
			for (int i = 0; i < chars.Length; i++)
			{
				chars[i] = UsedChars[Random.Next(UsedChars.Count)];
			}
			return new string(chars);
		}
	}
}
