using System;
using System.Linq;
using System.Collections.Generic;

namespace TopologicalSort
{
	public class Graph<T> where T : IEqualityComparer<T>
	{
		public Graph(DataComparator<T> comparer = null) 
		{
			this.DataComparer = comparer;
			this.Nodes = new List<Node<T>>();
		}

		public DataComparator<T> DataComparer{ get; set; }
		public List<Node<T>> Nodes { get; set; }

		public Node<T> FindNode(T s) 
		{
			return this.Nodes.Find(n => DataComparer.AreSame(n.NodeData, s));
		}

		public Node<T> FindOrInsertNode(T s) 
		{
			if (s == null) return null;
			var sn = FindNode(s);
			if (sn == null)
			{
				sn = new Node<T> { NodeData = s };
				this.Nodes.Add(sn);
			}
			return sn;
		}

		public bool IsChild(Node<T> n) 
		{
			foreach (var t in this.Nodes) 
			{
				if (t.Children.Contains(n)) return true;
			}
			return false;
		}
	}
}

