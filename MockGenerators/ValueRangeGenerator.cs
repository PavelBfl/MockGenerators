using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	/// <summary>
	/// Генератор значений внутри диапазона
	/// </summary>
	/// <typeparam name="T">Тип генерируемого значения</typeparam>
	public abstract class ValueRangeGenerator<T> : ValueGenerator<T>
	{
		public ValueRangeGenerator(int seed, T min, T max)
			: this(seed, new Range<T>(min, max))
		{

		}
		private ValueRangeGenerator(int seed, Range<T> range)
			: base(seed)
		{
			Range = range;
		}

		/// <summary>
		/// Диапазон допустимых значений
		/// </summary>
		public Range<T> Range { get; } = default;
	}
}
