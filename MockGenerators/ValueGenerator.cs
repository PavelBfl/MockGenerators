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
		public ValueGenerator(Random random)
		{
			Random = random ?? throw new NullReferenceException();
		}

		protected Random Random { get; } = null;
	}
}
