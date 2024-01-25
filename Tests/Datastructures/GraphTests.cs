using DataStructures;
using FileReader;
using FileReader.Models;

namespace Tests.Datastructures;

[TestFixture]
public class GraphTests
{
	[Test]
	public async Task Can_Read_DataSet()
	{
		// Arrange
		var fileReader = new JsonFileReader();
		var data = await fileReader.ReadFromFileAsync<GraphDataModel>("dataset_grafen.json");
		var graph = new Graph();
		var vertices = data.EdgeArray.GetLength(0);
		
		// Act
		for (var i = 0; i < vertices; i++)
		{
			graph.AddVertex(i);
		}
		
		foreach (var item in data.EdgeArray)
		{
			graph.AddEdge(item[0], item[1]);
		}
		
		// Assert
		Assert.That(graph.GetEdges(1), Is.EqualTo(new List<int>
		{
			2,
			3
		}));
	}
	
	[Test]
	public async Task Read_Adjacency_Matrix()
	{
		// Arrange
		var fileReader = new JsonFileReader();
		var data = await fileReader.ReadFromFileAsync<GraphDataModel>("dataset_grafen.json");
		var graph = new Graph();
		var vertices = data.AdjacencyMatrix.GetLength(0);
			
		// Act
		for (var i = 0; i < vertices; i++)
		{
			graph.AddVertex(i);
		}

		for (var i = 0; i < vertices; i++)
		{
			for (var j = 0; j < vertices; j++)
			{
				if (data.AdjacencyMatrix[i][j] == 1)
				{
					graph.AddEdge(i, j);
				}
			}
		}
		
		// Assert
		Assert.That(graph.GetEdges(1), Is.EqualTo(new List<int>
		{
			0,
			2,
			3
		}));
	}

	[Test]
	public async Task Read_Weighted_Adjacency_List()
    {
        // Arrange
        var fileReader = new JsonFileReader();
		var data = await fileReader.ReadFromFileAsync<GraphDataModel>("dataset_grafen.json");
		var graph = new Graph();
		var vertices = data.WeightedAdjacencyList.GetLength(0);
		
		// Act
		for (var i = 0; i < vertices; i++)
		{
			graph.AddVertex(i);
		}

		for (var i = 0; i < vertices; i++)
		{
			for (var j = 0; j < data.WeightedAdjacencyList[i].GetLength(0); j++)
			{
				if(data.WeightedAdjacencyList[i][j].Length > 0)
				{
					graph.AddEdge(
						i, 
						data.WeightedAdjacencyList[i][j][0],
						data.WeightedAdjacencyList[i][j][1]);
				}
			}
		}

        // Assert
        Assert.Multiple(() =>
        {

            Assert.That(graph.GetEdges(1), Is.EqualTo(new List<int>
	        {
	            2,
	            3,
	            4
	        }));

            Assert.That(graph.GetWeight(1, 2), Is.EqualTo(50));
        });
    }
	
	[Test]
	public void RemoveVertex_RemovesVertexSuccessfully()
	{
		// Arrange
		var graph = new Graph();
		graph.AddVertex(1);

		// Act
		graph.RemoveVertex(1);

		// Assert
		Assert.That(graph.GetVertex(1), Is.Not.EqualTo(1));
	}
	
	[Test]
	public void RemoveEdge_RemovesEdgeSuccessfully()
	{
		// Arrange
		var graph = new Graph();
		graph.AddVertex(1);
		graph.AddVertex(2);
		graph.AddEdge(1, 2);

		// Act
		graph.RemoveEdge(1, 2);

		// Assert
		Assert.That(graph.GetEdges(1), Is.Empty);
	}

	[Test]
	public void AddEdge_ThrowsArgumentExceptionWhenSourceVertexDoesNotExist()
	{
		// Arrange
		var graph = new Graph();

		// Act & Assert
		Assert.Throws<ArgumentException>(() => graph.AddEdge(1, 2));
	}

	[Test]
	public void AddEdge_ThrowsArgumentExceptionWhenTargetVertexDoesNotExist()
	{
		// Arrange
		var graph = new Graph();
		graph.AddVertex(1);

		// Act & Assert
		Assert.Throws<ArgumentException>(() => graph.AddEdge(1, 2));
	}
}