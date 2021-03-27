using System;

namespace sorter
{
    public static class StringExtension
    {
        public static T get<T>(this string line, string attrName)
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
    }
}
