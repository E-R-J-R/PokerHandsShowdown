using System;
using System.Collections.Generic;
using PokerHandShowdown.Contracts;
using PokerHandShowdown.DTO;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.Business
{
    public class DeckBL : IDeck
    {
        public void Initialize(Deck deck)
        {
            deck.CurrentCardIndex = 0;
            deck.CardDeck = new List<Card>();
            //int counter = 0;

            foreach (CardSuit cs in Enum.GetValues(typeof(CardSuit)))
                foreach (CardRank cr in Enum.GetValues(typeof(CardRank)))
                    if (cr != CardRank.None && cs != CardSuit.None)
                        deck.CardDeck.Add(new Card(cr, cs));

            //Perform a shuffle 
            ShuffleDeck(deck, 8);
        }

        public Card PullCard(Deck deck)
        {
            return deck.CardDeck[deck.CurrentCardIndex++];
        } 

        public Card PeekCard(Deck deck)
        {
            return deck.CardDeck[deck.CurrentCardIndex++];
        }

        public Deck SwapCards(Deck deck, int card1, int card2)
        {
            Card temp = deck.CardDeck[card1];
            deck.CardDeck[card1] = deck.CardDeck[card2];
            deck.CardDeck[card2] = temp;

            return deck;
        }

        public Deck ShuffleDeck(Deck deck, int shuffleCount)
        {
            deck.CurrentCardIndex = 0;
            Random random = new Random();

            for (int x = 0; x < shuffleCount; ++x)
            {
                for (int y = 0; y < 52; ++y)
                {
                    int index = random.Next(52);
                    SwapCards(deck, y, index);
                }
            }

            return deck;
        }
    }
}
