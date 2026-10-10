interface ICircularLinkedList<T>
{
    void Rotate();
    int GetSize();
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
        var newNode = new Node<T>(data);

        if (Tail == null)
        {
            Tail = newNode;
            Tail.Next = Tail;
        }
        else
        {
            newNode.Next = Tail.Next;
            Tail.Next = newNode;
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

    public int GetSize()
    {
        if (Tail is null)
            return 0;

        var currentNode = Tail.Next;
        var count = 0;
        while (currentNode.Next != Tail.Next)
        {
            currentNode = currentNode.Next;
            count++;
        }

    }
}
