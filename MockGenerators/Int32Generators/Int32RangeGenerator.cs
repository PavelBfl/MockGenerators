using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.Int32Generators
{
	/// <summary>
	/// Генератор чисел типа <see cref="int"/> ограниченых диапазоном
	/// </summary>
	public class Int32RangeGenerator : ValueRangeGenerator<int>, IValueGenerator<int>
	{
		public Int32RangeGenerator(Random random, int min, int max)
			: base(random, min, max)
		{
		}

		public int Generate()
		{
			return Random.Next(Range.Max - Range.Min) + Range.Min;
		}
	}
}
