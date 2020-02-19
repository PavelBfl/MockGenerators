using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.Int32Generators
{
	/// <summary>
	/// Генератор чисел типа <see cref="int"/> ограниченых диапазоном
	/// </summary>
	public class Int32RangeGenerator : ValueRangeGenerator<int>
	{
		public Int32RangeGenerator(int seed, int min, int max)
			: base(seed, min, max)
		{
		}

		protected override int Generate(Random random)
		{
			return random.Next(Range.Min, Range.Max);
		}
	}
}
