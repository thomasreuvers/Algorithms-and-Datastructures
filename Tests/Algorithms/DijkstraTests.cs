using Algorithms;

namespace Tests.Algorithms;

[TestFixture]
public class DijkstraTests
{
	[Test]
	public void DijkstraUnweighted_Test()
	{
		// Arrange
		int[,] graph = {
			{0, 1, 4, 0, 0},
			{1, 0, 2, 5, 0},
			{4, 2, 0, 1, 0},
			{0, 5, 1, 0, 3},
			{0, 0, 0, 3, 0}
		};

		// Act
		int[] result = Dijkstra.DijkstraUnweighted(graph, 0);

		// Assert
		Assert.AreEqual(new int[] { 0, 1, 3, 4, 7 }, result);
	}

	[Test]
	public void DijkstraWeighted_Test()
	{
		// Arrange
		int[,] graph = {
			{0, 1, 4, 0, 0},
			{1, 0, 2, 5, 0},
			{4, 2, 0, 1, 0},
			{0, 5, 1, 0, 3},
			{0, 0, 0, 3, 0}
		};

		// Act
		int[] result = Dijkstra.DijkstraWeighted(graph, 0);

		// Assert
		Assert.AreEqual(new int[] { 0, 1, 3, 4, 7 }, result);
	}
}