using Algorithms;
using BenchmarkDotNet.Attributes;

namespace Log.Benchmarks;

public class MergeSortBenchmarks : BaseBenchmark
{
	[Benchmark]
	public void Merge_Benchmark()
	{
		var array = Data.RandomList;
		var sortedArray = new int[array.Length];
		MergeSort.Merge(array, sortedArray, 0, array.Length / 2, array.Length - 1);
	}

	[Benchmark]
	public int[] MergeSort_LargeRandomList_Benchmark()
	{
		var sortedList = MergeSort.Sort(Data.LargeRandomList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] MergeSort_RandomList_Benchmark()
	{
		var sortedList = MergeSort.Sort(Data.RandomList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] MergeSort_RepeatedList_Benchmark()
	{
		var sortedList = MergeSort.Sort(Data.RepeatedList);
		return sortedList;
	}
	
	[Benchmark]
	public float[] MergeSort_FloatList_Benchmark()
	{
		var sortedList = MergeSort.Sort(Data.FloatList);
		return sortedList;
	}
	
	[Benchmark]
	public int[] MergeSort_LargeAscendingList_Benchmark()
	{
		var sortedList = MergeSort.Sort(Data.LargeAscendingList);
		return sortedList;
	}
}