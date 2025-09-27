
namespace Stack
{
    public class Stack<T>
    {
        private int count;
        private T[] items;

        public int Count => count;

        public Stack(int size = 10)
        {
            items = new T[size];
            count = 0;
        }

        public T Pop()
        {
            var item = items[count];
            Array.Clear(items, count, 1);
            count--;
            return item;
        }

        public void Push(T item)
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
            var newArray = new T[newLength];
            Array.Copy(items, newArray, count*2);
        }
    }
}
