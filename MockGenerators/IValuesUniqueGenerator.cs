using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	/// <summary>
	/// Генератор уникальных значений
	/// </summary>
	/// <typeparam name="T">Тип генерируемого значения</typeparam>
	interface IValuesUniqueGenerator<T> : IValueGenerator<T>
	{
		/// <summary>
		/// Перезапустить генератор
		/// </summary>
		void Reset();
	}
}
