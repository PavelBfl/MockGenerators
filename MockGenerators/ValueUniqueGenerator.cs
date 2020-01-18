using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockGenerators
{
	/// <summary>
	/// Базовый объект для генерации уникальных значений
	/// </summary>
	/// <typeparam name="T">Тип генерируемых значений</typeparam>
	public abstract class ValueUniqueGenerator<T> : IValueGenerator<T>
	{
		public ValueUniqueGenerator(IValueGenerator<T> baseGenerator, IEqualityComparer<T> equalityComparer = null)
		{
			BaseGenerator = baseGenerator ?? throw new NullReferenceException(nameof(baseGenerator));
			EqualityComparer = equalityComparer ?? EqualityComparer<T>.Default;
		}
		/// <summary>
		/// Источник генерируемых значений
		/// </summary>
		public IValueGenerator<T> BaseGenerator { get; } = null;
		/// <summary>
		/// Объект сравнения значений
		/// </summary>
		public IEqualityComparer<T> EqualityComparer { get; } = null;

		/// <summary>
		/// Инкрементировать значение
		/// </summary>
		/// <param name="value">Текущее значение</param>
		/// <returns>Инкрементированое значение</returns>
		protected abstract T Increment(T value);

		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerable(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private class Enumerable : IEnumerator<T>
		{
			public Enumerable(ValueUniqueGenerator<T> owner)
			{
				Owner = owner ?? throw new NullReferenceException();
				OldValues = new HashSet<T>(Owner.EqualityComparer);
			}

			/// <summary>
			/// Владелец итератора
			/// </summary>
			public ValueUniqueGenerator<T> Owner { get; } = null;

			public T Current { get; private set; } = default;

			object IEnumerator.Current => Current;

			/// <summary>
			/// Хеш ранее сгенерированых значений
			/// </summary>
			private HashSet<T> OldValues = null;

			public bool MoveNext()
			{
				var current = Owner.BaseGenerator.First();
				while (OldValues.Contains(current))
				{
					current = Owner.Increment(current);
				}
				Current = current;
				return true;
			}

			public void Reset()
			{
				OldValues.Clear();
			}

			public void Dispose()
			{
				
			}
		}
	}
}
