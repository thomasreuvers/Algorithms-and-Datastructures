namespace Algorithms;

public class BinarySearch
{
	public static int Search<T>(T[] array, T value)
	{
		var left = 0;
		var right = array.Length - 1;

		while (left <= right)
		{
			var middle = (left + right) / 2;
			var comparison = Comparer<T>.Default.Compare(value, array[middle]);

			switch (comparison)
			{
				case 0:
					return middle;
				case < 0:
					right = middle - 1;
					break;
				default:
					left = middle + 1;
					break;
			}
		}

		return -1;
	}
}