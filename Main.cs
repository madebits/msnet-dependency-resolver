using System;
using System.Collections.Generic;
using DependecyResolver;

class MainClass	{

	public static void Main (string[] args) {

		var dependencies = new List<Dependency<int>> {
			new Dependency<int>{ Current = 5,  Before = { 2, 1 }, After = { 9, 7 } },
			new Dependency<int>{ Current = 2,  Before = { 3 }, After = { 9, 7 } },
			new Dependency<int>{ Current = 7,  Before = { 2, 1 }, After = { 9 } },
			new Dependency<int>{ Current = 9,  Before = { 2, 1 }, After = { } },
		};

		var result = Resolver.Resolve (dependencies, (a, b) => { return a == b; });

		foreach (var t in result) {
			Console.WriteLine(t);
		}

		Console.WriteLine("Done! Press Enter to continue ...");
		Console.ReadLine();
	}
}

