namespace Trees
{
    public class Node
    {
        public int Value { get; }
        public Node? Left { get; }
        public Node? Right { get; }

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
            if (inputs == null || inputs.Length == 0) return null;

            int[] sorted = GetSortedValues(inputs);

            int mid = sorted.Length / 2;

            return new Node(
                sorted[mid],
                CreateBalancedTree(sorted[..mid]),
                CreateBalancedTree(sorted[(mid + 1)..])
            );
        }

        public static int[] GetSortedValues(int[] input) => input.OrderBy(x => x).ToArray();
    }
}