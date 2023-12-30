namespace Algorithms;

public class MergeSort
{
	public static void Sort<T>(T[] array) where T : IComparable<T>
	{
		var sortedArray = new T[array.Length];
		Sort(array, sortedArray, 0, array.Length - 1);
	}
	
	private static void Sort<T>(T[] array, T[] sortedArray, int left, int right) where T : IComparable<T>
	{
		if (left >= right) return;
		
		var middle = (left + right) / 2;
		Sort(array, sortedArray, left, middle);
		Sort(array, sortedArray, middle + 1, right);
		Merge(array, sortedArray, left, middle, right);
	}
	
	private static void Merge<T>(IList<T> array, IList<T> sortedArray, int left, int middle, int right) where T : IComparable<T>
	{
		var leftIndex = left;
		var rightIndex = middle + 1;
		var sortedIndex = left;
		
		while (leftIndex <= middle && rightIndex <= right)
		{
			if (array[leftIndex].CompareTo(array[rightIndex]) <= 0)
			{
				sortedArray[sortedIndex] = array[leftIndex];
				leftIndex++;
			}
			else
			{
				sortedArray[sortedIndex] = array[rightIndex];
				rightIndex++;
			}

			sortedIndex++;
		}

		while (leftIndex <= middle)
		{
			sortedArray[sortedIndex] = array[leftIndex];
			leftIndex++;
			sortedIndex++;
		}

		while (rightIndex <= right)
		{
			sortedArray[sortedIndex] = array[rightIndex];
			rightIndex++;
			sortedIndex++;
		}

		for (var i = left; i <= right; i++)
		{
			array[i] = sortedArray[i];
		}
	}
}