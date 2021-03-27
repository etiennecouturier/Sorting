using System;

namespace sorter
{
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
}
