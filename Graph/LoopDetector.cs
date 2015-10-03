using System;
using System.Linq;
using System.Collections.Generic;

namespace DependecyResolver
{
	public static class LoopDetector {

		public static void Check<T>(Node<T> graph) {
			if ((graph == null)
				|| (graph.Children == null)
				|| (graph.Children.Count <= 0)) {
				return;
			}
			for (int i = 0; i < graph.Children.Count; i++) {
				CheckOne(graph.Children[i]);
			}
		}

		private static void CheckOne<T>(Node<T> node) {
			var marker = new Node<T>();
			var stack = new Stack<Node<T>>();
			stack.Push(node);
			var currentPath = new Stack<Node<T>>();
			while (stack.Count > 0)	{
				var current = stack.Pop();
				if (current == marker) {
					if (currentPath.Count > 0) {
						currentPath.Pop();
					}
					continue;
				}
				stack.Push(marker);
				if (Contains(currentPath, current))	{
					currentPath.Push(current);
					var msg = string.Join(" => ", currentPath.Select(x => x.Data.ToString()).ToArray());
					throw new ApplicationException("Loop detected: " + msg);
				}
				currentPath.Push(current);
				foreach (var child in current.Children)	{
					stack.Push(child);
				}
			}
		}

		private static bool Contains<T>(Stack<Node<T>> stack, Node<T> target) {
			return stack.Any( x => target.EqualDataComparer(x.Data, target.Data));
		}
	}
}

