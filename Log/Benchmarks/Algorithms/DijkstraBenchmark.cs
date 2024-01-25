using Algorithms;
using BenchmarkDotNet.Attributes;

namespace Log.Benchmarks;

public class DijkstraBenchmarks : IBenchmark
{
	private int[,] graph;

	[Params(100, 1000, 10000)]
	public int N { get; set; }

	[GlobalSetup]
	public void Setup()
	{
		var rand = new Random();
		graph = new int[N, N];
		for (var i = 0; i < N; i++)
		{
			for (var j = 0; j < N; j++)
			{
				graph[i, j] = rand.Next(1, 100);
			}
		}
	}

	[Benchmark]
	public void UnweightedDijkstraBenchmark()
	{
		Dijkstra.DijkstraUnweighted(graph, 0);
	}

	[Benchmark]
	public void WeightedDijkstraBenchmark()
	{
		Dijkstra.DijkstraWeighted(graph, 0);
	}
}