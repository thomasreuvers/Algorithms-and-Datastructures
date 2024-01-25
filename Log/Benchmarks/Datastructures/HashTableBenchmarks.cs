using BenchmarkDotNet.Attributes;
using DataStructures;

namespace Log.Benchmarks.Datastructures;

public class HashTableBenchmarks : IBenchmark
{
	[Params(100, 1000, 10000)]
	public int ListSize { get; set; }

	private HashTable<int> _table;

	[IterationSetup]
	public void IterationSetup()
	{
		_table = new HashTable<int>();

		for (var i = 0; i < ListSize; i++)
		{
			_table.Insert(i.ToString(), i);
		}
	}
	
	[Benchmark]
	public void InsertBenchmark()
	{
		_table.Insert("5", 2);
	}

	[Benchmark]
	public int GetBenchmark()
	{
		return _table.Get("5");
	}

	[Benchmark]
	public void DeleteBenchmark()
	{
		_table.Delete("6");
	}

	[Benchmark]
	public void UpdateBenchmark()
	{
		_table.Update("1", 10);
	}
}