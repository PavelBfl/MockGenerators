using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.Int32Generators
{
	/// <summary>
	/// Генератор чисел типа <see cref="int"/> ограниченых диапазоном
	/// </summary>
	public class Int32RangeGenerator : ValueRangeGenerator<int>, IValueDifferentGenerator<int>
	{
		public Int32RangeGenerator(int seed, int min, int max)
			: base(seed, min, max)
		{
		}

		public int GetDifferent(IEnumerable<int> exclude)
		{
			var container = new HashSet<int>(exclude);
			for (int i = Range.Min; i <= Range.Max; i++)
			{
				if (!container.Contains(i))
				{
					return i;
				}
			}
			throw new Exception();
		}

		protected override int Generate(Random random)
		{
			return random.Next(Range.Min, Range.Max);
		}
	}
}
