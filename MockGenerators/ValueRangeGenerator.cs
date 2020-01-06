using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	/// <summary>
	/// Генератор значений внутри диапазона
	/// </summary>
	/// <typeparam name="T">Тип генерируемого значения</typeparam>
	public class ValueRangeGenerator<T> : ValueGenerator
	{
		public ValueRangeGenerator(Random random, T min, T max)
			: this(random, new Range<T>(min, max))
		{

		}
		private ValueRangeGenerator(Random random, Range<T> range)
			: base(random)
		{
			Range = range;
		}

		/// <summary>
		/// Диапазон допустимых значений
		/// </summary>
		public Range<T> Range { get; } = default;
	}
}
