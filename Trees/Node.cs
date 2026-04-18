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
                throw new ArgumentException("Right Node has to be more or equal than the current node value.");
            }

            Value = value;
            Left = left;
            Right = right;
        }

        public static Node? CreateBalancedTree(int[] inputs)
        {
            if (inputs == null || inputs.Length == 0) return null;

            int[] sorted = inputs.OrderBy(x => x).ToArray();
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

        public bool IsValid()
        {
            return IsValidInternal(this, null, null);
        }

        private static bool IsValidInternal(Node? node, int? min, int? max)
        {
            if (node == null) return true;

            if ((min.HasValue && node.Value < min.Value) ||
                (max.HasValue && node.Value >= max.Value))
            {
                return false;
            }

            return IsValidInternal(node.Left, min, node.Value) &&
                   IsValidInternal(node.Right, node.Value, max);
        }

        public List<int> FlattenSorted()
        {
            var result = new List<int>();
            FillListRecursive(this, result);
            return result;
        }

        private static void FillListRecursive(Node? node, List<int> result)
        {
            if (node == null) return;

            FillListRecursive(node.Left, result);
            result.Add(node.Value);
            FillListRecursive(node.Right, result);
        }
    }
}