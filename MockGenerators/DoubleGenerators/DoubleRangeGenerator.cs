using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.DoubleGenerators
{
	public class DoubleRangeGenerator : ValueRangeGenerator<double>
	{
		public DoubleRangeGenerator(int seed, double min, double max)
			: base(seed, min, max)
		{
		}

		protected override double Generate(Random random)
		{
			return ((Range.Max - Range.Min) * random.NextDouble()) + Range.Min;
		}
	}
}
