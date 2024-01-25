#nullable disable
namespace DataStructures;


public class Graph
{
	private readonly Dictionary<int, List<Edge>> _adjacencyList = new();

	public void AddVertex(int vertex)
	{
		if (!_adjacencyList.ContainsKey(vertex))
		{
			_adjacencyList[vertex] = new List<Edge>();
		}
	}

	public void RemoveVertex(int vertex)
	{
		if (!_adjacencyList.ContainsKey(vertex)) return;
		
		_adjacencyList.Remove(vertex);

		foreach (var vertices in _adjacencyList.Values)
		{
			vertices.RemoveAll(edge => edge.Target == vertex);
		}
	}
	
	public void AddEdge(int source, int target, int weight = 0)
	{
		if (_adjacencyList.ContainsKey(source) && _adjacencyList.ContainsKey(target))
		{
			var edge = new Edge(target, weight);
			_adjacencyList[source].Add(edge);
		}
		else
		{
			throw new ArgumentException("Source or target vertex does not exist");
		}
	}
	
	public void RemoveEdge(int source, int target)
	{
		if (_adjacencyList.ContainsKey(source))
		{
			_adjacencyList[source].RemoveAll(edge => edge.Target == target);
		}
	}

	public List<int> GetEdges(int vertex)
	{
		return !_adjacencyList.ContainsKey(vertex) ? null : _adjacencyList[vertex].Select(edge => edge.Target).ToList();
	}
	
	public int GetWeight(int source, int target)
	{
		if (!_adjacencyList.ContainsKey(source)) return -1;
		
		var edge = _adjacencyList[source].Find(e => e.Target == target);

		return edge?.Weight ?? -1;
	}

	public int GetVertex(int vertex)
	{
		return _adjacencyList.ContainsKey(vertex) ? vertex : -1;
	}

	private class Edge(int target, int weight)
	{
		public int Target { get; } = target;
		public int Weight { get; } = weight;
	}
}