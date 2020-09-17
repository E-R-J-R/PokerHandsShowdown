using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.Business;
using PokerHandShowdown.DTO;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.Tests
{ 
    [TestClass]
    public class PokerHandUnitTest
    {
        [TestMethod]
        public void TestPokerHand_PullCard()
        {
            //Arrange
            var pokerHandBl = new PokerHandBL();
            var deckBl = new DeckBL();
            var deck = new Deck();
            deckBl.Initialize(deck);
            var pokerHandPlayer1 = new PokerHand(deck, "Player1");
            var pokerHandPlayer2 = new PokerHand(deck, "Player2");

            var deckCardsFirstSet = new List<Card>()
            {
                deck.CardDeck[0],
                deck.CardDeck[1],
                deck.CardDeck[2],
                deck.CardDeck[3],
                deck.CardDeck[4],
            };

            var deckCardsSecondSet = new List<Card>()
            {
                deck.CardDeck[5],
                deck.CardDeck[6],
                deck.CardDeck[7],
                deck.CardDeck[8],
                deck.CardDeck[9],
            };

            //Act
            pokerHandPlayer1.Hand = pokerHandBl.PullCards(pokerHandPlayer1);
            pokerHandPlayer2.Hand = pokerHandBl.PullCards(pokerHandPlayer2);

            var isFirstSetOfCardsEqual = deckCardsFirstSet.All(pokerHandPlayer1.Hand.Contains) && deckCardsFirstSet.Count == pokerHandPlayer1.Hand.Count;
            var isSecondSetOfCardsEqual = deckCardsSecondSet.All(pokerHandPlayer2.Hand.Contains) && deckCardsSecondSet.Count == pokerHandPlayer2.Hand.Count;


            //Assert
            Assert.AreEqual(pokerHandPlayer1.Hand.Count, 5, "Cards in hand is not equal to 5");
            Assert.AreEqual(isFirstSetOfCardsEqual, true, "First set of Cards in Deck is not equal to first Pull.");
            Assert.AreEqual(isSecondSetOfCardsEqual, true, "Secont set of Cards in Deck is not equal to second Pull.");

        }

    }
}
