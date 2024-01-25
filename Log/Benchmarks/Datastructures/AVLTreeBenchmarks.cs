using BenchmarkDotNet.Attributes;
using DataStructures;

namespace Log.Benchmarks.Datastructures;

public class AVLTreeBenchmarks : IBenchmark
{
	[Params(100, 1000, 10000)]
	public int TreeSize { get; set; }
	
	private AVLTree<int> _avlTree;

	[IterationSetup]
	public void IterationSetup()
	{
		_avlTree = new AVLTree<int>();

		for (var i = 0; i < TreeSize; i++)
		{
			_avlTree.Insert(i);
		}
	}

	[Benchmark]
	public void InsertBenchmark()
	{
		_avlTree.Insert(30000);
	}

	[Benchmark]
	public void RemoveBenchmark()
	{
		_avlTree.Remove(3);
	}

	[Benchmark]
	public void FindBenchmark()
	{
		_avlTree.Find(99);
	}
}