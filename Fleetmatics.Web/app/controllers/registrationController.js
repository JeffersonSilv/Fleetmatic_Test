(function () {
    "use strict";

    angular.module("FleetmaticsApp")
        .controller("registrationController", ["$scope", "$location", "$timeout", "authenticationService", function ($scope, $location, $timeout, authenticationService) {

            $scope.savedSuccessfully = false;
            $scope.errorMessage = "";

            $scope.registration = {
                userName: "",
                firstName: "",
                lastName: "",
                password: "",
                confirmPassword: ""
            };

            var startTimer = function () {
                var timer = $timeout(function () {
                    $timeout.cancel(timer);
                    $location.path("/login");
                }, 2000);
            }

            var validatePassword = function () {
                if ($scope.registration.password !== $scope.registration.confirmPassword) {
                    $scope.errorMessage = "The password and the confirmation password does not match";

                    $scope.registration.password = "";
                    $scope.registration.confirmPassword = "";

                    return false;
                }

                return true;
            }

            $scope.signUp = function () {

                if (validatePassword()) {
                    authenticationService.register($scope.registration).then(function (response) {
                        $scope.savedSuccessfully = true;
                        startTimer();
                    },
                     function (response) {
                         var errors = [];
                         for (var key in response.data.modelState) {
                             if (response.data.modelState.hasOwnProperty(key)) {
                                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                                     errors.push(response.data.modelState[key][i]);
                                 }
                             }
                         }
                         $scope.errorMessage = "Failed to register user due to:" + errors.join(" ");
                        });
                }
            };
        }]);
})();

