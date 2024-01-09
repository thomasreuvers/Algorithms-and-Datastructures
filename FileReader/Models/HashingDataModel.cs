using System.Text.Json.Serialization;
using DataStructures;

namespace FileReader.Models;

public class HashingDataModel
{
	[JsonPropertyName("hashtabelsleutelswaardes")]
	public HashTable<string, List<int>> HashTable { get; set; } = new();
}
