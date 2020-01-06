using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	public static class GeneratorExtension
	{
		/// <summary>
		/// Сгенерировать набор значений
		/// </summary>
		/// <param name="count">Количество необходимых значений</param>
		/// <returns>Коллекция значений</returns>
		public static IEnumerable<T> Generate<T>(this IValueGenerator<T> generator, int count)
		{
			for (int i = 0; i < count; i++)
			{
				yield return generator.Generate();
			}
		}
	}
}
