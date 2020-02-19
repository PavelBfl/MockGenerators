using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.DoubleGenerators
{
	public class DoubleUniqueGenerator : DoubleRangeGenerator
	{
		public DoubleUniqueGenerator(int seed, double min, double max, double epsilon)
			: base(seed, min, max)
		{
			doubleComparer = new DoubleComparer(epsilon);
			ranges.Add(new Range<double>(doubleComparer.Offset(min), doubleComparer.Offset(max)));
		}
		public DoubleUniqueGenerator(int seed, double epsilon)
			: this(seed, double.MinValue, double.MaxValue, epsilon)
		{
			
		}

		private readonly DoubleComparer doubleComparer = null;

		private readonly List<Range<double>> ranges = new List<Range<double>>();

		protected override double Generate(Random random)
		{
			var index = random.Next(ranges.Count);
			var range = ranges[index];
			var result = doubleComparer.Offset((range.Max - range.Min) * random.NextDouble() + range.Min);

			var beforeRange = new Range<double>(range.Min, result);
			var afterRange = new Range<double>(result + doubleComparer.Epsilon, range.Max);
			var beforeLength = beforeRange.Max - beforeRange.Min;
			var afterLength = afterRange.Max - afterRange.Min;
			if (beforeLength > doubleComparer.Epsilon && afterLength > doubleComparer.Epsilon)
			{
				ranges[index] = beforeRange;
				ranges.Add(afterRange);
			}
			else if (beforeLength > doubleComparer.Epsilon)
			{
				ranges[index] = beforeRange;
			}
			else if (afterLength > doubleComparer.Epsilon)
			{
				ranges[index] = afterRange;
			}
			else
			{
				ranges.RemoveAt(index);
			}
			return result * doubleComparer.Epsilon;
		}
	}
}
