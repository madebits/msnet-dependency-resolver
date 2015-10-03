using System;
using System.Linq;
using System.Collections.Generic;

namespace DependecyResolver
{
	public static class Resolver
	{
		public static List<T> Resolve<T> (List<Dependency<T>> dependecies, Func<T, T, bool> equalDataComparer, bool checkForLoops = true)	{
			if (dependecies == null)
				return null;
			if (dependecies.Count <= 0)
				return new List<T> ();
			var graph = GetDependenciesGraph<T> (dependecies, equalDataComparer);
			if (checkForLoops) {
				LoopDetector.Check (graph);
			}
			return TopologicSort.Sort<T>(graph);
		}

		private static Node<T> GetDependenciesGraph<T> (List<Dependency<T>> dependecies, Func<T, T, bool> equalDataComparer) {
			var graph = new Node<T> { EqualDataComparer = equalDataComparer };
			foreach (var d in dependecies) {
				var currentNode = graph.FindOrInsertChild(d.Current);
				if(d.Before != null) {
					foreach (var b in d.Before) {
						currentNode.AddChild(graph.FindOrInsertChild(b));
					}
				}
				if(d.After != null) {
					foreach (var a in d.After) {
						var parentNode = graph.FindOrInsertChild(a);
						parentNode.AddChild(currentNode);
					}
				}
			}
			return graph;
		}
	}
}

