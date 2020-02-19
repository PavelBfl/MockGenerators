using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockGenerators.StringGenerators
{
	public class StringUniqueGenerator : StringGenerator
	{
		public StringUniqueGenerator(int seed)
			: base(seed)
		{
		}

		public StringUniqueGenerator(int seed, IEnumerable<char> usedChars)
			: base(seed, usedChars)
		{
		}

		public StringUniqueGenerator(int seed, int maxLength)
			: base(seed, maxLength)
		{
		}

		public StringUniqueGenerator(int seed, IEnumerable<char> usedChars, int maxLength)
			: base(seed, usedChars, maxLength)
		{
		}

		private void AddFirstRange()
		{
			var max = new int[MaxLength];
			for (int i = 0; i < UsedChars.Count; i++)
			{
				max[i] = UsedChars.Count - 1;
			}

			ranges.Add((new int[] { }, max));
		}

		private readonly List<(int[], int[])> ranges = new List<(int[], int[])>();

		protected override string Generate(Random random)
		{
			var index = random.Next(ranges.Count);
			var range = ranges[index];

			var result = Random(range.Item1, range.Item2, random);
			var beforeRange = (min: range.Item1, max: result);
			var afterRange = (min: Increment(result), max: range.Item2);
			var beforeGapExists = !beforeRange.min.SequenceEqual(beforeRange.max);
			var afterGapExists = !afterRange.min.SequenceEqual(afterRange.max);
			if (beforeGapExists && afterGapExists)
			{
				ranges[index] = beforeRange;
				ranges.Add(afterRange);
			}
			else if (beforeGapExists)
			{
				ranges[index] = beforeRange;
			}
			else if (afterGapExists)
			{
				ranges[index] = afterRange;
			}
			else
			{
				ranges.RemoveAt(index);
			}
			return new string(result.Select(charIndex => UsedChars[charIndex]).ToArray());
		}

		private int[] Random(int[] min, int[] max, Random random)
		{
			var result = new int[random.Next(min.Length, max.Length + 1)];
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = random.Next(i < min.Length ? min[i] : 0, max[i] + 1);
			}
			return result;
		}
		private int[] Increment(int[] value)
		{
			var result = value.ToArray();
			for (int i = result.Length - 1; i >= 0; i--)
			{
				if (result[i] >= UsedChars.Count)
				{
					result[i] = 0;
				}
				else
				{
					result[i]++;
					return result;
				}
			}

			return Enumerable.Range(0, value.Length + 1).Select(x => 0).ToArray();
		}
	}
}
