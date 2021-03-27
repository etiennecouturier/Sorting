using System;

namespace sorter
{
    public class Sorting
    {

        public static T getAttr<T>(string line, string attrName)
        {
            foreach (string s in line.Split(','))
            {
                string[] k = s.Split(':');
                if (k[0] == attrName)
                {
                    return (T)Convert.ChangeType(k[1], typeof(T));
                }
            }
            return default(T);
        }

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
                    if (compareFunc(getAttr<T>(arr[i], attr), getAttr<T>(arr[i + 1], attr)))
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
            bool isInt = int.TryParse(getAttr<string>(arr[0], orderings[0].getField()), out intVal);
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
                if (getAttr<string>(arr[i], orderings[0].getField()) != getAttr<string>(arr[start], orderings[0].getField()))
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
