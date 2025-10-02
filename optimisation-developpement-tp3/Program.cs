namespace optimisation_developpement_tp3
{
    public class Program
    {
        public static void Main()
        {
            BubbleSort();
            MergeSort();
        }

        private static void BubbleSort()
        {
            // Example list to sort
            var list = new List<int> { 8, 2, 9, 4, 1 };

            // Bubble Sort Algorithm
            for (var i = 0; i < list.Count - 1; i++)
            {
                // Last i elements are already sorted
                for (var j = 0; j < list.Count - i - 1; j++)
                {
                    // Swap if the element found is greater than the next element
                    if (list[j] > list[j + 1])
                    {
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    }
                }
            }

            Console.WriteLine("BubbleSort: " + string.Join(", ", list));
        }

        private static void MergeSort()
        {
            // Example list to sort
            var list = new List<int> { 37, 12, 5, 21, 6, 19, 4 };

            // Merge Sort Algorithm
            var sortedList = MergeSortRecursive(list);

            Console.WriteLine("MergeSort: " + string.Join(", ", sortedList));
        }

        private static List<int> MergeSortRecursive(List<int> list)
        {
            // Base case
            if (list.Count <= 1)
                return list;

            // Split the list into halves and merge sort each half
            var mid = list.Count / 2;
            var left = MergeSortRecursive(list.GetRange(0, mid));
            var right = MergeSortRecursive(list.GetRange(mid, list.Count - mid));

            // Merging two sorted lists
            var result = new List<int>();

            // Indices for left and right lists
            var i = 0;
            var j = 0;

            // Merge until one list is exhausted
            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            // Append any remaining elements
            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }
            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }
    }
}