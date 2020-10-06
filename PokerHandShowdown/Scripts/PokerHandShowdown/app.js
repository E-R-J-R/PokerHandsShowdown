var app = angular.module("PokerHandShowdown", ["ngPlayingCards"]);

app.filter("rawHtml", ["$sce", function ($sce) {
    return function (val) {
        return $sce.trustAsHtml(val);
    };
}]);

app.filter("htmlDecode", ["$sce", function ($sce) {
    return function (val) {
        var decoded = htmlDecode(val);
        return $sce.trustAsHtml(decoded);
    };
}]);


app.factory("ajaxService", ["$http", function ($http) {
    function succeed(data) {
        if (typeof data === "string") {
            var msg = angular.fromJson(data);
        }
    }
    function errorOccured(data) {
        alert(JSON.stringify(data));
    }

    return {
        get: function (url, params) {
            return $http.get(url, params)
            .success(succeed)
            .error(errorOccured);
        },
        post: function (url, params) {
            return $http.post(url, params)
            .success(succeed)
            .error(errorOccured);
        }
    }
}]);
