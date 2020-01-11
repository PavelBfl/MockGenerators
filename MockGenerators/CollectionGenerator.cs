using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MockGenerators
{
	/// <summary>
	/// Генератор коллекций элементов
	/// </summary>
	/// <typeparam name="T">Тип элемента коллекции</typeparam>
	public class CollectionGenerator<T> : ValueGenerator, IValueGenerator<IEnumerable<T>>
	{
		public CollectionGenerator(Random random, int lengthMin, IEnumerable<IValueGenerator<T>> itemsGenerators)
			: base(random)
		{
			ItemsGenerators = (itemsGenerators ?? throw new NullReferenceException(nameof(itemsGenerators))).ToArray();

			LengthMin = lengthMin <= ItemsGenerators.Count ? lengthMin : throw new ArgumentOutOfRangeException();
		}
		public CollectionGenerator(Random random, int lengthMin, int lengthMax, IValueGenerator<T> itemsGenerator)
			: this(random, lengthMin, Enumerable.Range(0, lengthMax).Select(_ => itemsGenerator))
		{

		}
		public CollectionGenerator(Random random, int lengthMax, IValueGenerator<T> itemsGenerator)
			: this(random, 0, Enumerable.Range(0, lengthMax).Select(_ => itemsGenerator))
		{

		}

		/// <summary>
		/// Минимальная длина генерируемой коллекции
		/// </summary>
		public int LengthMin { get; } = 0;
		/// <summary>
		/// Генераторы елементов коллеции
		/// </summary>
		public IReadOnlyList<IValueGenerator<T>> ItemsGenerators { get; } = null;

		public IEnumerable<T> Generate()
		{
			var result = new T[Random.Next(LengthMin, ItemsGenerators.Count)];
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = ItemsGenerators[i].Generate();
			}
			return result;
		}
	}
}
