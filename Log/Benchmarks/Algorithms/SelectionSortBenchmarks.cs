using Algorithms;
using BenchmarkDotNet.Attributes;

namespace Log.Benchmarks;

public class SelectionSortBenchmarks : BaseBenchmark
{
	[Benchmark]
	public int[] SelectionSort_LargeRandomList_Benchmark()
	{
		var sortedList = SelectionSort.Sort(Data.LargeRandomList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] SelectionSort_RandomList_Benchmark()
	{
		var sortedList = SelectionSort.Sort(Data.RandomList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] SelectionSort_RepeatedList_Benchmark()
	{
		var sortedList = SelectionSort.Sort(Data.RepeatedList);
		return sortedList;
	}
	
	[Benchmark]
	public float[] SelectionSort_FloatList_Benchmark()
	{
		var sortedList = SelectionSort.Sort(Data.FloatList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] SelectionSort_LargeAscendingList_Benchmark()
	{
		var sortedList = SelectionSort.Sort(Data.LargeAscendingList);
		return sortedList;
	}
}