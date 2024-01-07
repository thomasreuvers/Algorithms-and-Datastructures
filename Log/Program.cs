﻿using BenchmarkDotNet.Running;
using Log.Benchmarks;

namespace Log;

public static class Program
{
	public static void Main(string[] args)
	{
		// Run all benchmarks:
		// BenchmarkRunner.Run(typeof(BaseBenchmark).Assembly);
		
		// Choose which set of benchmarks to run:
		var switcher = BenchmarkSwitcher.FromAssembly(typeof(BaseBenchmark).Assembly);
		switcher.Run(args);
	}
}