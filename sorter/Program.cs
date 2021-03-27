using System;
namespace sorter
{
    
    public class Program
    {

        static void Main(string[] args)
        {
            Input input = new Input();
            string[] arr = input.getData();

            Sorting.sort(arr, input.getOrdering());
            foreach (string p in arr)
                Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
