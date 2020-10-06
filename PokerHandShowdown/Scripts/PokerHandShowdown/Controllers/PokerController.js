app.controller("pokerController", ["$scope", "pokerService", function ($scope, pokerService) {

    $scope.shuffle = function () {
        pokerService
       .dealPlayerCards()
       .success(function (data) {
           $scope.playerList = JSON.parse(data);
           $scope.winner = "";
       });
    };
   

    $scope.evaluate = function () {
        pokerService.evaluateWinningHand($scope.playerList)
            .success(function (data) {
                $scope.winner = JSON.parse(data);
            });
    };

    $scope.shuffle();

}]);
