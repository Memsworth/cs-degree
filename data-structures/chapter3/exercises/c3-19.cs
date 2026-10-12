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
        int newScore = entry.Score;

        // Check whether the entry qualifies for the scoreboard.
        if (numEntries < board.Length ||
            newScore > board[numEntries - 1].Score)
        {
            if (numEntries < board.Length)
                numEntries++;

            // Shift lower scores to the right.
            int j = numEntries - 1;

            while (j > 0 && board[j - 1].Score < newScore)
            {
                board[j] = board[j - 1];
                j--;
            }

            board[j] = entry;
        }
    }

    public GameEntry Remove(int index)
    {
        if (index < 0 || index >= numEntries)
            throw new ArgumentOutOfRangeException(nameof(index));

        GameEntry removedEntry = board[index];

        // Shift remaining entries to the left.
        for (int j = index; j < numEntries - 1; j++)
            board[j] = board[j + 1];

        board[--numEntries] = null;

        return removedEntry;
    }
}