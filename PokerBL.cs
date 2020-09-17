using System;
using System.Collections.Generic;
using System.Linq;
using PokerHandShowdown.Contracts;
using PokerHandShowdown.DTO;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.Business
{
    public class PokerBL : IPoker
    {
        public bool isFlush(PokerHand pokerHand)
        {
            var hand = pokerHand.Hand;
            CardSuit suit = hand.Select(x => x.Suit).FirstOrDefault();

            if (hand.Where(x => x.Suit == suit).ToList().Count == 5)
            {
                return true;
            }

            return false;
        }

        public bool isOnePair(PokerHand pokerHand)
        {
            var hand = pokerHand.Hand;

            var pairs = hand.GroupBy(x => x.Rank)
                              .Where(group => group.Count() > 1)
                              .Select(group => group.Key);

            if (pairs.Count() == 1) return true;

            return false;
        }

        public bool isThreeOfAKind(PokerHand pokerHand)
        {
            var hand = pokerHand.Hand;

            var threeOfAKind = hand.GroupBy(x => x.Rank)
                                   .Where(group => group.Count() >= 3)
                                   .Select(group => group.First());

            if (threeOfAKind.Any()) return true;

            return false;
        }

        public int GetHighCard(PokerHand pokerHand)
        {
            var hand = pokerHand.Hand;

            var highCard = hand.OrderByDescending(x => x.Rank).FirstOrDefault();

            return (int)highCard.Rank;
        }

        public PokerHands EvaluatePokerHand(PokerHand pokerHand)
        {
            var pokerBl = new PokerBL();

            if (pokerBl.isFlush(pokerHand))
            {
                return PokerHands.Flush;
            }
            else if (pokerBl.isThreeOfAKind(pokerHand))
            {
                return PokerHands.ThreeOfAKind;
            }
            else if (pokerBl.isOnePair(pokerHand))
            {
                return PokerHands.OnePair;
            }
            else
            {
                return PokerHands.HighCard;
            }
        }

        public PokerHand EvaluateWinningHand(List<PokerHand> pokerHandList)
        {
            var pokerBl = new PokerBL();

            foreach (var pokerHand in pokerHandList)
            {
                pokerHand.PokerScore = pokerBl.EvaluatePokerHand(pokerHand);
            }

            var winningHand = pokerHandList.OrderByDescending(x => x.PokerScore).First();

            //Check if winning hand has competition
            var duplicateList = pokerHandList.Where(x => x.PokerScore == winningHand.PokerScore).ToList();


            var hasDuplicate = duplicateList.Count > 1;

            //Declare winner
            if (!hasDuplicate)
            {
                return winningHand;
            }
            else
            {
                //Perform Tie Breaker
                var highScore = winningHand.PokerScore;
                var tieBreakerList = pokerHandList.Where(x => x.PokerScore == highScore).ToList();

                if (highScore == PokerHands.HighCard || highScore == PokerHands.Flush)
                {
                    foreach (var hand in tieBreakerList)
                    {
                        hand.HighCard = pokerBl.GetHighCard(hand);
                    }

                    var highCardWinner = tieBreakerList.OrderByDescending(x => x.HighCard).First();

                    return highCardWinner;
                }
                else if (highScore == PokerHands.OnePair)
                {
                    //Determine the higher pair
                    foreach(var hand in tieBreakerList)
                    {
                        hand.HighCard = pokerBl.GetPairScore(hand);
                    }

                    var highPairWinner = tieBreakerList.OrderByDescending(x => x.HighCard).First();

                    return highPairWinner;

                }
                else if (highScore == PokerHands.ThreeOfAKind)
                {
                    foreach (var hand in tieBreakerList)
                    {
                        hand.HighCard = pokerBl.GetTrioScore(hand);
                    }

                    var highTrioWinner = tieBreakerList.OrderByDescending(x => x.HighCard).First();

                    return highTrioWinner;
                }
                else
                {
                    return null;
                }

            }

        }

        private int GetPairScore(PokerHand pokerHand)
        {
            var pair = pokerHand.Hand.GroupBy(x => x.Rank)
                           .Where(group => group.Count() > 1)
                           .Select(group => group.Key);
            var pairScore = pair.ToList().First();

            return (int)pairScore;
        }

        private int GetTrioScore(PokerHand pokerHand)
        {
            var trio = pokerHand.Hand.GroupBy(x => x.Rank)
                           .Where(group => group.Count() >= 3)
                           .Select(group => group.Key);
            var trioScore = trio.ToList().First();

            return (int)trioScore;
        }
    }
}
