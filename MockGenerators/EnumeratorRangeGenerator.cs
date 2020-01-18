using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	abstract class EnumeratorRangeGenerator<T> : EnumeratorGenerator<T>
	{
		public EnumeratorRangeGenerator(int seed, Range<T> range)
			: base(seed)
		{
			Range = range;
		}

		public Range<T> Range { get; } = default;
	}
}
