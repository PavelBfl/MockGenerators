using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.Int32Generators
{
	public class Int32UniqueGenerator : Int32RangeGenerator
	{
		public Int32UniqueGenerator(int seed, int min, int max)
			: base(seed, min, max)
		{
			ranges.Add(Range);
		}
		public Int32UniqueGenerator(int seed)
			: this(seed, int.MinValue, int.MaxValue)
		{

		}

		private readonly List<Range<int>> ranges = new List<Range<int>>();

		protected override int Generate(Random random)
		{
			var index = random.Next(ranges.Count);
			var range = ranges[index];
			var result = random.Next(range.Min, range.Max);

			var beforeRange = new Range<int>(range.Min, result);
			var afterRange = new Range<int>(result + 1, range.Max);
			var beforeLength = beforeRange.Max - beforeRange.Min;
			var afterLength = afterRange.Max - afterRange.Min;
			if (beforeLength > 0 && afterLength > 0)
			{
				ranges[index] = beforeRange;
				ranges.Add(afterRange);
			}
			else if (beforeLength > 0)
			{
				ranges[index] = beforeRange;
			}
			else if (afterLength > 0)
			{
				ranges[index] = afterRange;
			}
			else
			{
				ranges.RemoveAt(index);
			}
			return result;
		}
	}
}
