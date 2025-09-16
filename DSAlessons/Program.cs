using System.Collections;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            if (stack.Count < 0)
            {
                throw new Exception();
            }

            Console.WriteLine(stack.Peek());

            PrintValues(stack);

            static void PrintValues(IEnumerable myCollection) // This function was here brought trough docs, not StackOverflow or AI
            {
                foreach (Object obj in myCollection)
                    Console.Write("    {0}", obj);
                Console.WriteLine();
            }
        }
    }
}