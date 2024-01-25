using System.Text.Json.Serialization;

namespace FileReader.Models;

public class GraphDataModel
{
	[JsonPropertyName("lijnlijst")] 
	public int[][] EdgeArray { get; set; }
	
	[JsonPropertyName("verbindingslijst")]
	public int[][] AdjacencyList { get; set; }
	
	[JsonPropertyName("verbindingsmatrix")]
	public int[][] AdjacencyMatrix { get; set; }
	
	[JsonPropertyName("lijnlijst_gewogen")]
	public int[][] WeightedEdgeArray { get; set; }
	
	[JsonPropertyName("verbindingslijst_gewogen")]
	public int[][][] WeightedAdjacencyList { get; set; }
	
	[JsonPropertyName("verbindingsmatrix_gewogen")]
	public int[][] CostAdjacencyMatrix { get; set; }
}