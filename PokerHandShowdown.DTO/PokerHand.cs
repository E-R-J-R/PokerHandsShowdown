using System.Collections.Generic;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.DTO
{
    public class PokerHand
    {
        public Deck Deck;
        public List<Card> Hand;
        public string PlayerName;
        public PokerHands PokerScore;
        public int HighCard;

        public PokerHand(Deck deck, string playerName)
        {
            Deck = deck;
            Hand = new List<Card>();
            PlayerName = playerName;
        }
    }
}
