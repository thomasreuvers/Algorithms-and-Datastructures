#nullable disable
using BenchmarkDotNet.Attributes;
using DataStructures;

namespace Log.Benchmarks.Datastructures;

public class DoublyLinkedListBenchmarks : IBenchmark
{
	[Params(100, 1000, 10000)]
	public int ListSize { get; set; }

	private DoublyLinkedList<int> _list;

	[IterationSetup]
	public void IterationSetup()
	{
		_list = new DoublyLinkedList<int>();

		for (var i = 0; i < ListSize; i++)
		{
			_list.Add(i);
		}
	}

	[Benchmark]
	public void AddBenchmark()
	{
		_list.Add(999);
	}

	[Benchmark]
	public int GetBenchmark()
	{
		var index = ListSize / 2;
		return _list.Get(index);
	}

	[Benchmark]
	public void SetBenchmark()
	{
		var index = ListSize / 2;
		_list.Set(index, 999);
	}

	[Benchmark]
	public void RemoveAtBenchmark()
	{
		var index = ListSize / 2;
		_list.Remove(index);
	}

	[Benchmark]
	public void RemoveBenchmark()
	{
		_list.Remove(element: 10);
	}

	[Benchmark]
	public bool ContainsBenchmark()
	{
		return _list.Contains(10);
	}

	[Benchmark]
	public int IndexOfBenchmark()
	{
		return _list.IndexOf(10);
	}
}