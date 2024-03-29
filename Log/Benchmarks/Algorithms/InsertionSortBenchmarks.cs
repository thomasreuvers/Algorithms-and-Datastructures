using Algorithms;
using BenchmarkDotNet.Attributes;

namespace Log.Benchmarks;

public class InsertionSortBenchmarks : BaseBenchmark
{
	/* Optimizations for the Insertion Sort algorithm:
	 * We can use a binary search to find the index where the element should be inserted.
	 * We could use a temporary variable for swapping instead of using tuple deconstruction.
	 */
	
	[Benchmark]
	public int[] InsertionSort_LargeRandomList_Benchmark()
	{
		var sortedList = MergeSort.Sort(Data.LargeRandomList);
		return sortedList;
	}
	
	[Benchmark]
	public float[] InsertionSort_FloatList_Benchmark()
	{
		var sortedList = InsertionSort.Sort(Data.FloatList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] InsertionSort_RandomList_Benchmark()
	{
		var sortedList = InsertionSort.Sort(Data.RandomList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] InsertionSort_RepeatedList_Benchmark()
	{
		var sortedList = InsertionSort.Sort(Data.RepeatedList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] InsertionSort_LargeAscendingList_Benchmark()
	{
		var sortedList = InsertionSort.Sort(Data.LargeAscendingList);
		return sortedList;
	}
}