using System.Text.Json.Serialization;

namespace FileReader.Models;

public class HashingDataModel
{
	[JsonPropertyName("hashtabelsleutelswaardes")]
	public Dictionary<string, List<int>> HashTableKeyValues { get; set; }
}