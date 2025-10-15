
namespace Queue
{
    public class Queue<T>
    {
        private int count;
        private T[] items;
        private int head;
        private int tail;

        public Queue(int size = 4)
        {
            items = new T[size];
            count = 0;
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)
        {
            if (count == items.Length)
            {
                Resize();
            }
            items[tail] = item;
            tail = (tail + 1);
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            T x = items[head];
            items[head] = default!;
            head = (head + 1) % items.Length;
            count--;
            return x;
        }

        private void Resize()
        {
            T[] newItems = new T[items.Length * 2];
            for (int i = 0; i < count; i++)
            {
                newItems[i] = items[(head + i) % items.Length];
            }
            items = newItems;
            head = 0;
            tail = count;
        }
    }
}
