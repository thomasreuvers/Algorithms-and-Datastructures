using BenchmarkDotNet.Attributes;

namespace Log.Benchmarks.Datastructures;

public class StackBenchmarks : IBenchmark
{
	[Params(100, 1000, 10000)]
	public int Capacity { get; set; }
	
	private DataStructures.Stack<int> _stack = null!;

	[IterationSetup]
	public void IterationSetup()
	{
		_stack = new DataStructures.Stack<int>(Capacity);

		for (var i = 0;  i < Capacity - 1; i++)
		{
			_stack.Push(i);
		}
	}

	[Benchmark]
	public void PushBenchmark()
	{
		_stack.Push(5);
	}
	
	[Benchmark]
	public void PopBenchmark()
	{
		_stack.Pop();
	}
	
	[Benchmark]
	public void TopBenchmark()
	{
		_stack.Top();
	}

	[Benchmark]
	public bool IsEmptyBenchmark()
	{
		return _stack.IsEmpty();
	}

	[Benchmark]
	public int SizeBenchmark()
	{
		return _stack.Size();
	}
}