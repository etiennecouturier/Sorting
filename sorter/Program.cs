using System;
namespace sorter
{
    
    public class Program
    {

        static void Main(string[] args)
        {
            Input input = new Input();
            input.readInput();
            string[] arr = input.getData();

            Sorting.sortForAllCriteria(arr, 0, arr.Length, input.getOrdering());
            foreach (string p in arr)
                Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
