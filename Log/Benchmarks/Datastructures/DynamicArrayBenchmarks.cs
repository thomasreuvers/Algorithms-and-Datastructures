#nullable disable
using BenchmarkDotNet.Attributes;
using DataStructures;

namespace Log.Benchmarks.Datastructures;

public class DynamicArrayBenchmarks : IBenchmark
{
	[Params(100, 1000, 10000)]
	public int ListSize { get; set; }

	private DynamicArray<int> _dynamicArray;

	[IterationSetup]
	public void IterationSetup()
	{
		_dynamicArray = new DynamicArray<int>();
		for (var i = 0; i < ListSize; i++)
		{
			_dynamicArray.Add(i);
		}
	}

	[Benchmark]
	public void InsertBenchmark()
	{
		_dynamicArray.Add(42);
	}
	
	[Benchmark]
	public void SetBenchmark()
	{
		_dynamicArray.Set(ListSize / 2, 42);
	}
	
	[Benchmark]
	public int GetBenchmark()
	{
		return _dynamicArray.Get(ListSize / 2);
	}

	[Benchmark]
	public void RemoveByIndexBenchmark()
	{
		_dynamicArray.Remove(ListSize / 2);
	}
	
	[Benchmark]
	public void RemoveByElementBenchmark()
	{
		_dynamicArray.Remove(element: 10);
	}

	[Benchmark]
	public int SizeBenchmark()
	{
		return _dynamicArray.Size();
	}
	
	[Benchmark]
	public bool ContainsBenchmark()
	{
		return _dynamicArray.Contains(10);
	}
	
	[Benchmark]
	public int IndexOfBenchmark()
	{
		return _dynamicArray.IndexOf(10);
	}
}