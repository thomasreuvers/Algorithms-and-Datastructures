using BenchmarkDotNet.Attributes;
using FileReader;
using FileReader.Models;

namespace Log.Benchmarks;

[MemoryDiagnoser]
public abstract class BaseBenchmark
{
	protected SortingDataModel Data = null!;
	
	[GlobalSetup]
	public async Task Setup()
	{
		var fileReader = new JsonFileReader();
		Data = await fileReader.ReadFromFileAsync<SortingDataModel>("data_sorteren.json");
	}
}