using Algorithms;
using BenchmarkDotNet.Attributes;

namespace Log.Benchmarks;

public class QuickSortBenchmarks : BaseBenchmark
{
	[Benchmark]
	public int[] QuickSort_LargeRandomList_Benchmark()
	{
		var sortedList = QuickSort.Sort(Data.LargeRandomList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] QuickSort_RandomList_Benchmark()
	{
		var sortedList = QuickSort.Sort(Data.RandomList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] QuickSort_RepeatedList_Benchmark()
	{
		var sortedList = QuickSort.Sort(Data.RepeatedList);
		return sortedList;
	}
	
	[Benchmark]
	public float[] QuickSort_FloatList_Benchmark()
	{
		var sortedList = QuickSort.Sort(Data.FloatList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] QuickSort_LargeAscendingList_Benchmark()
	{
		var sortedList = QuickSort.Sort(Data.LargeAscendingList);
		return sortedList;
	}
}