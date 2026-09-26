#!

interface CirculatLinkedList<T>
{
    public void Rotate();
}


interface LinkedList<T>
{
    public void AddFirst(T data);
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


