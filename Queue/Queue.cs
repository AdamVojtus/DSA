namespace Queue
{
    public class Queue
    {
        private int count;
        private int[] keys;

        public int Count => count;

        public Queue()
        {
            count = 4;
        }

        public void Enqueue(int key)
        {
            keys = new int[count];
            keys[count] = key;
            count--;
        }

        public int Dequeue()
        {
            var key = keys[count];
            Array.Clear(keys, count, 4);
            return key;
        }

        public static void Main(string[] args)
        {
        }
    }
}