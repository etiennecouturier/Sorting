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

        public void SetField(string field)
        {
            this.field = field;
        }

        public void SetAsc(bool asc)
        {
            this.asc = asc;
        }
        public string GetField()
        {
            return field;
        }

        public bool IsAsc()
        {
            return asc;
        }

        public Func<T, T, bool> Comp<T>() where T : IComparable
        {
            if (asc)
                return (a, b) => a.CompareTo(b) > 0;
            return (a, b) => a.CompareTo(b) < 0;
        }
    }
}
