interface ICircularLinkedList<T>
{
    void Rotate();
}

interface ILinkedList<T>
{
    void AddFirst(T data);
    void AddLast(T data);
    T? RemoveFirst();
}

public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class MyList<T> : ICircularLinkedList<T>, ILinkedList<T>
{
    private Node<T>? Tail { get; set; }

    public int Size { get; private set; }

    public MyList()
    {
        Tail = null;
        Size = 0;
    }

    public void AddFirst(T data)
    {
        if (Tail == null)
        {
            Tail = new Node<T>(data);
            Tail.Next = Tail;
        }
        else
        {
            Tail.Next = new Node<T>(data)
            {
                Next = Tail.Next
            };
        }

        Size++;
    }

    public void AddLast(T data)
    {
        AddFirst(data);
        Tail = Tail!.Next;
    }

    public T? RemoveFirst()
    {
        if (Tail == null)
            return default;

        var head = Tail.Next!;

        if (head == Tail)
        {
            Tail = null;
        }
        else
        {
            Tail.Next = head.Next;
        }

        Size--;

        return head.Data;
    }

    public void Rotate()
    {
        if (Tail != null)
            Tail = Tail.Next;
    }
}
