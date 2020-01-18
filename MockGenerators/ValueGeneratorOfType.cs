using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	public abstract class ValueGenerator<T> : ValueGenerator, IValueGenerator<T>
	{
		public ValueGenerator(int seed)
			: base(seed)
		{
		}

		protected abstract T Generate(Random random);

		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private class Enumerator : IEnumerator<T>
		{
			public Enumerator(ValueGenerator<T> owner)
			{
				Owner = owner ?? throw new NullReferenceException();
				Random = new Random(Owner.Seed);
			}

			public ValueGenerator<T> Owner { get; } = null;
			public Random Random { get; private set; } = null;
			public T Current { get; set; } = default;

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				
			}

			public bool MoveNext()
			{
				Current = Owner.Generate(Random);
				return true;
			}

			public void Reset()
			{
				Random = new Random(Owner.Seed);
			}
		}
	}
}
