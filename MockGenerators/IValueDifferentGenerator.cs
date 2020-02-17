using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	/// <summary>
	/// Генератор уникальных значений
	/// </summary>
	/// <typeparam name="T">Тип генерируемого значения</typeparam>
	public interface IValueDifferentGenerator<T> : IValueGenerator<T>
	{
		/// <summary>
		/// Получить значение отличное от указаных
		/// </summary>
		/// <param name="exclude">Исключаемые значения</param>
		/// <returns>Уникальное значение в рамках отличное от всех предоставленых значений</returns>
		T GetDifferent(IEnumerable<T> exclude);
	}
}
