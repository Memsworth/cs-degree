#!

public interface IExercise<T>
{
    public Node<T>? GetSecondLast();
}

public class Node<T>
{
    public Node<T>? Next { get; set; }
    public T Data { get; set; }

    public Node(T data)
    {
        Data = data;
    }
}

public class LinkedList<T> : IExercise<T>
{
    public int Size { get; private set; }
    private Node<T>? Head { get; set; }

    public LinkedList()
    {
        Head = null;
        Size = 0;
    }

    public void AddFirst(T newData)
    {
        if (Head is null)
        {
            Head = new Node<T>(newData);
        }
        else
        {
            var newNode = new Node<T>(newData)
            {
                Next = Head
            };
            Head = newNode;
        }
        Size++;
    }

    public void AddLast(T newData)
    {
        var newNode = new Node<T>(newData)
        {
            Next = null
        };

        if (Head is null)
            Head = newNode;
        else
        {
            var currentNode = Head;
            while (currentNode.Next is not null)
                currentNode = currentNode.Next;

            currentNode.Next = newNode;
        }
        Size++;
    }

    public Node<T>? RemoveFirst()
    {
        if (Head is null)
            return null;

        var currentHead = Head;
        Head = Head.Next;
        Size--;
        currentHead.Next = null;
        return currentHead;
    }

    public Node<T>? RemoveLast()
    {
        if (Head is null)
            return null;

        if (Size == 1)
        {
            var currentHead = Head;
            Size--;
            Head = null;
            return currentHead;
        }
        else
        {
            var target = Head;
            while (target.Next.Next is not null)
                target = target.Next;



            var currentTail = target.Next;
            target.Next = null;
            Size--;

            return currentTail;
        }
    }


    public Node<T>? GetSecondLast()
    {
        if (Size == 1 || Head is null)
            return null;

        var target = Head;
        while (target.Next.Next is not null)
            target = target.Next;

        return target;
    }
}