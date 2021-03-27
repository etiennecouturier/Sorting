using System;

namespace sorter
{
    public class Sorting
    {
        static void BubbleSort<T>(
            string[] arr,
            string attr,
            int begin, int end,
            Func<T, T, bool> compareFunc
            ) where T : IComparable
        {
            for (int j = begin; j <= end - 2; j++)
            {
                for (int i = begin; i <= end - 2; i++)
                {
                    if (compareFunc(arr[i].getAttr<T>(attr), arr[i+1].getAttr<T>(attr)))
                    {
                        string temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }

        private static Ordering[] getNewOrderings(Ordering[] orderByAttrs)
        {
            Ordering[] newOrderByAttrs = new Ordering[orderByAttrs.Length - 1];
            Array.Copy(orderByAttrs, 1, newOrderByAttrs, 0, newOrderByAttrs.Length);
            return newOrderByAttrs;
        }

        private static bool isInt(string[] arr, Ordering[] orderings)
        {
            int intVal = 0;
            bool isInt = int.TryParse(arr[0].getAttr<string>(orderings[0].getField()), out intVal);
            return isInt;
        }

        public static void sortForAllCriteria(
            string[] arr,
            int begin, int end,
            Ordering[] orderings
            )
        {
            if (orderings.Length == 0) return;

            if (isInt(arr, orderings)) BubbleSort<int>(arr, orderings[0].getField(), begin, end, orderings[0].comp<int>());
            else BubbleSort<string>(arr, orderings[0].getField(), begin, end, orderings[0].comp<string>());

            int start = begin;
            for (int i = begin; i < end; i++)
            {
                if (arr[i].getAttr<string>(orderings[0].getField()) != arr[start].getAttr<string>(orderings[0].getField()))
                {
                    if ((i - start) > 1)
                        sortForAllCriteria(arr, start, i, getNewOrderings(orderings));
                    start = i;
                }
            }
        }

        public static void sort(string[] arr, Ordering[] orderings)
        {
            sortForAllCriteria(arr, 0, arr.Length, orderings);
        }

    }
}
