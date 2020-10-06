app.service("pokerService", ["ajaxService", function (ajaxService) {
    
    this.dealPlayerCards = function () {
        return ajaxService.get("/api/player/DealPlayerCards");
    };

    this.evaluateWinningHand = function (playerList) {
        return ajaxService.post("/api/poker/EvaluateWinningHand", playerList);
    };

}]);
