using PokerHandShowdown.DTO;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.Contracts
{
    public interface IPoker
    {
        bool isFlush(PokerHand pokerHand);
        bool isOnePair(PokerHand pokerHand);
        bool isThreeOfAKind(PokerHand pokerHand);
        int GetHighCard(PokerHand pokerHand);
        PokerHands EvaluatePokerHand(PokerHand pokerHand);


    }
}
