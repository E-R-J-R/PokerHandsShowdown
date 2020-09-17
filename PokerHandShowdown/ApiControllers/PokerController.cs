using System.Collections.Generic;
using PokerHandShowdown.DTO;
using System.Web.Http;
using PokerHandShowdown.Business;
using Newtonsoft.Json;

namespace PokerHandShowdown.ApiControllers
{
    public class PokerController : ApiController
    {     
        PokerBL pokerBl = new PokerBL();

        [HttpPost]
        public string EvaluateWinningHand([FromBody]List<PokerHand> playerList)
        {
            var winner = pokerBl.EvaluateWinningHand(playerList);
            return JsonConvert.SerializeObject(winner.PlayerName);
        }


    }




}