using DataStructures;
using FileReader;
using FileReader.Models;

namespace Log;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var jsonFileReader = new JsonFileReader();
		var data = await jsonFileReader.ReadFromFile<SortingDataModel>("data_sorteren.json");
	}
}