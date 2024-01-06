using System.Text.Json.Serialization;

namespace FileReader.Models;

public class SortingDataModel
{
	[JsonPropertyName("lijst_aflopend_2")]
	public required int[] DescendingList { get; set; }
	
	[JsonPropertyName("lijst_oplopend_2")]
	public required int[] AscendingList { get; set; }
	
	[JsonPropertyName("lijst_float_8001")]
	public required float[] FloatList { get; set; }
	
	[JsonPropertyName("lijst_gesorteerd_aflopend_3")]
	public required int[] SortedDescendingList { get; set; }
	
	[JsonPropertyName("lijst_gesorteerd_oplopend_3")]
	public required int[] SortedAscendingList { get; set; }
	
	[JsonPropertyName("lijst_herhaald_1000")]
	public required int[] RepeatedList { get; set; }
	
	[JsonPropertyName("lijst_leeg_0")]
	public required object[] EmptyList { get; set; }
	
	[JsonPropertyName("lijst_null_1")]
	public required object?[] NullList { get; set; }
	
	[JsonPropertyName("lijst_null_3")] 
	public required object?[] MultiTypeNullList { get; set; }
	
	[JsonPropertyName("lijst_onsorteerbaar_3")]
	public required object[] UnsortableList { get; set; }
	
	[JsonPropertyName("lijst_oplopend_10000")]
	public required int[] LargeAscendingList { get; set; }
	
	[JsonPropertyName("lijst_willekeurig_10000")]
	public required int[] LargeRandomList { get; set; }
	
	[JsonPropertyName("lijst_willekeurig_3")]
	public required int[] RandomList { get; set; }
}