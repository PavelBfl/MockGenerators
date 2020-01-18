using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	/// <summary>
	/// Объект генерации значений
	/// </summary>
	public class ValueGenerator
	{
		public ValueGenerator(int seed)
		{
			Seed = seed;
		}

		/// <summary>
		/// Зерно генерации значений
		/// </summary>
		protected int Seed { get; } = 0;
	}
}
