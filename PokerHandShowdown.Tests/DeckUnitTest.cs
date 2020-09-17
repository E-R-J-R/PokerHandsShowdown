using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.Business;
using PokerHandShowdown.DTO;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.Tests
{
    [TestClass]
    public class DeckUnitTest
    {
        [TestMethod]
        public void TestDeck_Initialize()
        {
            //Arrange
            var deckBl = new DeckBL();
            var deck = new Deck();

            //Act
            deckBl.Initialize(deck);

            //Assert
            Assert.AreEqual(deck.CardDeck.Count, 52, "Deck failed to initialize");

        }

        [TestMethod]
        public void TestDeck_Duplicates()
        {
            //Arrange
            var deckBl = new DeckBL();
            var deck = new Deck();

            //Act
            deckBl.Initialize(deck);

            //deck.CardDeck.Add(new Card(CardRank.Ace, CardSuit.Spades)); INSERT DUPLICATE

            var duplicateList = deck.CardDeck.GroupBy(x => new { x.Rank, x.Suit })
                                   .Where(group => group.Count() >= 2)
                                   .Select(group => group.First());

            //Assert
            Assert.AreEqual(duplicateList.Any(), false, "There are duplicate cards in the deck.");

        }

        [TestMethod]
        public void TestDeck_PullCard()
        {
            //Arrange
            var deckBl = new DeckBL();
            var deck = new Deck();

            //Act
            deckBl.Initialize(deck);
            var card = deckBl.PullCard(deck);
            var isCardValid = (card.Rank != CardRank.None && card.Suit != CardSuit.None);

            //Assert
            Assert.AreEqual(isCardValid, true, "Card pulled from Deck is not valid");
            Assert.AreEqual(deck.CardDeck.Count, 52, "Deck does not contain expected number of cards after pulling a card.");

        }

        [TestMethod]
        public void TestDeck_Shuffle()
        {
            //Arrange
            var deckBl = new DeckBL();
            var deck = new Deck();

            //Act
            deckBl.Initialize(deck);
            var firstCard = deck.CardDeck[0];
            deckBl.ShuffleDeck(deck, 1);
            var isShuffled = firstCard != deck.CardDeck[0];
            var duplicateList = deck.CardDeck.GroupBy(x => new { x.Rank, x.Suit })
                                   .Where(group => group.Count() >= 2)
                                   .Select(group => group.First());

            //Assert
            Assert.AreEqual(isShuffled, true, "Deck may not be shuffled.");
            Assert.AreEqual(deck.CardDeck.Count, 52, "Deck does not contain expected number of cards after shuffle.");
            Assert.AreEqual(duplicateList.Any(), false, "There are duplicate cards in the deck after shuffle.");
        }

    }
}
