namespace DynamicArray
{
    public class DynamicArray<T>
    {
        private int size;
        private int capacity;
        private T[] array;

        public int Size => size;

        public DynamicArray(int capacity)
        {
            this.capacity = capacity;
            array = new T[capacity];
        }

        public void Add(T value)
        {
            if (size >= capacity)
            {
                Grow();
            }
            array[size] = value;
            size++;
        }

        public void Insert(int index, T value)
        {
            if (size >= capacity)
            {
                Grow();
            }
            for (int i = size; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = value;
            size++;
        }

        public void Delete(T value)
        {
            for (int i = 0; i < size; i++)
            {
                if (Equals(array[i], value))
                {
                    for (int j = 0; j < size - i - 1; j++)
                    {
                        array[i + j] = array[i + j + 1];
                    }
                    array[size - 1] = default!;
                    size--;
                    if (size <= capacity / 3)
                    {
                        Shrink();
                    }
                    break;
                }
            }
        }

        public int Search(T value)
        {
            for (int i = 0; i < size; i++)
            {
                if (Equals(array[i], value))
                {
                    return i;
                }
            }
            return -1;
        }

        private void Grow()
        {
            int newCapacity = capacity * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < size; i++)
            {
                newArray[i] = array[i];
            }
            capacity = newCapacity;
            array = newArray;
        }

        public void Shrink()
        {
            int newCapacity = capacity / 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < size; i++)
            {
                newArray[i] = array[i];
            }
            capacity = newCapacity;
            array = newArray;
        }
    }
}
