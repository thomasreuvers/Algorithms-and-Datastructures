using BenchmarkDotNet.Attributes;
using DataStructures;

namespace Log.Benchmarks.Datastructures;

public class GraphBenchmarks : IBenchmark
{
	[Params(100, 1000, 10000)]
	public int Vertices { get; set; }

	private Graph _graph;

	[IterationSetup]
	public void IterationSetup()
	{
		_graph = new Graph();
		for (var i = 0; i < Vertices; i++)
		{
			_graph.AddVertex(i);
		}
	}
	
	[Benchmark]
	public void AddVertexBenchmark()
	{
		_graph.AddVertex(1);
	}

	[Benchmark]
	public void RemoveVertexBenchmark()
	{
		_graph.RemoveVertex(1);
	}

	[Benchmark]
	public void AddEdgeBenchmark()
	{
		_graph.AddEdge(1, 2, 3);
	}

	[Benchmark]
	public void RemoveEdgeBenchmark()
	{
		_graph.RemoveEdge(1, 2);
	}

	[Benchmark]
	public List<int> GetEdgesBenchmark()
	{
		var edges =  _graph.GetEdges(1);
		return edges;
	}

	[Benchmark]
	public int GetWeightBenchmark()
	{
		var weight = _graph.GetWeight(1, 2);
		return weight;
	}

	[Benchmark]
	public int GetVertexBenchmark()
	{
		var vertex = _graph.GetVertex(1);
		return vertex;
	}
}