interface ICircularLinkedList<T>
{
    void Rotate();
}

interface IExercise<T>
{
    MyList<T>? Split();
}

interface ILinkedList<T>
{
    void AddFirst(T data);
    void AddLast(T data);
    T? RemoveFirst();
    bool IsSame(MyList<T> otherList);

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

public class MyList<T> : ICircularLinkedList<T>, ILinkedList<T>, IExercise<T>
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

    public bool IsSame(MyList<T> otherList)
    {
        ArgumentNullException.ThrowIfNull(otherList);

        if (Size != otherList.Size)
            return false;

        if (Size == 0)
            return true;

        var start = Tail.Next;
        var candidate = otherList.Tail.Next;

        // Try every possible starting point in otherList
        do
        {
            if (EqualityComparer<T>.Default.Equals(start.Data, candidate.Data))
            {
                var current = start;
                var other = candidate;
                bool isSame = true;

                for (int i = 0; i < Size; i++)
                {
                    if (!EqualityComparer<T>.Default.Equals(current.Data, other.Data))
                    {
                        isSame = false;
                        break;
                    }

                    current = current.Next;
                    other = other.Next;
                }

                if (isSame)
                    return true;
            }

            candidate = candidate.Next;
        }
        while (candidate != otherList.Tail.Next);

        return false;
    }


    public MyList<T>? Split()
    {
        if (Size == 0 || Size % 2 != 0)
            return null;

        var headOne = Tail.Next;
        int halfSize = Size / 2;

        var mid = headOne;
        for (int i = 1; i < halfSize; i++)
            mid = mid.Next;

        var headTwo = mid.Next;
        var oldTail = Tail;

        mid.Next = headOne;
        oldTail.Next = headTwo;

        Tail = mid;
        Size = halfSize;

        // Create the second list using the existing nodes.
        var secondList = new MyList<T>
        {
            Tail = oldTail,
            Size = halfSize
        };

        return secondList;
    }
}