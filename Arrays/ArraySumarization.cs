namespace Arrays
{
    public class ArraySumarization
    {
        public static bool DoesArrayContainsTwoNumbersSum(int[] inputs, int targetSum)
        { 
            var numbers = new HashSet<int>();

            for (int i = 0; i < inputs.Length; i++)
            {
                int diff = targetSum - inputs[i];
                if (numbers.Contains(diff))
                {
                    return true;
                }
                numbers.Add(inputs[i]);
            }
            return false;
        }
    }
}
