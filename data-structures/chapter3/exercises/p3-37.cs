#!


#region original way
public class GameEntry
{
    public string Name { get; }
    public int Score { get; }

    public GameEntry(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public override string ToString()
    {
        return $"({Name}, {Score})";
    }
}



public class ScoreboardLinkedList
{
    public LinkedList<GameEntry> Board { get; private set; }
    public int Count => Board.Size;
    public int Capacity;

    public ScoreboardLinkedList(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);
        Board = new();
        Capacity = capacity;
    }

    public void Add(GameEntry entry)
    {
        if (Capacity == 0)
            return;


        if (Count == Capacity && entry.Score <= Board.Tail.Data.Score)
            return;


        var currentNode = Board.Head;
        var indexToAdd = 0;


        while (currentNode is not null && currentNode.Data.Score >= entry.Score)
        {
            currentNode = currentNode.Next;
            indexToAdd++;
        }

        Board.AddAt(indexToAdd, entry);

        if (Count > Capacity)
            Board.RemoveLast();
    }

    public GameEntry Remove(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        Node<GameEntry> currentNode = Board.Head;

        for (int i = 0; i < index; i++)
            currentNode = currentNode.Next!;

        var removedEntry = currentNode.Data;
        Board.RemoveAt(index);
        return removedEntry;
    }

    public GameEntry? GetEntry(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();

        Node<GameEntry>? currentNode = Board.Head;
        for (int i = 0; i < index; i++)
            currentNode = currentNode.Next;

        return currentNode.Data;
    }
}

public class Scoreboard
{
    private readonly GameEntry?[] _board;
    private int _numEntries;

    public int Count => _numEntries;
    public int Capacity => _board.Length;

    public Scoreboard(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);

        _board = new GameEntry?[capacity];
    }

    public void Add(GameEntry entry)
    {
        ArgumentNullException.ThrowIfNull(entry);

        int newScore = entry.Score;

        // Ignore the entry if the board is full and its score is too low.
        if (_numEntries == _board.Length &&
            newScore <= _board[_numEntries - 1]!.Score)
        {
            return;
        }

        // Increase the number of entries if there is room.
        if (_numEntries < _board.Length)
        {
            _numEntries++;
        }

        // Shift lower scores right to make room.
        int index = _numEntries - 1;

        while (index > 0 && _board[index - 1]!.Score < newScore)
        {
            _board[index] = _board[index - 1];
            index--;
        }

        _board[index] = entry;
    }

    public GameEntry Remove(int index)
    {
        if (index < 0 || index >= _numEntries)
        {
            throw new ArgumentOutOfRangeException(
                nameof(index),
                index,
                "Index is outside the range of existing entries.");
        }

        GameEntry removedEntry = _board[index]!;

        // Shift remaining entries left.
        for (int i = index; i < _numEntries - 1; i++)
            _board[i] = _board[i + 1];

        // Clear the old last slot.
        _board[--_numEntries] = null;

        return removedEntry;
    }

    public GameEntry? GetEntry(int index)
    {
        if (index < 0 || index >= _numEntries)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return _board[index];
    }
}
#endregion


#region linked list data structure

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
    public void ReverseList();
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
    public void Concat(LinkedList<T> newList);
    public void Swap(Node<T> nodeOne, Node<T> nodeTwo);

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

    public void Swap(Node<T> nodeOne, Node<T> nodeTwo)
    {
        if (nodeOne is null || nodeTwo is null)
            throw new ArgumentNullException();


        if (nodeOne == nodeTwo)
            return;

        Node<T>? prevOne = null;
        Node<T>? prevTwo = null;
        var current = Head;

        while (current is not null)
        {
            if (current.Next == nodeOne)
                prevOne = current;

            if (current.Next == nodeTwo)
                prevTwo = current;

            current = current.Next;
        }

        var oneIsHead = Head == nodeOne;
        var twoIsHead = Head == nodeTwo;

        var oneExists = oneIsHead || prevOne is not null;
        var twoExists = twoIsHead || prevTwo is not null;

        if (!oneExists || !twoExists)
            throw new ArgumentException(
                "Both nodes must belong to this linked list.");


        if (nodeOne.Next == nodeTwo)
        {
            if (prevOne is not null)
                prevOne.Next = nodeTwo;
            else
                Head = nodeTwo;

            nodeOne.Next = nodeTwo.Next;
            nodeTwo.Next = nodeOne;
        }

        else if (nodeTwo.Next == nodeOne)
        {
            if (prevTwo is not null)
                prevTwo.Next = nodeOne;
            else
                Head = nodeOne;

            nodeTwo.Next = nodeOne.Next;
            nodeOne.Next = nodeTwo;
        }

        else
        {
            var nextOne = nodeOne.Next;
            var nextTwo = nodeTwo.Next;

            if (prevOne is not null)
                prevOne.Next = nodeTwo;
            else
                Head = nodeTwo;

            if (prevTwo is not null)
                prevTwo.Next = nodeOne;
            else
                Head = nodeOne;

            nodeOne.Next = nextTwo;
            nodeTwo.Next = nextOne;
        }

        if (Tail == nodeOne)
            Tail = nodeTwo;
        else if (Tail == nodeTwo)
            Tail = nodeOne;
    }

    public void ReverseList()
    {
        if (Size < 1)
            return;

        var currentHead = Head;
        var currentTail = Tail;

        Node<T>? prev = null;

        var currentNode = Head;

        while (currentNode is not null)
        {
            var nextNode = currentNode.Next;
            currentNode.Next = prev;
            prev = currentNode;
            currentNode = nextNode;
        }

        Head = currentTail;
        Tail = currentHead;
    }
}
#endregion