using System;
namespace sorter
{
    
    public class Program
    {

        static void Main(string[] args)
        {
            Input input = new Input();
            Sorting.Sort(input);
            foreach (string p in input.GetData())
                Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
