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

            if (right != null && right.Value <= value)
            {
                throw new ArgumentException("Right Node has to be strictly more than the current node value.");
            }

            Value = value;
            Left = left;
            Right = right;
        }

        public static Node? CreateBalancedTree(int[] inputs)
        {
            if (inputs == null || inputs.Length == 0) return null;

            int[] sorted = inputs.Distinct().OrderBy(x => x).ToArray();

            return BuildRecursive(sorted);
        }

        private static Node? BuildRecursive(int[] sorted)
        {
            if (sorted.Length == 0) return null;

            int mid = sorted.Length / 2;

            return new Node(
                sorted[mid],
                BuildRecursive(sorted[..mid]),
                BuildRecursive(sorted[(mid + 1)..])
            );
        }

        public static int[] GetSortedValues(int[] input) => input.Distinct().OrderBy(x => x).ToArray();

        public bool IsValid(int min = int.MinValue, int max = int.MaxValue)
        {
            if (Value < min || Value > max) return false;

            bool leftValid = Left == null || Left.IsValid(min, Value - 1);
            bool rightValid = Right == null || Right.IsValid(Value + 1, max);

            return leftValid && rightValid;
        }

        public List<int> FlattenSorted()
        {
            var result = new List<int>();

            if (Left != null) result.AddRange(Left.FlattenSorted());
            result.Add(Value);
            if (Right != null) result.AddRange(Right.FlattenSorted());

            return result;
        }
    }
}