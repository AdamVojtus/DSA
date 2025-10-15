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
            if (count == 0)
                throw new InvalidOperationException("Stack is empty.");

            count--;
            T item = items[count];
            items[count] = default!;
            return item;
        }

        public void Push(T item)
        {
            if (items.Length == count)
                Resize();

            items[count] = item;
            count++;
        }

        private void Resize()
        {
            int newLength = items.Length * 2;
            T[] newArray = new T[newLength];
            Array.Copy(items, newArray, count);
            items = newArray;
        }
    }
}
