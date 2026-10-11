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

public interface ILinkedList<T>
{
    Node<T>? Remove(T data);
    Node<T>? RemoveFirst();
    Node<T>? RemoveLast();
    void AddAt(int i, T data);
    void AddFirst(T data);
    void AddLast(T data);
}

public class LinkedList<T> : ILinkedList<T>
{

    public Node<T>? Head { get; private set; }
    public Node<T>? Tail { get; private set; }
    public int Size { get; private set; }
    public LinkedList()
    {
        Head = null;
        Tail = null;
        Size = 0;
    }


    public void AddAt(int i, T data)
    {
        throw new NotImplementedException();
    }

    public void AddFirst(T data)
    {
        if (Head is null)
        {
            Head = new Node<T>(data);
            if (Tail is null)
                Tail = Head;
            return;
        }

        throw new NotImplementedException();
    }

    public void AddLast(T data)
    {
        throw new NotImplementedException();
    }

    public Node<T>? Remove(T data)
    {
        throw new NotImplementedException();
    }

    public Node<T>? RemoveFirst()
    {
        throw new NotImplementedException();
    }

    public Node<T>? RemoveLast()
    {
        throw new NotImplementedException();
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