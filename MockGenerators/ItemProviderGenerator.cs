using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockGenerators
{
	/// <summary>
	/// Генератор предоставляющий один из элементов коллекции
	/// </summary>
	/// <typeparam name="T">Тип генерируемого элемента</typeparam>
	public class ItemProviderGenerator<T> : ValueGenerator, IValueGenerator<T>
	{
		private const string ITEMS_EMPTY_MESSAGE = "Предоставляемая коллекция пуста";

		public ItemProviderGenerator(Random random, IEnumerable<T> items)
			: base(random)
		{
			if (items is null)
			{
				throw new NullReferenceException(nameof(items));
			}
			if (!items.Any())
			{
				throw new InvalidOperationException(ITEMS_EMPTY_MESSAGE);
			}

			Items = items.ToArray();
		}
		/// <summary>
		/// Контейнер предоставляемых элементов
		/// </summary>
		public IReadOnlyList<T> Items { get; } = null;

		public T Generate()
		{
			return Items[Random.Next(Items.Count)];
		}
	}
}
