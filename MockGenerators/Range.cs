using System;
using System.Collections.Generic;

namespace MockGenerators
{
	public struct Range<T>
	{
		public Range(T min, T max)
		{
			if (Comparer<T>.Default.Compare(min, max) > 0)
			{
				throw new Exception();
			}
			Min = min;
			Max = max;
		}

		public T Min { get; }
		public T Max { get; }
	}
}
