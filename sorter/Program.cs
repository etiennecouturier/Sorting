using System;
namespace sorter
{
    class Input
    {
        private Ordering[] orderings = new Ordering[4];
        private string[] data;

        public void readInput()
        {
            string fieldName = "";
            int j = -1;
            foreach (char c in Console.ReadLine())
            {
                if (c == '+' || c == '-')
                {
                    if (j >= 0)
                    {
                        orderings[j].setField(fieldName);
                    }
                    Ordering ordering = new Ordering();
                    ordering.setAsc(c == '+' ? true : false);
                    orderings[++j] = ordering;
                    fieldName = "";
                }
                else
                {
                    fieldName += c;
                }
            }
            orderings[j].setField(fieldName);

            data = new string[Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < data.Length; i++)
                data[i] = Console.ReadLine();
        }

        public Ordering[] getOrdering()
        {
            return orderings;
        }

        public string[] getData()
        {
            return data;
        }

    }

    public class Ordering
    {
        private string field;
        private bool asc;

        public Ordering() { }
        public Ordering(string field, bool asc)
        {
            this.field = field;
            this.asc = asc;
        }

        public void setField(string field)
        {
            this.field = field;
        }

        public void setAsc(bool asc)
        {
            this.asc = asc;
        }
        public string getField()
        {
            return field;
        }

        public bool isAsc()
        {
            return asc;
        }

        public Func<T, T, bool> comp<T>() where T : IComparable
        {
            if (asc)
                return (a, b) => a.CompareTo(b) > 0;
            return (a, b) => a.CompareTo(b) < 0;
        }
    }

    public class Program
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

        static void Main(string[] args)
        {
            Input input = new Input();
            input.readInput();
            string[] arr = input.getData();

            sortForAllCriteria(arr, 0, arr.Length, input.getOrdering());
            foreach (string p in arr)
                Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
