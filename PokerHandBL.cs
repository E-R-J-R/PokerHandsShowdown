using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokerHandShowdown.Contracts;
using PokerHandShowdown.DTO;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.Business
{
    public class PokerHandBL : IPokerHand
    {

        DeckBL deckBl = new DeckBL(); 

        public List<Card> PullCards (PokerHand pokerHand)
        {
            for (int i = 0; i < 5; ++i)
                pokerHand.Hand.Add(deckBl.PullCard(pokerHand.Deck));

            return pokerHand.Hand;
        }

        public string PokerHandToString(PokerHand pokerHand)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Card c in pokerHand.Hand)
            {
                sb.Append(c);
                sb.Append(", ");
            }
            return sb.ToString();
        }

        public Card GetCard(PokerHand pokerHand, int cardIndex)
        {
            if (pokerHand.Hand.Any())
            {
                return pokerHand.Hand[cardIndex];
            }
            else
            {
                return null;
            }
        }

        public List<Card> SortHand(List<Card> hand)
        {
            return hand.OrderBy(x => x.Rank).ToList();
        }
    }
}
