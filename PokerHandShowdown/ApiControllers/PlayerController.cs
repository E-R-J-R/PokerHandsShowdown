using System.Collections.Generic;
using PokerHandShowdown.DTO;
using PokerHandShowdown.Contracts;
using System.Web.Http;
using PokerHandShowdown.Business;
using Newtonsoft.Json;

namespace PokerHandShowdown.ApiControllers
{
    public class PlayerController : ApiController
    {
        //DeckBL deckBl = new DeckBL();
        //PokerHandBL pokerHandBl = new PokerHandBL();

        private readonly IDeck _deckBl;
        private readonly IPokerHand _pokerHandBl;

        public PlayerController(IDeck deckBl, IPokerHand pokerHandBl)
        {
            _deckBl = deckBl;
            _pokerHandBl = pokerHandBl;
        }

        [HttpGet]
        public string DealPlayerCards()
        {
            Deck deck = new Deck();

            _deckBl.Initialize(deck);

            PokerHand player1 = new PokerHand(deck, "Joe");
            PokerHand player2 = new PokerHand(deck, "Jen");
            PokerHand player3 = new PokerHand(deck, "Bob");

            player1.Hand = _pokerHandBl.PullCards(player1);
            player2.Hand = _pokerHandBl.PullCards(player2);
            player3.Hand = _pokerHandBl.PullCards(player3);

            var playerList = new List<PokerHand>()
            {
                player1,
                player2,
                player3
            };

            return JsonConvert.SerializeObject(playerList);

        }

    }
}