using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.DoubleGenerators
{
	public class DoubleGenerator : ValueGenerator, IValueGenerator<double>
	{
		public DoubleGenerator(Random random)
			: base(random)
		{
		}

		public double Generate()
		{
			return Random.NextDouble();
		}
	}
}
