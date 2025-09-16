
namespace Stack
{
    public class Stack
    {
        private int count;
        private int[] items;

        public int Count => count;

        public Stack(int size = 10)
        {
            items = [size];
            count = 0;
        }

        public int Pop()
        {
            var item = items[count];
            Array.Clear(items, count, 1);
            count--;
            return item;
        }

        public void Push(int item)
        {
            if (items.Length == count)
            {
                Resize();
            }
            items[count] = item;
            count++;
        }

        private void Resize()
        {
            var newLength = count * 2;
            var newArray = new int[newLength];
            Array.Copy(items, newArray, count*2);
        }

        public static void Main(string[] args)
        {

        }
    }
}
