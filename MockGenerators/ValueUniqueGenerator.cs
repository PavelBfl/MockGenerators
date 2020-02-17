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
	public class ValueUniqueGenerator<T> : IValueGenerator<T>
	{
		public ValueUniqueGenerator(IValueDifferentGenerator<T> baseGenerator, IEqualityComparer<T> equalityComparer = null)
		{
			BaseGenerator = baseGenerator ?? throw new NullReferenceException(nameof(baseGenerator));
			EqualityComparer = equalityComparer ?? EqualityComparer<T>.Default;
		}
		/// <summary>
		/// Источник генерируемых значений
		/// </summary>
		public IValueDifferentGenerator<T> BaseGenerator { get; } = null;
		/// <summary>
		/// Объект сравнения значений
		/// </summary>
		public IEqualityComparer<T> EqualityComparer { get; } = null;

		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private class Enumerator : IEnumerator<T>
		{
			public Enumerator(ValueUniqueGenerator<T> owner)
			{
				Owner = owner ?? throw new NullReferenceException();
				OldValues = new HashSet<T>(Owner.EqualityComparer);
				EnumerableBase = Owner.BaseGenerator.GetEnumerator();
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
			private HashSet<T> OldValues { get; } = null;
			/// <summary>
			/// Базовый счётчик коллекции
			/// </summary>
			private IEnumerator<T> EnumerableBase { get; } = null;

			public bool MoveNext()
			{
				if (EnumerableBase.MoveNext())
				{
					var current = EnumerableBase.Current;
					if (OldValues.Contains(current))
					{
						current = Owner.BaseGenerator.GetDifferent(OldValues);
						if (OldValues.Contains(current))
						{
							throw new Exception();
						}
					}

					OldValues.Add(current);
					Current = current;
					return true;
				}
				return false;
			}

			public void Reset()
			{
				OldValues.Clear();
				EnumerableBase.Reset();
			}

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			private void Dispose(bool disposing)
			{
				if (disposing)
				{
					EnumerableBase.Dispose();
				}
			}
		}
	}
}
