using System;
using System.Collections.Generic;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.DTO
{
    public class Deck
    {
        public List<Card> CardDeck { get; set; }
        public int CurrentCardIndex { get; set; }

    }
}
