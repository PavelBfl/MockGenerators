using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.DoubleGenerators
{
	public class DoubleUniqueGenerator : ValueUniqueGenerator<double>
	{
		public DoubleUniqueGenerator(IValueGenerator<double> baseGenerator, DoubleComparer comparer)
			: base(baseGenerator)
		{
			Comparer = comparer ?? throw new NullReferenceException(nameof(comparer));
		}

		public DoubleComparer Comparer { get; } = null;

		protected override double Increment(double value)
		{
			return value + Comparer.Epsilon;
		}
	}
}
