using System.Diagnostics;

namespace optimisation_developpement_tp3
{
    public class Program
    {
        public static void Main()
        {
            var sizes = new List<int> { 100, 1000, 10000 };
            var rnd = new Random();

            foreach (var size in sizes)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Size: {size}");

                var original = GenerateRandomList(size, rnd);

                // Préparer copies pour chaque algorithme
                var listForBubble = new List<int>(original);
                var listForMerge = new List<int>(original);

                // BubbleSort (tri en place) - mesurer le temps
                var sw = Stopwatch.StartNew();
                BubbleSort(listForBubble);
                sw.Stop();
                Console.WriteLine();
                Console.WriteLine($"BubbleSort durée : {sw.ElapsedMilliseconds} ms");
                Console.WriteLine($"BubbleSort aperçu : {Preview(listForBubble)}");

                // MergeSort - mesurer le temps
                sw.Restart();
                MergeSort(listForMerge);
                sw.Stop();
                Console.WriteLine();
                Console.WriteLine($"MergeSort durée : {sw.ElapsedMilliseconds} ms");
                Console.WriteLine($"MergeSort aperçu : {Preview(listForMerge)}");
            }
        }

        private static List<int> GenerateRandomList(int count, Random rnd)
        {
            var list = new List<int>(count);

            for (var i = 0; i < count; i++)
            {
                list.Add(rnd.Next(100000));
            }

            return list;
        }

        private static string Preview(List<int> list, int maxItems = 20)
        {
            if (list == null || list.Count == 0) return "<vide>";
            var take = Math.Min(maxItems, list.Count);
            return string.Join(", ", list.Take(take)) + (list.Count > take ? ", ..." : "");
        }

        private static void BubbleSort(List<int> list)
        {
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
        }

        private static void MergeSort(List<int> list)
        {
            // Merge Sort Algorithm
            var sortedList = MergeSortRecursive(list);

            // Copy back to original list
            list.Clear();
            list.AddRange(sortedList);
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