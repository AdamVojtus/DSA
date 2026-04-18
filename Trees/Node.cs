namespace Trees
{
    public class Node
    {
        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(int value, Node? left = null, Node? right = null)
        {
            if (left != null && left.Value >= value)
            {
                throw new ArgumentException("Left Node has to be less than the current node value.");
            }

            if (right != null && right.Value < value)
            {
                throw new ArgumentException("Right Node has to be more than the current node value.");
            }

            Value = value;
            Left = left;
            Right = right;
        }

        public static Node? CreateBalancedTree(int[] inputs)
        {
            int[] sortedInput = GetSortedValues(inputs);

            for (int i = 0; i < sortedInput.Length; i++)
            {
               if (sortedInput[i] > sortedInput.Length)
               {
                    return new Node(sortedInput[i], CreateBalancedTree(sortedInput[..i]), CreateBalancedTree(sortedInput[(i + 1)..]));
               }
            }

            return null;
        }

        public static int[] GetSortedValues(int[] input)
        {
            int[] sortedValues = (int[])input.Clone();

            Array.Sort(sortedValues);

            return sortedValues;
        }
    }
}