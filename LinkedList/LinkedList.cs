namespace LinkedList
{
    public class Node<T>
    {
        public T Data;
        public Node<T>? Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T>
    {
        private Node<T>? head;

        public LinkedList()
        {
            head = null;
        }

        public void Push(T value)
        {
            var newNode = new Node<T>(value);
            newNode.Next = head;
            head = newNode;
        }

        public void Remove(T value)
        {
            if (head == null)
                throw new InvalidOperationException("Nodes are empty.");

            if (head.Data!.Equals(value))
            {
                head = head.Next;
                return;
            }

            var current = head;

            while (current.Next != null)
            {
                if (current.Next.Data!.Equals(value))
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }
        }

        public Node<T>? Head => head;

        public int Count
        {
            get
            {
                int count = 0;
                var current = head;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }
    }
}