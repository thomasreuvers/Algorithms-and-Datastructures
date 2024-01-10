#nullable disable
using BenchmarkDotNet.Attributes;
using DataStructures;

namespace Log.Benchmarks.Datastructures;

public class DequeBenchmarks : IBenchmark
{
	[Params(100, 1000, 10000)]
	public int Capacity { get; set; }
	
	private Deque<int> _deque;

	[IterationSetup]
	public void IterationSetup()
	{
		_deque = new Deque<int>(Capacity);

		for (var i = 0;  i < Capacity - 1; i++)
		{
			_deque.InsertLeft(i);
		}
	}

	[Benchmark]
	public void InsertLeftBenchmark()
	{
		_deque.InsertLeft(42);
	}

	[Benchmark]
	public void InsertRightBenchmark()
	{
		_deque.InsertRight(42);
	}
	
	[Benchmark]
	public void DeleteLeftBenchmark()
	{
		_deque.DeleteLeft();
	}
	
	[Benchmark]
	public void DeleteRightBenchmark()
	{
		_deque.DeleteRight();
	}
	
	[Benchmark]
	public int SizeBenchmark()
	{
		return _deque.Size();
	}
}