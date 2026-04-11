namespace CSFundamentals.Sedgewick.Chapter1.Section4
{
    internal class Exercise4_10 : IExercise
    {
        public void Run(string[] args)
        {
            var deck = new Card[52];
            var index = 0;

            //Kana's implementation
            deck = 
                Enum.GetValues<Type>()
                .SelectMany(type => Enum.GetValues<CardVal>(),
                (type, face) => new Card { CardType = type, CardValue = face }).ToArray();

            //foreach (var type in Enum.GetValues<Type>())
            //{
            //    foreach(var cardVal in Enum.GetValues<CardVal>())
            //        deck[index++] = new Card { CardType = type, CardValue = cardVal};
            //}

            var rand = new Random();
            // Fisher–Yates shuffle
            for (var i = deck.Length - 1; i > 0; i--)
            {
                var j = rand.Next(i + 1);

                var temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }


            var handsToDeal = int.Parse(args[0]);

            var currentIndex = 0;
            for(int i = 0; i < handsToDeal; i++)
            {
                if((currentIndex + 5) > deck.Length)
                {
                    Console.WriteLine($"Not enough cards");
                    return;
                }

                var Hand = GetHand(deck, rand, ref currentIndex);

                //Kana's implementation
                //var Hand = deck.Skip(i * 5).Take(5);
                Console.WriteLine($"Player {i+1} Hand: ");

                foreach(var card in Hand)
                {
                    Console.Write($"{card}  ");
                }
                Console.WriteLine();
            }
        }

        private Card[] GetHand(Card[] deck, Random rand, ref int currentIndex)
        {
            var hand = new Card[5];
            for (var i = 0; i < 5; i++)
                hand[i] = deck[currentIndex++];

            return hand;
        }

        private class Card
        {
            public Type CardType { get; set; }
            public CardVal CardValue { get; set; }

            public override string ToString()
            {
                return $"{CardValue} of {CardType}";
            }
        }

        private enum Type
        {
            Diamond = 0,
            Club = 1,
            Heart = 2,
            Spade = 3
        }

        private enum CardVal
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

    }
}
