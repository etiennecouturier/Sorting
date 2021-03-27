using System;

namespace sorter
{
    public class Sorting
    {
        public static void sort(Input input)
        {
            sortForAllCriteria(input.getData(), 0, input.getData().Length, 0, input.getOrdering());
        }

        public static void sort(string[] arr, Ordering[] orderings)
        {
            sortForAllCriteria(arr, 0, arr.Length, 0, orderings);
        }

        private static void sortForAllCriteria(
            string[] arr,
            int begin, int end, int orderInd,
            Ordering[] orderings
            )
        {
            if (orderings.Length == orderInd) return;

            if (isInt(arr, orderings[orderInd])) BubbleSort<int>(arr, orderings[orderInd].getField(), begin, end, orderings[orderInd].comp<int>());
            else BubbleSort<string>(arr, orderings[orderInd].getField(), begin, end, orderings[orderInd].comp<string>());

            int start = begin;
            for (int i = begin; i < end; i++)
            {
                if (arr[i].get<string>(orderings[orderInd].getField()) != arr[start].get<string>(orderings[orderInd].getField()))
                {
                    if ((i - start) > 1)
                        sortForAllCriteria(arr, start, i, ++orderInd, orderings);
                    start = i;
                }
            }
        }

        private static bool isInt(string[] arr, Ordering ordering)
        {
            int intVal = 0;
            bool isInt = int.TryParse(arr[0].get<string>(ordering.getField()), out intVal);
            return isInt;
        }

        private static void BubbleSort<T>(
            string[] arr,
            string attr,
            int begin, int end,
            Func<T, T, bool> compareFunc
            ) where T : IComparable
        {
            for (int j = begin; j < end - 1; j++)
            {
                for (int i = begin; i < end - 1; i++)
                {
                    if (compareFunc(arr[i].get<T>(attr), arr[i+1].get<T>(attr)))
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
