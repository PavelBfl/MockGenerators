using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.DoubleGenerators
{
	public class DoubleUniqueGenerator : ValueUniqueGenerator<double>
	{
		public DoubleUniqueGenerator(IValueGenerator<double> baseGenerator, DoubleComparer equalityComparer)
			: base(baseGenerator, equalityComparer)
		{
			DoubleComparer = equalityComparer ?? throw new NullReferenceException(nameof(equalityComparer));
		}

		public DoubleComparer DoubleComparer { get; } = null;

		protected override double Increment(double value)
		{
			return value + DoubleComparer.Epsilon;
		}
	}
}
