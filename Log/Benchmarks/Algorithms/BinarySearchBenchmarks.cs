using Algorithms;
using BenchmarkDotNet.Attributes;

namespace Log.Benchmarks;

public class BinarySearchBenchmarks : BaseBenchmark
{
	[Benchmark]
	public int BinarySearch_LargeAscendingList_Benchmark()
	{
		return BinarySearch.Search(Data.LargeAscendingList, 9910);
	}
	
	[Benchmark]
	public int BinarySearch_LargeRandomList_Benchmark()
	{
		return BinarySearch.Search(Data.LargeRandomList, 5846);
	}
	
	[Benchmark]
	public int BinarySearch_RepeatedList_Benchmark()
	{
		return BinarySearch.Search(Data.RepeatedList, -1);
	}
}