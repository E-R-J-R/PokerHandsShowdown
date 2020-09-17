using System.Collections.Generic;
using PokerHandShowdown.DTO;

namespace PokerHandShowdown.Contracts
{
    public interface IPokerHand
    {
        List<Card> PullCards(PokerHand pokerHand);
        string PokerHandToString(PokerHand pokerHand);
        Card GetCard(PokerHand pokerHand, int cardIndex);
        List<Card> SortHand(List<Card> hand);
    }
}
