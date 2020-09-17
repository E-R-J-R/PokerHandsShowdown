using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerHandShowdown.Common
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class Enums
    {
        public enum CardRank
        {
            None = 0,
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
            King = 13,
            Ace = 14
        }

        public enum CardSuit
        {
            None,
            Club,
            Spades,
            Hearts,
            Diamonds
        }

        public enum PokerHands
        {
            HighCard,
            OnePair,
            ThreeOfAKind,
            Flush
        }
    }
}
