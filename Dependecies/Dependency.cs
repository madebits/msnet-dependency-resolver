using System;
using System.Linq;
using System.Collections.Generic;

namespace DependecyResolver
{
	public class Dependency<T> {

		public Dependency () {
			this.Before = new List<T>();
			this.After = new List<T>();
		}

		public T Current { get; set; }

		/// <summary>
		/// Items before current
		/// </summary>
		public List<T> Before { get; set; }
		/// <summary>
		/// Items after current
		/// </summary>
		public List<T> After { get; set; }
	}
}

