public class GameEntry
{
    public int Score { get; set; }
    public string Name { get; set; }

    public GameEntry(int score, string name)
    {
        Score = score;
        Name = name;
    }

    public override string ToString() => $"{Name}: {Score}";
}


public class ScoreBoard
{
    public int CurrentEntries { get; private set; }
    public GameEntry[] Board { get; private set; }

    public ScoreBoard(int capacity)
    {
        CurrentEntries = 0;
        Board = new GameEntry[capacity];
    }


    #region Add Into An Array
    public bool Add(GameEntry entry)
    {
        if (CurrentEntries < Board.Length || entry.Score > Board[CurrentEntries - 1].Score)
        {
            if (CurrentEntries < Board.Length)
                CurrentEntries++;

            var atIndex = 0;

            for (var k = CurrentEntries - 1; entry.Score > Board[k - 1].Score; k--)
            {
                Board[k] = Board[k - 1];
                atIndex = k;
            }

            Board[atIndex] = entry;



            var j = CurrentEntries - 1;
            while (j > 0 && Board[j - 1].Score < entry.Score)
            {
                Board[j] = Board[j - 1];
                j--;
            }

            Board[j] = entry;
        }
    }

    #endregion



    #region Remove At Index
    public GameEntry Remove(int atIndex)
    {
        if (atIndex >= CurrentEntries || atIndex < 0)
        {
            throw new IndexOutOfRangeException();
        }




        var toRemove = Board[atIndex];

        for (var k = atIndex; k < CurrentEntries - 1; k++)
        {
            Board[k] = Board[k + 1];
        }


        int j = atIndex;
        while (j < CurrentEntries - 1)
        {
            Board[j] = Board[j + 1];
            j++;
        }

        Board[CurrentEntries - 1] = null;
        CurrentEntries--;

        return toRemove;
    }

    #endregion


    #region InsertionSort

    public void SortArray()
    {
        if (CurrentEntries >= 2)
        {
            for (int i = 1; i < CurrentEntries; i++)
            {
                var currentEntry = Board[i];

                int j = i;

                while (j > 0 && Board[j - 1].Score > currentEntry.Score)
                {
                    Board[j] = Board[j - 1];
                    j--;
                }

                Board[j] = currentEntry;
            }
        }
    }
    #endregion
}