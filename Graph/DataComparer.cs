using System;

namespace DependecyResolver
{
	public class DataComparer<T> {

		public Func<T, T, bool> AreSame { get; set; }
	}
}

