using System;

namespace sorter
{
    public class Input
    {
        private Ordering[] orderings;
        private string[] data;

        public Input()
        {
            ReadInput();
        }

        private void ReadInput()
        {
            string orderingStr = Console.ReadLine();
            int numberOfCriteria = 0;
            foreach (char c in orderingStr)
                if (c == '+' || c == '-') numberOfCriteria++;

             orderings = new Ordering[numberOfCriteria];

            string fieldName = "";
            int j = -1;
            foreach (char c in orderingStr)
            {
                if (c == '+' || c == '-')
                {
                    if (j >= 0)
                    {
                        orderings[j].SetField(fieldName);
                    }
                    Ordering ordering = new Ordering();
                    ordering.SetAsc(c == '+' ? true : false);
                    orderings[++j] = ordering;
                    fieldName = "";
                }
                else
                {
                    fieldName += c;
                }
            }
            orderings[j].SetField(fieldName);

            data = new string[Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < data.Length; i++)
                data[i] = Console.ReadLine();
        }

        public Ordering[] GetOrdering()
        {
            return orderings;
        }

        public string[] GetData()
        {
            return data;
        }

    }
}
