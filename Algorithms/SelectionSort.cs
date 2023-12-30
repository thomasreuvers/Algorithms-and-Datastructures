namespace Algorithms;

public class SelectionSort
{
	public static void Sort<T>(IEnumerable<T> array) where T : IComparable<T>
	{
		var sortedArray = array.ToArray();

		for (var i = 0; i < sortedArray.Length - 1; i++)
		{
			var minIndex = i;

			for (var j = i + 1; j < sortedArray.Length; j++)
			{
				if (sortedArray[j].CompareTo(sortedArray[minIndex]) < 0)
				{
					minIndex = j;
				}
			}

			if (minIndex != i)
			{
				(sortedArray[i], sortedArray[minIndex]) = (sortedArray[minIndex], sortedArray[i]);
			}
		}
	}
}