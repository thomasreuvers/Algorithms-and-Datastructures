using DataStructures;
using FileReader;
using FileReader.Models;

namespace Log;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var jsonFileReader = new JsonFileReader();
		var data = await jsonFileReader.ReadFromFile<BaseModel>("data_sorteren.json");

		var dynamicArray = new DynamicArray();
		foreach (var item in data.AscendingList)
		{
			dynamicArray.Add(item);
		}
		
		Console.WriteLine("Reach");
	}
}