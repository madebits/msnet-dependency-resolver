using System;
using System.Linq;
using System.Collections.Generic;

namespace DependecyResolver
{
	public static class TopologicSort {

		public static List<T> Sort<T> (Node<T> graph) {
			var orderedList = new List<Node<T>>();
			var frontier = new List<Node<T>>();
			foreach(var n in graph.Children) {
				frontier.Add(n);
			}
			foreach (var node in frontier) {
				Visit(graph, orderedList, node);
			}
			return orderedList.Select(x => x.Data).ToList();
		}

		private static void Visit<T> (Node<T> graph, List<Node<T>> orderedList, Node<T> node) {
			if (node.SortedFlag)
				return;
			node.SortedFlag = true; // flag
			foreach (var child in node.Children) {
				Visit (graph, orderedList, child);
			}
			orderedList.Add(node);
		}
	}
}

