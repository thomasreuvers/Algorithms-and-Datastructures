#nullable disable
namespace DataStructures;

public class Edge(int toVertex, int fromVertex, int weight)
{
	public int ToVertex { get; set; } = toVertex;
	public int FromVertex { get; set; } = fromVertex;
	public int Weight { get; set; } = weight;
}

public class Graph
{
	private Dictionary<int, List<Edge>> _adjacencyList = new();
	private HashSet<int> _vertices = new(); // Using a HashSet for vertices and a Dictionary for adjacency lists provides a balance between storage efficiency and efficient access. The HashSet ensures that only unique vertices are stored, which reduces memory usage. The Dictionary allows for efficient lookups of neighbors and edge weights.
	
	public void AddVertex(int vertex)
	{
		if(_vertices.Contains(vertex)) throw new Exception("Vertex already exists");

		_vertices.Add(vertex);
		_adjacencyList[vertex] = new List<Edge>();
	}
	
	public void RemoveVertex(int vertex)
	{
		if(!_vertices.Remove(vertex)) throw new Exception("Vertex does not exist");

		foreach(var edge in _adjacencyList[vertex])
		{
			_adjacencyList[edge.ToVertex].Remove(edge);
		}
		
		_adjacencyList.Remove(vertex);
	}

	public void AddEdge(int fromVertex, int toVertex, int weight = 0)
	{
		if (!_vertices.Contains(fromVertex) || !_vertices.Contains(toVertex)) return;
		
		var edge = new Edge(fromVertex, toVertex, weight);
		_adjacencyList[fromVertex].Add(edge);
	}
	
	public void RemoveEdge(int fromVertex, int toVertex)
	{
		if (_adjacencyList.TryGetValue(fromVertex, out var value))
		{
            value.RemoveAll(edge => edge.ToVertex == toVertex);
		}
	}
}