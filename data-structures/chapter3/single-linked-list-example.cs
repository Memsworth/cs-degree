#!

var myTestList = new LinkedList<int>();
System.Console.WriteLine(myTestList);
myTestList.AddAt(0, 10);
System.Console.WriteLine(myTestList);


myTestList.AddAt(0, 5);
System.Console.WriteLine(myTestList);

myTestList.AddAt(1, 15);
System.Console.WriteLine(myTestList);

myTestList.AddAt(myTestList.Size, 30);
System.Console.WriteLine(myTestList);


myTestList.Remove(15);
System.Console.WriteLine(myTestList);

myTestList.Remove(30);
System.Console.WriteLine(myTestList);

myTestList.Remove(5);
System.Console.WriteLine(myTestList);





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
    Node<T>? RemoveAt(int i);
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
            throw new ArgumentOutOfRangeException();

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
        throw new NotImplementedException();
    }

    public Node<T>? RemoveFirst() => RemoveAt(0);
    public Node<T>? RemoveLast() => RemoveAt(Size);
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