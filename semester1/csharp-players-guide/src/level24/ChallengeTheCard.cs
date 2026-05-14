using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.level24;

internal class ChallengeTheCard : IExercise
{
    public void Run()
    {
        var deck = new List<Card>();
        foreach (CardColor color in Enum.GetValuesAsUnderlyingType<CardColor>())
        {
            foreach (CardRank rank in Enum.GetValuesAsUnderlyingType<CardRank>())
            {
                Card card = new Card(color, rank);
                deck.Add(card);
            }
        }

        var deck2 = deck.Shuffle();
        foreach (var item in deck2)
            Console.WriteLine(item);
    }


    enum CardColor
    {
        Red, Green, Blue, Yellow
    }

    enum CardRank
    {
        One = 1, Two, Three,
        Four, Five, Six,
        Seven, Eight, Nine,
        Ten, Dollar, Percent,
        Caret, Ampersand
    }

    class Card
    {
        public CardColor Color { get; }
        public CardRank Rank { get; }

        public Card(CardColor color, CardRank rank)
        {
            Color = color;
            Rank = rank;
        }

        public bool IsNumberCard =>
            Rank >= CardRank.One && Rank <= CardRank.Ten;

        public bool IsSymbolCard => !IsNumberCard;

        public override string ToString() => $"The {Color} {GetRankName()}";

        private string GetRankName()
        {
            return Rank switch
            {
                CardRank.One => "One",
                CardRank.Two => "Two",
                CardRank.Three => "Three",
                CardRank.Four => "Four",
                CardRank.Five => "Five",
                CardRank.Six => "Six",
                CardRank.Seven => "Seven",
                CardRank.Eight => "Eight",
                CardRank.Nine => "Nine",
                CardRank.Ten => "Ten",
                CardRank.Dollar => "Dollar",
                CardRank.Percent => "Percent",
                CardRank.Caret => "Caret",
                CardRank.Ampersand => "Ampersand",
                _ => Rank.ToString()
            };
        }
    }
}
