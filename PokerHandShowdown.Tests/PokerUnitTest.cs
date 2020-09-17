using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.Business;
using PokerHandShowdown.DTO;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.Tests
{
    [TestClass]
    public class PokerUnitTest
    {
        [TestMethod]
        public void TestIsJacksOrBetter()
        {
            CardBL cardBl = new CardBL();

            //Arrange
            var card = new Card(CardRank.Ace, CardSuit.Hearts);

            //Act
            var result = cardBl.isJacksOrBetter(card);

            //Assert
            Assert.AreEqual(true, result, "Current Card is Jacks or better.");

        }

        [TestMethod]
        public void TestIsFlush()
        {
            PokerBL pokerBl = new PokerBL();
            PokerHand pokerHand = new PokerHand(new Deck(), "Player");

            //Arrange
            var cardList = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Three, CardSuit.Spades),
                new Card(CardRank.Four, CardSuit.Spades),
                new Card(CardRank.Five, CardSuit.Spades),
                new Card(CardRank.Six, CardSuit.Spades)
            };

            pokerHand.Hand = cardList;

            //Act
            var result = pokerBl.isFlush(pokerHand);

            //Assert
            Assert.AreEqual(true, result, "Current Hand is not a Flush.");

        }

        [TestMethod]
        public void TestIsOnePair_OnePair()
        {
            PokerBL pokerBl = new PokerBL();
            PokerHand pokerHand = new PokerHand(new Deck(), "Player");

            //Arrange
            var cardList = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Two, CardSuit.Diamonds),
                new Card(CardRank.Four, CardSuit.Spades),
                new Card(CardRank.Five, CardSuit.Spades),
                new Card(CardRank.Six, CardSuit.Spades)
            };

            pokerHand.Hand = cardList;

            //Act
            var result = pokerBl.isOnePair(pokerHand);

            //Assert
            Assert.AreEqual(true, result, "Current Hand does not contain a Pair.");

        }

        [TestMethod]
        public void TestIsOnePair_NoPair()
        {
            PokerBL pokerBl = new PokerBL();
            PokerHand pokerHand = new PokerHand(new Deck(), "Player");

            //Arrange
            var cardList = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Jack, CardSuit.Diamonds),
                new Card(CardRank.Four, CardSuit.Spades),
                new Card(CardRank.Five, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Spades)
            };

            pokerHand.Hand = cardList;

            //Act
            var result = pokerBl.isOnePair(pokerHand);

            //Assert
            Assert.AreEqual(false, result, "Current Hand should not contain a Pair.");

        }

        [TestMethod]
        public void TestIsOnePair_TwoPair()
        {
            PokerBL pokerBl = new PokerBL();
            PokerHand pokerHand = new PokerHand(new Deck(), "Player");

            //Arrange
            var cardList = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Two, CardSuit.Diamonds),
                new Card(CardRank.Four, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Spades)
            };

            pokerHand.Hand = cardList;

            //Act
            var result = pokerBl.isOnePair(pokerHand);

            //Assert
            Assert.AreEqual(false, result, "Current Hand is a two Pair.");

        }

        [TestMethod]
        public void TestThreeOfAKind()
        {
            PokerBL pokerBl = new PokerBL();
            PokerHand pokerHand = new PokerHand(new Deck(), "Player");

            //Arrange
            var cardList = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Two, CardSuit.Diamonds),
                new Card(CardRank.King, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Spades)
            };

            pokerHand.Hand = cardList;

            //Act
            var result = pokerBl.isThreeOfAKind(pokerHand);

            //Assert
            Assert.AreEqual(true, result, "Current Hand is a not a Three Of A Kind.");

        }

        [TestMethod]
        public void TestGetHighCard()
        {
            PokerBL pokerBl = new PokerBL();
            PokerHand pokerHand = new PokerHand(new Deck(), "Player");

            //Arrange
            var cardList = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Six, CardSuit.Diamonds), 
                new Card(CardRank.Jack, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Spades)
            };

            pokerHand.Hand = cardList;

            //Act Test
            var result = pokerBl.GetHighCard(pokerHand);

            //Assert
            Assert.AreEqual(14, result, "Could not retrieve High Card.");
        }

        [TestMethod]
        public void TestEvaluateWinningHand()
        {
            //Arrange
            PokerBL pokerBl = new PokerBL();
            PokerHandBL pokerHandBl = new PokerHandBL();
            DeckBL deckBl = new DeckBL();
            Deck deck = new Deck();

            deckBl.Initialize(deck);

            PokerHand player1 = new PokerHand(deck, "Player1");
            PokerHand player2 = new PokerHand(deck, "Player2");
            PokerHand player3 = new PokerHand(deck, "Player3");

            player1.Hand = pokerHandBl.PullCards(player1);
            player2.Hand = pokerHandBl.PullCards(player2);
            player3.Hand = pokerHandBl.PullCards(player3);

            var playerList = new List<PokerHand>()
            {
                player1,
                player2,
                player3
            };

           
            foreach (var player in playerList)
            {
                player.PokerScore = pokerBl.EvaluatePokerHand(player);
            }

            var winningHand = playerList.OrderByDescending(x => x.PokerScore).First();

            //This test does not determine which player won the game in case of a tie, only the hand with highest score (first or default)

            //Act
            var result = pokerBl.EvaluateWinningHand(playerList);

            //Assert
            Assert.AreEqual(winningHand.PokerScore, result.PokerScore, "Poker Hand with highest score did not win the game.");

        }

        [TestMethod]
        public void TestOnePairTieBreaker()
        {
            //Arrange
            PokerBL pokerBl = new PokerBL();
            PokerHandBL pokerHandBl = new PokerHandBL();
            DeckBL deckBl = new DeckBL();
            Deck deck = new Deck();

            deckBl.Initialize(deck);

            PokerHand player1 = new PokerHand(deck, "Player1");
            PokerHand player2 = new PokerHand(deck, "Player2");
            PokerHand player3 = new PokerHand(deck, "Player3");

            //Assign cards to players manually to simulate One Pair Tie Breaker
            var player1CardList = new List<Card>()
            {
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Six, CardSuit.Diamonds),
                new Card(CardRank.Jack, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Spades)
            };

            var player2CardList = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Six, CardSuit.Diamonds),
                new Card(CardRank.Jack, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.Two, CardSuit.Hearts)
            };

            var player3CardList = new List<Card>()
            {
                new Card(CardRank.King, CardSuit.Spades),
                new Card(CardRank.Six, CardSuit.Diamonds),
                new Card(CardRank.Jack, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Spades)
            };

            player1.Hand = player1CardList;
            player2.Hand = player2CardList;
            player3.Hand = player3CardList;

            var playerList = new List<PokerHand>()
            {
                player1,
                player2,
                player3
            };

            var winningHand = player1;

            //Act
            var result = pokerBl.EvaluateWinningHand(playerList);

            //Assert
            Assert.AreEqual(winningHand.PlayerName, result.PlayerName, "Player with wiining pair did not win the game.");
        }

        [TestMethod]
        public void TestThreeOfAKindTieBreaker()
        {
            //Arrange
            PokerBL pokerBl = new PokerBL();
            PokerHandBL pokerHandBl = new PokerHandBL();
            DeckBL deckBl = new DeckBL();
            Deck deck = new Deck();

            deckBl.Initialize(deck);

            PokerHand player1 = new PokerHand(deck, "Player1");
            PokerHand player2 = new PokerHand(deck, "Player2");
            PokerHand player3 = new PokerHand(deck, "Player3");

            //Assign cards to players manually to simulate One Pair Tie Breaker
            var player1CardList = new List<Card>()
            {
                new Card(CardRank.Jack, CardSuit.Hearts),
                new Card(CardRank.Six, CardSuit.Diamonds),
                new Card(CardRank.Jack, CardSuit.Spades),
                new Card(CardRank.Jack, CardSuit.Club),
                new Card(CardRank.Jack, CardSuit.Diamonds)
            };

            var player2CardList = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Two, CardSuit.Diamonds),
                new Card(CardRank.Jack, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.Two, CardSuit.Hearts)
            };

            var player3CardList = new List<Card>()
            {
                new Card(CardRank.King, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Diamonds),
                new Card(CardRank.Jack, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Spades)
            };

            player1.Hand = player1CardList;
            player2.Hand = player2CardList;
            player3.Hand = player3CardList;

            var playerList = new List<PokerHand>()
            {
                player1,
                player2,
                player3
            };

            var winningHand = player3;

            //Act
            var result = pokerBl.EvaluateWinningHand(playerList);

            //Assert
            Assert.AreEqual(winningHand.PlayerName, result.PlayerName, "Player with winning three of a kind hand did not win the game.");
        }
    }
}
