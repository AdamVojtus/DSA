namespace LinearSearch
{
    public class LinearSearch<T>
    {
        public static bool Search(T value, T[] array, out T? result)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (Equals(array[i], value))
                {
                    result = array[i];
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}
