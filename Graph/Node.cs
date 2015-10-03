using System;
using System.Linq;
using System.Collections.Generic;

namespace DependecyResolver
{
	public class Node<T> {

		public Node() {
			this.Children = new List<Node<T>>();
		}

		public T Data { get; set; }
		public Func<T, T, bool> EqualDataComparer{ get; set; }

		public List<Node<T>> Children { get; set; }

		public Node<T> FindChild (T d) {
			return this.Children.FirstOrDefault(x => EqualDataComparer(x.Data, d));
		}

		public bool HasChild (T d) {
			return (FindChild(d) != null);
		}

		public Node<T> FindOrInsertChild (T d) {
			var n = FindChild (d);
			if (n == null) {
				n = new Node<T>{ Data = d, EqualDataComparer = this.EqualDataComparer };
				this.Children.Add(n);
			}
			return n;
		}

		public void AddChild (Node<T> n) {
			if(n == null) return;
			this.Children.Add(n);
		}

		/// <summary>
		/// not intended for direct usage
		/// </summary>
		internal bool SortedFlag { get; set; } 

		public override string ToString() {
			return (this.Data == null ? "*" : this.Data.ToString())
				+ " => {"
				+ string.Join(", ", this.Children.Select(x => x.Data.ToString()).ToArray())
				+ "}";
		}
	}
}

