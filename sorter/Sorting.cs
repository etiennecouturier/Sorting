using System;

namespace sorter
{
    public class Sorting
    {
        public static void Sort(Input input)
        {
            SortForAllCriteria(input.GetData(), 0, input.GetData().Length, 0, input.GetOrdering());
        }

        public static void sort(string[] arr, Ordering[] orderings)
        {
            SortForAllCriteria(arr, 0, arr.Length, 0, orderings);
        }

        private static void SortForAllCriteria(
            string[] arr,
            int begin, int end, int orderInd,
            Ordering[] orderings
            )
        {
            if (orderings.Length == orderInd) return;

            if (IsInt(arr, orderings[orderInd])) BubbleSort<int>(arr, orderings[orderInd].GetField(), begin, end, orderings[orderInd].Comp<int>());
            else BubbleSort<string>(arr, orderings[orderInd].GetField(), begin, end, orderings[orderInd].Comp<string>());

            int start = begin;
            for (int i = begin; i < end; i++)
            {
                if (arr[i].Get<string>(orderings[orderInd].GetField()) != arr[start].Get<string>(orderings[orderInd].GetField()))
                {
                    if ((i - start) > 1)
                        SortForAllCriteria(arr, start, i, ++orderInd, orderings);
                    start = i;
                }
            }
        }

        private static bool IsInt(string[] arr, Ordering ordering)
        {
            int intVal = 0;
            bool isInt = int.TryParse(arr[0].Get<string>(ordering.GetField()), out intVal);
            return isInt;
        }

        private static void BubbleSort<T>(
            string[] arr,
            string attr,
            int begin, int end,
            Func<T, T, bool> compareFunc
            )
        {
            for (int j = begin; j < end - 1; j++)
            {
                for (int i = begin; i < end - 1; i++)
                {
                    if (compareFunc(arr[i].Get<T>(attr), arr[i+1].Get<T>(attr)))
                    {
                        string temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }

    }
}
