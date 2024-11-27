namespace SearchAlg;

public class Program
{
    public static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int target = 5;
        int result = RecursiveSearch(arr, target);
        // int result = BinarySearch(arr, target);
        Console.WriteLine(result);
    }

    public static int RecursiveSearch(int[] arr, int target, int i = 0)
    {
        if (arr[i] == target) return i;
        return RecursiveSearch(arr, target, i + 1);
    }

    public static int SentinelSearch(int[] arr, int target, int i = 0)
    {
        int last = arr[arr.Length - 1];
        arr[arr.Length - 1] = target;

        while (arr[i] != target) i++;
        arr[arr.Length - 1] = last;
        if (i < arr.Length - 1 || arr[arr.Length - 1] == target) return i;
        return -1;
    }

    public static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                return mid;
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}