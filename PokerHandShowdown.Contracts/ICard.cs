using PokerHandShowdown.DTO;

namespace PokerHandShowdown.Contracts
{
    public interface ICard
    {
        bool isJacksOrBetter(Card card);
    }
}
