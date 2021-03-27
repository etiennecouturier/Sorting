using System;

namespace sorter
{
    class Input
    {
        private Ordering[] orderings = new Ordering[4];
        private string[] data;

        public Input()
        {
            readInput();
        }

        private void readInput()
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
}
