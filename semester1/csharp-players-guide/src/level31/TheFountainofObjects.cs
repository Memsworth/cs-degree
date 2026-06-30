namespace CSharpPlayersGuide.level31
{
    internal class TheFountainofObjects : IExercise
    {
        private readonly static Random rand = new Random();
        public void Run()
        {
            var dungeoun = new Dungeoun();
            var player = new Player();

            while (true)
            {
                if (!player.IsAlive)
                {
                    Console.WriteLine("LOSS");
                    return;
                }


                if (dungeoun.IsFountainActive == true && dungeoun.Board[player.X, player.Y] == RoomType.Enterance)
                {
                    Console.WriteLine("GG WON");
                    return;
                }

                if (IsNearby(player, dungeoun, RoomType.Pit))
                {
                    Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
                }

                if (IsNearby(player, dungeoun, RoomType.Malestorm))
                {
                    Console.WriteLine("You hear the growling and groaning of a maelstrom nearby.");
                }

                if (IsNearby(player, dungeoun, RoomType.Amarocks))
                {
                    Console.WriteLine("You can smell the rotten stench of an amarok in a nearby room.");
                }


                Console.Write("Command (n,s,e,w,a): ");
                string? input = Console.ReadLine()?.ToLower();

                ICommand? command = input switch
                {
                    "n" => new MoveNorth(),
                    "s" => new MoveSouth(),
                    "e" => new MoveEast(),
                    "w" => new MoveWest(),
                    "a" => new Activate(),
                    _ => null
                };

                if (command == null)
                {
                    Console.WriteLine("Invalid command.");
                    continue;
                }

                command.Run(player, dungeoun);

                RoomType currentRoom = dungeoun.Board[player.X, player.Y];

                if (currentRoom == RoomType.Pit)
                {
                    Console.WriteLine("You fell into a pit!");
                    player.IsAlive = false;
                    continue;
                }

                if (currentRoom == RoomType.Amarocks)
                {
                    Console.WriteLine("An amarok attacks and kills you!");
                    player.IsAlive = false;
                    continue;
                }

                while (dungeoun.Board[player.X, player.Y] == RoomType.Malestorm)
                {
                    HandleMaelstrom(player, dungeoun);
                }
            }
        }


        private bool IsNearby(Player player, Dungeoun dungeoun, RoomType roomType)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int x = player.X + dx;
                    int y = player.Y + dy;

                    if (x < 0 || y < 0 ||
                        x >= dungeoun.Board.GetLength(0) ||
                        y >= dungeoun.Board.GetLength(1))
                        continue;

                    if (dungeoun.Board[x, y] == roomType)
                        return true;
                }
            }

            return false;
        }

        private void HandleMaelstrom(Player player, Dungeoun dungeoun)
        {
            if (dungeoun.Board[player.X, player.Y] != RoomType.Malestorm)
                return;

            Console.WriteLine("A maelstrom hurls you through the caverns!");

            int oldX = player.X;
            int oldY = player.Y;

            int maxX = dungeoun.Board.GetLength(0) - 1;
            int maxY = dungeoun.Board.GetLength(1) - 1;

            player.X = Math.Clamp(player.X + 2, 0, maxX);
            player.Y = Math.Clamp(player.Y - 1, 0, maxY);

            Console.WriteLine($"You were moved to ({player.X}, {player.Y}).");

            int newMaelstromX = Math.Clamp(oldX - 2, 0, maxX);
            int newMaelstromY = Math.Clamp(oldY + 1, 0, maxY);

            RoomType destination = dungeoun.Board[newMaelstromX, newMaelstromY];

            if (destination != RoomType.Enterance &&
                destination != RoomType.Fountain)
            {
                dungeoun.Board[oldX, oldY] = RoomType.Blank;
                dungeoun.Board[newMaelstromX, newMaelstromY] = RoomType.Malestorm;
            }
        }




        public interface ICommand
        {
            void Run(Player player, Dungeoun dungeoun);
        }

        public class MoveNorth : ICommand
        {
            public void Run(Player player, Dungeoun dungeoun)
            {
                if (player.Y > 0)
                    player.Y--;
                else
                    Console.WriteLine("You cannot move north.");
            }
        }

        public class MoveSouth : ICommand
        {
            public void Run(Player player, Dungeoun dungeoun)
            {
                if (player.Y < dungeoun.Board.GetLength(0) - 1)
                    player.Y++;
                else
                    Console.WriteLine("You cannot move south.");
            }
        }

        public class MoveEast : ICommand
        {
            public void Run(Player player, Dungeoun dungeoun)
            {
                if (player.X < dungeoun.Board.GetLength(1) - 1)
                    player.X++;
                else
                    Console.WriteLine("You cannot move east.");
            }
        }

        public class MoveWest : ICommand
        {
            public void Run(Player player, Dungeoun dungeoun)
            {
                if (player.X > 0)
                    player.X--;
                else
                    Console.WriteLine("You cannot move west.");
            }
        }

        public class Activate : ICommand
        {
            public void Run(Player player, Dungeoun dungeoun)
            {
                if (dungeoun.Board[player.X, player.Y] == RoomType.Fountain)
                {
                    dungeoun.IsFountainActive = true;
                    Console.WriteLine("The Fountain of Objects has been activated.");
                }
                else
                {
                    Console.WriteLine("There is no fountain here.");
                }
            }
        }

        public class Player
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsAlive { get; set; }

            public Player()
            {
                X = 0;
                Y = 0;
                IsAlive = true;
            }
        }

        public enum RoomType
        {
            Blank,
            Enterance,
            Fountain,
            Pit,
            Malestorm,
            Amarocks
        }


        public class Dungeoun
        {
            public RoomType[,] Board { get; set; }
            public bool IsFountainActive { get; set; }
            public Dungeoun()
            {
                Board = GetGameSize();
                IsFountainActive = false;
            }

            private void PlaceRandom(RoomType[,] rooms, RoomType roomType, int count)
            {
                int width = rooms.GetLength(0);
                int height = rooms.GetLength(1);

                for (int i = 0; i < count; i++)
                {
                    int x, y;

                    do
                    {
                        x = rand.Next(width);
                        y = rand.Next(height);
                    }
                    while (rooms[x, y] != RoomType.Blank);

                    rooms[x, y] = roomType;
                }
            }

            private RoomType[,] GetGameSize()
            {
                var size = string.Empty;
                while (!string.IsNullOrEmpty(size))
                {
                    Console.WriteLine("Choose a difficulty: large, medium, small");
                    size = Console.ReadLine();
                }

                switch (size)
                {
                    case "large":
                        {
                            var room = new RoomType[8, 8];

                            room[0, 0] = RoomType.Enterance;

                            PlaceRandom(room, RoomType.Pit, 4);
                            PlaceRandom(room, RoomType.Malestorm, 2);
                            PlaceRandom(room, RoomType.Amarocks, 3);
                            PlaceRandom(room, RoomType.Fountain, 1);

                            return room;
                        }

                    case "medium":
                        {
                            var room = new RoomType[6, 6];

                            room[0, 0] = RoomType.Enterance;

                            PlaceRandom(room, RoomType.Pit, 2);
                            PlaceRandom(room, RoomType.Malestorm, 1);
                            PlaceRandom(room, RoomType.Amarocks, 2);
                            PlaceRandom(room, RoomType.Fountain, 1);

                            return room;
                        }

                    default:
                        {
                            var room = new RoomType[4, 4];

                            room[0, 0] = RoomType.Enterance;

                            PlaceRandom(room, RoomType.Pit, 1);
                            PlaceRandom(room, RoomType.Fountain, 1);

                            return room;
                        }
                }
            }
        }
    }
}
