using System;
namespace sorter
{
    
    public class Program
    {

        static void Main(string[] args)
        {
            Input input = new Input();
            Sorting.sort(input);
            foreach (string p in input.getData())
                Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
