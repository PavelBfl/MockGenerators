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
	public class CollectionGenerator<T> : ValueGenerator<IEnumerable<T>>
	{
		public CollectionGenerator(int seed, int lengthMin, IEnumerable<IValueGenerator<T>> itemsGenerators)
			: base(seed)
		{
			ItemsGenerators = (itemsGenerators ?? throw new NullReferenceException(nameof(itemsGenerators))).ToArray();

			LengthMin = lengthMin <= ItemsGenerators.Count ? lengthMin : throw new ArgumentOutOfRangeException();
		}
		public CollectionGenerator(int seed, int lengthMin, int lengthMax, IValueGenerator<T> itemsGenerator)
			: this(seed, lengthMin, Enumerable.Range(0, lengthMax).Select(_ => itemsGenerator))
		{

		}
		public CollectionGenerator(int seed, int lengthMax, IValueGenerator<T> itemsGenerator)
			: this(seed, 0, Enumerable.Range(0, lengthMax).Select(_ => itemsGenerator))
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

		protected override IEnumerable<T> Generate(Random random)
		{
			var result = new T[random.Next(LengthMin, ItemsGenerators.Count)];
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = ItemsGenerators[i].First();
			}
			return result;
		}
	}
}
