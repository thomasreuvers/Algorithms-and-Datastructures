#nullable disable
using BenchmarkDotNet.Attributes;
using DataStructures;

namespace Log.Benchmarks.Datastructures;

public class PriorityQueueBenchmarks : IBenchmark
{
	[Params(100, 1000, 10000)]
	public int ListSize { get; set; }

	private PriorityQueue<int> _priorityQueue;

	[IterationSetup]
	public void IterationSetup()
	{
		_priorityQueue = new PriorityQueue<int>((x, y) => x.CompareTo(y));
		for (var i = 0; i < ListSize; i++)
		{
			_priorityQueue.Add(i);
		}
	}

	[Benchmark]
	public void AddBenchmark()
	{
		_priorityQueue.Add(42);
	}
	
	[Benchmark]
	public int PeekBenchmark()
	{
		return _priorityQueue.Peek();
	}
	
	[Benchmark]
	public int PollBenchmark()
	{
		return _priorityQueue.Poll();
	}
}