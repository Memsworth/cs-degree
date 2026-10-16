public class GameEntry
{
    public string Name { get; }
    public int Score { get; }

    public GameEntry(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public override string ToString() => $"({Name}, {Score})";
}

public class Scoreboard
{
    private int numEntries = 0;
    private readonly GameEntry[] board;

    public Scoreboard(int capacity)
    {
        board = new GameEntry[capacity];
    }

    public void Add(GameEntry entry)
    {
        if (numEntries < board.Length)
            board[numEntries++] = entry;
        else
            System.Console.WriteLine("Error! Array is full");
    }

    public GameEntry Remove(int index)
    {
        if (index < 0 || index >= numEntries || numEntries == 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        GameEntry removedEntry = board[index];

        board[index] = board[numEntries - 1];
        board[numEntries - 1] = null;
        numEntries--;

        return removedEntry;
    }
}