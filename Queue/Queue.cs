namespace Queue
{
    public class Queue<T>
    {
        private int count;
        private T[] keys;

        public int Count => count;

        public Queue()
        {
            count = 4;
        }

        public void Enqueue(T key)
        {
            keys = new T[count];
            keys[count] = key;
            count--;
        }

        public T Dequeue()
        {
            var key = keys[count];
            Array.Clear(keys, count, 4);
            return key;
        }
    }
}