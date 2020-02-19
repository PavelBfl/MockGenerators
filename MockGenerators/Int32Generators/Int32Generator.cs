using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockGenerators.Int32Generators
{
	/// <summary>
	/// Генератор чисел типа <see cref="int"/>
	/// </summary>
	public class Int32Generator : ValueGenerator<int>
	{
		public Int32Generator(int seed)
			: base(seed)
		{
		}

		public int GetDifferent(IEnumerable<int> exclude)
		{
			return exclude.DefaultIfEmpty(0).Max() + 1;
		}

		protected override int Generate(Random random)
		{
			return random.Next();
		}
	}
}
