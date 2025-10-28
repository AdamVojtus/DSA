namespace DynamicArray
{
    public class DynamicArray
    {
        private int size;
        private int capacity = 10;
        private Object[] array;

        public int Size => size;

        public DynamicArray()
        {
            array = new Object[capacity];
        }

        public DynamicArray(int capacity)
        {
            this.capacity = capacity;
            array = new Object[capacity];
        }

        public void Add(Object value)
        {
            if (size>= capacity)
            {
                Grow();
            }
            array[size] = value;
            size++;
        }

        public void Insert(int index, Object value)
        {
            if(size>= capacity)
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

        public void Delete(Object value)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i] == value)
                {
                    for(int j = 0; j < (size - i - 1); j++)
                    {
                        array[i +j] = array[i + j + 1];
                    }
                    array[size - 1] = null;
                    size--;
                    if (size <=(int) (capacity/3))
                    {
                        Shrink();
                    }
                    break;
                }
            }
        }

        public int Search(Object value)
        {
            for (int i = 0; i < size; i++)
            {
                if(array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Grow()
        {
            int newCapacity = (int)(capacity * 2);
            Object[] newArray = new Object[newCapacity];

            for (int i = 0; i < size; i++)
            {
                newArray[i] = array[i];
            }
            capacity = newCapacity;
            array = newArray;
        }

        public void Shrink()
        {
            int newCapacity = (int)(capacity / 2);
            Object[] newArray = new Object[newCapacity];

            for (int i = 0; i < size; i++)
            {
                newArray[i] = array[i];
            }
            capacity = newCapacity;
            array = newArray;
        }
    }
}
