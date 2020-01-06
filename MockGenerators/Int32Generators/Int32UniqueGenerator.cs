using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators.Int32Generators
{
	/// <summary>
	/// Генератор уникальных значений типа <see cref="int"/>
	/// </summary>
	public class Int32UniqueGenerator : ValueUniqueGenerator<int>
	{
		public Int32UniqueGenerator(IValueGenerator<int> baseGenerator)
			: base(baseGenerator)
		{
		}

		protected override int Increment(int value)
		{
			return ++value;
		}
	}
}
