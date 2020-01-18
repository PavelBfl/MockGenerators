using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.DoubleGenerators
{
	public class DoubleGenerator : ValueGenerator<double>
	{
		public DoubleGenerator(int seed)
			: base(seed)
		{
		}

		protected override double Generate(Random random)
		{
			return random.NextDouble();
		}
	}
}
