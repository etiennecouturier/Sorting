using System;
namespace sorter
{
    
    public class Program
    {

        static void Main(string[] args)
        {
            Input input = new Input();
            Sorting.Sort(input);
            foreach (int p in ExtractResult(input.GetData()))
                Console.WriteLine(p);
            Console.ReadLine();
        }

        private static int[] ExtractResult(string[] data)
        {
            int[] res = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                res[i] = data[i].Get<int>("id");
            }

            return res;
        }
    }
}
