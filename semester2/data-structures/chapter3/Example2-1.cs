//Single Linked List

public class CustomSingleLinkedList<T>
{
    public class Node<T>
    {
        public T Element { get; set; }
        public Node<T> Next { get; set; }

        public Node(T element, Node<T> next)
        {
            Element = element;
            Next = next;
        }
    }
}