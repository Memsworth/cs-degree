#!

var testList = new DoubleLinkedList<int>();

testList.AddFirst(1);
testList.AddFirst(2);
testList.AddFirst(3);
testList.AddFirst(4);
testList.AddFirst(5);
testList.AddFirst(6);
testList.AddFirst(7);
testList.AddFirst(8);


var currentNode = testList.Head;

if (currentNode is not null)
    while (currentNode != null)
    {
        System.Console.Write($"{currentNode.Data} -> ");
        currentNode = currentNode.Next;
    }


var midItem = testList.ReturnMid();

if (midItem is not null)
{
    System.Console.WriteLine();
    System.Console.WriteLine(midItem.Data);
}



public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; }
    public Node<T>? Prev { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}


interface IExercise<T>
{
    Node<T>? ReturnMid();
}

interface ILinkedList<T>
{
    void AddFirst(T data);
    void AddLast(T data);
    T? RemoveFirst();
    T? RemoveLast();
}


public class DoubleLinkedList<T> : ILinkedList<T>, IExercise<T>
{

    public Node<T>? Head { get; set; }
    public Node<T>? Tail { get; set; }
    public int Size { get; private set; }

    public DoubleLinkedList()
    {
        Head = null;
        Tail = null;
        Size = 0;
    }

    public void AddFirst(T data)
    {
        var newNode = new Node<T>(data);
        if (Head is null)
            Head = Tail = newNode;
        else
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }
        Size++;
    }

    public void AddLast(T data)
    {
        var newNode = new Node<T>(data);
        if (Tail is null)
            Head = Tail = newNode;
        else
        {
            newNode.Prev = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }
        Size++;
    }

    private void AddBetween(Node<T> first, Node<T> second, T data)
    {
        var newNode = new Node<T>(data);
        newNode.Prev = first;
        newNode.Next = second;
        first.Next = newNode;
        second.Prev = newNode;
        Size++;
    }
    public T? RemoveFirst()
    {
        if (Head is null)
            return default;

        var data = Head.Data;

        if (Head == Tail)
            Head = Tail = null;
        else
        {
            Head = Head.Next;
            Head.Prev = null;
        }

        Size--;
        return data;
    }

    public T? RemoveLast()
    {
        if (Tail is null)
            return default;

        var data = Tail.Data;

        if (Head == Tail)
            Head = Tail = null;
        else
        {
            Tail = Tail.Prev;
            Tail.Next = null;
        }

        Size--;
        return data;
    }

    public Node<T>? ReturnMid()
    {
        if (Head is null)
            return null;

        var slowPointer = Head;
        var fastPointer = Head;

        while (fastPointer.Next is not null && fastPointer.Next.Next is not null)
        {
            slowPointer = slowPointer.Next;
            fastPointer = fastPointer.Next.Next;
        }
        return slowPointer;
    }
}