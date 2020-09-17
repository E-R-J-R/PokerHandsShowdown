using PokerHandShowdown.DTO;

namespace PokerHandShowdown.Contracts
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public interface IDeck
    {
        void Initialize(Deck deck);
        Card PullCard(Deck deck);
        Card PeekCard(Deck deck);
        Deck SwapCards(Deck deck, int card1, int card2);
        Deck ShuffleDeck(Deck deck, int shuffleCount);
    }
}
