using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MockGenerators
{
	abstract class EnumeratorGenerator<T> : IEnumerator<T>
	{
		public EnumeratorGenerator(int seed)
		{
			Seed = seed;
			Reset();
		}

		private int Seed { get; } = 0;
		protected Random Random { get; private set; } = null;

		public T Current { get; protected set; } = default;

		object IEnumerator.Current => Current;

		public void Dispose()
		{
			
		}

		public abstract bool MoveNext();

		public virtual void Reset()
		{
			Random = new Random(Seed);
		}
	}
}
