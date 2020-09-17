
using System;
using PokerHandShowdown.DTO;
using static PokerHandShowdown.Common.Enums;

namespace PokerHandShowdown.Business
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class CardBL 
    {
        public bool isJacksOrBetter(Card card)
        {
            if (card.Rank == CardRank.Ace || card.Rank >= CardRank.Jack) return true;
            return false;
        }
    }
}
