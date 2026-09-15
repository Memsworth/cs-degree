#!

public class Node<T>
{
    public Node<T>? Next { get; set; }
    public T Data { get; set; }

    public Node(T data)
    {
        Data = data;
    }
}

public class NewLinkedList<T>
{
    public int Size { get; private set; }
    private Node<T>? Head { get; set; }
    private Node<T>? Tail { get; set; }

    public NewLinkedList()
    {
        Head = null;
        Tail = null;
        Size = 0;
    }

    public void AddFirst(T newData)
    {
        var newNode = new Node<T>(newData)
        {
            Next = Head
        };
        Head = newNode;
        if (Tail is null)
            Tail = newNode;
        Size++;
    }

    public void AddLast(T newData)
    {
        var newNode = new Node<T>(newData)
        {
            Next = null
        };

        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail!.Next = newNode;
            Tail = newNode;
        }
        Size++;
    }

    public Node<T>? RemoveFirst()
    {
        if (Head is null)
            return null;

        var currentHead = Head;
        Head = Head.Next;
        if (Head is null)
            Tail = null;
        Size--;
        currentHead.Next = null;
        return currentHead;
    }

    public Node<T>? First() => Head;
    public Node<T>? Last() => Tail;
    public bool IsEmpty() => Size == 0;

}