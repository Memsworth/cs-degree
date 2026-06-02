using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.level28;

internal class ChallengeRoomCoordinates : IExercise
{
    public void Run()
    {
        var a = new Coordinate(2, 3);
        var b = new Coordinate(2, 4);
        var c = new Coordinate(5, 3);

        Console.WriteLine(a.IsAdjacentTo(b));
        Console.WriteLine(a.IsAdjacentTo(c));
    }

    public struct Coordinate
    {
        public int Row { get; }
        public int Column { get; }

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool IsAdjacentTo(Coordinate other)
        {
            bool horizontal =
                Row == other.Row &&
                Math.Abs(Column - other.Column) == 1;

            bool vertical =
                Column == other.Column &&
                Math.Abs(Row - other.Row) == 1;

            return horizontal || vertical;
        }
    }
}
