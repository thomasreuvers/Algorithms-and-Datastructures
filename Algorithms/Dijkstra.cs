namespace Algorithms;

public class Dijkstra
{
	// Dijkstra's algorithm for unweighted graph
    public static int[] DijkstraUnweighted(int[,] graph, int start)
    {
        var n = graph.GetLength(0);
        var distances = new int[n];
        var visited = new bool[n];

        for (var i = 0; i < n; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }

        distances[start] = 0;

        for (var count = 0; count < n - 1; count++)
        {
            var u = MinDistance(distances, visited);
            visited[u] = true;

            for (var v = 0; v < n; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                }
            }
        }

        return distances;
    }
    
    public static int[] DijkstraWeighted(int[,] graph, int start)
    {
        var n = graph.GetLength(0);
        var distances = new int[n];
        var visited = new bool[n];

        for (var i = 0; i < n; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }

        distances[start] = 0;

        for (var count = 0; count < n - 1; count++)
        {
            var u = MinDistance(distances, visited);
            visited[u] = true;

            for (var v = 0; v < n; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                }
            }
        }

        return distances;
    }

    // Helper function to find the vertex with the minimum distance value
    public static int MinDistance(int[] distances, bool[] visited)
    {
        var min = int.MaxValue;
        var minIndex = -1;

        for (var v = 0; v < distances.Length; v++)
        {
            if (!visited[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
}