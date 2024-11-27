namespace Sort;

using System;

class Program
{
    // Swap method
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    // Selection Sort
    public static void SelectionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                    minIndex = j;
            }
            Swap(array, i, minIndex);
        }
    }

    // Exchange Sort
    public static void ExchangeSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (array[i] > array[j])
                {
                    Swap(array, i, j);
                }
            }
        }
    }

    // Insertion Sort
    public static void InsertionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }

    // Bubble Sort
    public static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }

    // Quick Sort
    public static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);
            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }
        Swap(array, i + 1, high);
        return i + 1;
    }

    // Merge Sort
    public static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);
            Merge(array, left, mid, right);
        }
    }

    private static void Merge(int[] array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];
        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, mid + 1, rightArray, 0, n2);

        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
                array[k++] = leftArray[i++];
            else
                array[k++] = rightArray[j++];
        }
        while (i < n1) array[k++] = leftArray[i++];
        while (j < n2) array[k++] = rightArray[j++];
    }

    // Shell Sort
    public static void ShellSort(int[] array)
    {
        int n = array.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j;
                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                {
                    array[j] = array[j - gap];
                }
                array[j] = temp;
            }
        }
    }

    // Heap Sort
    public static void HeapSort(int[] array)
    {
        int n = array.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i);
        for (int i = n - 1; i > 0; i--)
        {
            Swap(array, 0, i);
            Heapify(array, i, 0);
        }
    }

    private static void Heapify(int[] array, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && array[left] > array[largest])
            largest = left;
        if (right < n && array[right] > array[largest])
            largest = right;

        if (largest != i)
        {
            Swap(array, i, largest);
            Heapify(array, n, largest);
        }
    }

    // Main method for testing
    static void Main()
    {
        int[] array = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(", ", array));

        // Testing each sorting algorithm
        int[] testArray;

        testArray = (int[])array.Clone();
        SelectionSort(testArray);
        Console.WriteLine("Selection Sort:");
        Console.WriteLine(string.Join(", ", testArray));

        testArray = (int[])array.Clone();
        ExchangeSort(testArray);
        Console.WriteLine("Exchange Sort:");
        Console.WriteLine(string.Join(", ", testArray));

        testArray = (int[])array.Clone();
        InsertionSort(testArray);
        Console.WriteLine("Insertion Sort:");
        Console.WriteLine(string.Join(", ", testArray));

        testArray = (int[])array.Clone();
        BubbleSort(testArray);
        Console.WriteLine("Bubble Sort:");
        Console.WriteLine(string.Join(", ", testArray));

        testArray = (int[])array.Clone();
        QuickSort(testArray, 0, testArray.Length - 1);
        Console.WriteLine("Quick Sort:");
        Console.WriteLine(string.Join(", ", testArray));

        testArray = (int[])array.Clone();
        MergeSort(testArray, 0, testArray.Length - 1);
        Console.WriteLine("Merge Sort:");
        Console.WriteLine(string.Join(", ", testArray));

        testArray = (int[])array.Clone();
        ShellSort(testArray);
        Console.WriteLine("Shell Sort:");
        Console.WriteLine(string.Join(", ", testArray));

        testArray = (int[])array.Clone();
        HeapSort(testArray);
        Console.WriteLine("Heap Sort:");
        Console.WriteLine(string.Join(", ", testArray));
    }
}
