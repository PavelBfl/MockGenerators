using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	/// <summary>
	/// Базовый объект для генерации уникальных значений
	/// </summary>
	/// <typeparam name="T">Тип генерируемых значений</typeparam>
	public abstract class ValueUniqueGenerator<T> : IValuesUniqueGenerator<T>
	{
		public ValueUniqueGenerator(IValueGenerator<T> baseGenerator)
		{
			BaseGenerator = baseGenerator ?? throw new NullReferenceException(nameof(baseGenerator));
		}
		/// <summary>
		/// Источник генерируемых значений
		/// </summary>
		private IValueGenerator<T> BaseGenerator { get; } = null;

		/// <summary>
		/// Хеш ранее сгенерированых значений
		/// </summary>
		private readonly SortedSet<T> oldValues = new SortedSet<T>();

		/// <summary>
		/// Перезапустить генератор
		/// </summary>
		public void Reset()
		{
			oldValues.Clear();
		}
		/// <summary>
		/// Генерировать уникальное значение
		/// </summary>
		/// <returns>Новое значение</returns>
		public T Generate()
		{
			var result = BaseGenerator.Generate();
			foreach (var oldValue in oldValues)
			{
				while (EqualityComparer<T>.Default.Equals(result, oldValue))
				{
					result = Increment(result);
				}
			}
			oldValues.Add(result);
			return result;
		}
		/// <summary>
		/// Инкрементировать значение
		/// </summary>
		/// <param name="value">Текущее значение</param>
		/// <returns>Инкрементированое значение</returns>
		protected abstract T Increment(T value);
	}
}
