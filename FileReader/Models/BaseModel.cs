using System.Text.Json.Serialization;

namespace FileReader.Models;

public class BaseModel
{
	[JsonPropertyName("lijst_aflopend_2")]
	public int[] AscendingList { get; set; } = Array.Empty<int>();
}