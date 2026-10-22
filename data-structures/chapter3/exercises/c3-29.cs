using System.ComponentModel.DataAnnotations;

interface ICircularLinkedList<T>
{
    void Rotate();
}

interface IExercise<T>
{
    public bool IsSame(MyList<T> otherList);
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

public interface test<T>
{
    public void test();
}
public class MyList<T> : ICircularLinkedList<T>, ILinkedList<T>, IExercise<T>, test<T>
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
}