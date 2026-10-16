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

public interface IExercise<T>
{
    public void Concat(LinkedList<T> newList);
}
public interface ILinkedList<T>
{
    Node<T>? Remove(T data);
    Node<T>? RemoveAt(int i);
    Node<T>? RemoveFirst();
    Node<T>? RemoveLast();
    void AddAt(int i, T data);
    void AddFirst(T data);
    void AddLast(T data);
}

public class LinkedList<T> : ILinkedList<T>, IExercise<T>
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

    public override string ToString()
    {
        var currentNode = Head;
        if (currentNode is not null)
        {
            var source = "";
            while (currentNode != null)
            {
                source += $"{currentNode.Data} -> ";
                currentNode = currentNode.Next;
            }
            return source;
        }
        return "LinkedList is empty";
    }
    public void AddAt(int i, T data)
    {
        if (Size < i || i < 0)
            throw new ArgumentOutOfRangeException();

        var newNode = new Node<T>(data);

        //If at start or empty
        if (i == 0)
        {
            //if empty
            if (Head is null)
            {
                Head = newNode;
                if (Tail is null)
                    Tail = Head;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            Size++;
            return;
        }

        var currentNode = Head;

        //Go to index - 1
        for (int j = 0; j < i - 1; j++)
            currentNode = currentNode.Next;



        //No need to restrict
        newNode.Next = currentNode.Next;
        currentNode.Next = newNode;
        if (newNode.Next is null)
            Tail = newNode;

        Size++;
    }

    public void AddFirst(T data) => AddAt(0, data);
    public void AddLast(T data) => AddAt(Size, data);

    public Node<T>? Remove(T data)
    {
        if (Size == 0)
            return null;

        var currentNode = Head;
        var previousNode = Head;

        while (currentNode is not null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.Data, data))
            {
                //if data is head
                if (currentNode == Head)
                {
                    //Head == Tail
                    if (Head == Tail)
                    {
                        Head = null;
                        Tail = null;
                    }
                    else
                    {
                        var toHead = Head.Next;
                        Head.Next = null;
                        Head = toHead;
                    }
                    Size--;
                    return currentNode;
                }

                //if data is in tail
                else if (currentNode == Tail)
                {
                    previousNode.Next = null;
                    Tail = previousNode;
                    Size--;
                    return currentNode;
                }
                //delete from mid
                else
                {
                    previousNode.Next = currentNode.Next;
                    currentNode.Next = null;
                    Size--;
                    return currentNode;
                }
            }
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }
        return null;
    }

    public Node<T>? RemoveAt(int i)
    {
        if (i < 0 || i >= Size)
            throw new ArgumentOutOfRangeException(nameof(i));

        if (i == 0)
        {
            if (Head is null)
                return null;

            var removedHead = Head;

            if (Head == Tail)
            {
                removedHead.Next = null;
                Head = Tail = null;
            }
            else
            {
                Head = Head.Next;
                removedHead.Next = null;
            }
            Size--;
            return removedHead;
        }

        // Remove the head
        var previousNode = Head;
        var currentNode = Head;

        // Go to the node before index i
        for (int j = 0; j < i - 1; j++)
            previousNode = previousNode.Next;

        currentNode = previousNode.Next;


        if (currentNode == Tail)
        {
            previousNode.Next = null;
            Tail = previousNode;
        }
        else
        {
            previousNode.Next = currentNode.Next;
            currentNode.Next = null;
        }
        Size--;
        return currentNode;
    }
    public Node<T>? RemoveFirst() => RemoveAt(0);
    public Node<T>? RemoveLast() => RemoveAt(Size - 1);

    public void Concat(LinkedList<T> newList)
    {
        if (newList is null)
            throw new ArgumentNullException($"{nameof(newList)}");
        if (newList == this)
            throw new ArgumentException("What the actual F are you doing?");
        if (newList.Head is null)
            return;

        //if my head is null
        if (Head is null)
        {
            Head = newList.Head;
            Tail = newList.Tail;
            Size = newList.Size;
        }
        else
        {
            if (Tail is not null)
            {
                Tail.Next = newList.Head;
                Tail = newList.Tail;
                Size += newList.Size;
            }
        }
        newList.Head = null;
        newList.Tail = null;
        newList.Size = 0;
    }
}