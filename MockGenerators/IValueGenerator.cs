using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	/// <summary>
	/// Генератор значений
	/// </summary>
	/// <typeparam name="T">Тип генерируемого значения</typeparam>
	public interface IValueGenerator<T> : IEnumerable<T>
	{
		
	}
}
