using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.Int32Generators
{
	/// <summary>
	/// Генератор чисел типа <see cref="int"/>
	/// </summary>
	public class Int32Generator : ValueGenerator, IValueGenerator<int>
	{
		public Int32Generator(Random random)
			: base(random)
		{
		}

		public int Generate()
		{
			return Random.Next();
		}
	}
}
