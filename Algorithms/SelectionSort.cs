namespace Algorithms;

public class SelectionSort
{
	public static T[] Sort<T>(IEnumerable<T> array)
	{
		var sortedArray = array.ToArray();

		for (var i = 0; i < sortedArray.Length - 1; i++)
		{
			var minIndex = i;

			for (var j = i + 1; j < sortedArray.Length; j++)
			{
				if (Comparer<T>.Default.Compare(sortedArray[j],sortedArray[minIndex]) < 0)
				{
					minIndex = j;
				}
			}

			if (minIndex != i)
			{
				(sortedArray[i], sortedArray[minIndex]) = (sortedArray[minIndex], sortedArray[i]);
			}
		}

		return sortedArray;
	}
}