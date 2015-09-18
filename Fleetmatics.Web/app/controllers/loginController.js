(function () {
    "use strict";

    angular.module("FleetmaticsApp")
        .controller("loginController", [
        "$scope", "authenticationService", "$location", function ($scope, authenticationService, $location) {

            $scope.vm = {
                userName: "",
                password: ""
            }

            $scope.errorMessage = "";


            $scope.login = function () {
                authenticationService.logIn($scope.vm).then(function (response) {
                    $location.path("/product");
                },
                 function (err) {
                     $scope.errorMessage = err.error_description;
                 });
            };
        }
        ]);

})();