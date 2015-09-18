(function () {
    "use strict";

    angular.module("FleetmaticsApp")
        .controller("indexController", ["$scope", "$location", "authenticationService", function ($scope, $location, authenticationService) {

        $scope.logOut = function () {
            authenticationService.logOut();
            $location.path("/home");
        }

        $scope.authenticationInfo = authenticationService.authenticationInfo;

    }]);


})();
