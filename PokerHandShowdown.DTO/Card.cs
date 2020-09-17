using System;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.DTO
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Card : IComparable
    {
        public CardRank Rank { get; set; }

        public CardSuit Suit { get; set; }

        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int CompareTo(object obj)
        {
            if (obj is Card)
            {
                Card card = (Card)obj;
                if (Rank < card.Rank) return -1;
                if (Rank > card.Rank) return 1;
                return 0;
            }
            throw new ArgumentException("Object is not a Card");
        }


    }
}
