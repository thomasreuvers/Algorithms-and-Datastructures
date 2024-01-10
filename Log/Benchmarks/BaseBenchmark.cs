using BenchmarkDotNet.Attributes;
using FileReader;
using FileReader.Models;

namespace Log.Benchmarks;

[MemoryDiagnoser]
public abstract class BaseBenchmark : IBenchmark
{
	protected SortingDataModel Data = null!;
	
	[GlobalSetup]
	public virtual async Task Setup()
	{
		var fileReader = new JsonFileReader();
		Data = await fileReader.ReadFromFileAsync<SortingDataModel>("dataset_sorteren.json");
	}
}