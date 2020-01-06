using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.DoubleGenerators
{
	public class DoubleRangeGenerator : ValueRangeGenerator<double>, IValueGenerator<double>
	{
		public DoubleRangeGenerator(Random random, double min, double max)
			: base(random, min, max)
		{
		}

		public double Generate()
		{
			return ((Range.Max - Range.Min) * Random.NextDouble()) + Range.Min;
		}
	}
}
