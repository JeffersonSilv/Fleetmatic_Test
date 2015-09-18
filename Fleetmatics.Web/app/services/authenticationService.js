(function () {
    "use strict";

    angular.module("FleetmaticsApp")
        .factory("authenticationService", [
                    "$http", "$q", "localStorageService", "fleetmaticsAppconst",
                    function ($http, $q, localStorageService, fleetmaticsAppconst) {

                        var authenticationServiceFactory = {};
                        var authenticationInfo = {
                            isAuth: false,
                            userName: ""
                        };

                        var logOut = function () {
                            localStorageService.remove("authorizationData");
                            authenticationInfo.isAuth = false;
                            authenticationInfo.userName = "";
                        };

                        var logIn = function (loginData) {
                            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
                            var deferred = $q.defer();

                            $http.post(fleetmaticsAppconst.baseUrl + "api/security/token", data, { headers: { 'Content-Type': "application/x-www-form-urlencoded" } }).success(function (response) {
                                localStorageService.set("authorizationData", { token: response.access_token, userName: loginData.userName, expires_in: response.expires_in, token_type: response.token_type });

                                authenticationInfo.isAuth = true;
                                authenticationInfo.userName = loginData.userName;

                                deferred.resolve(response);
                            }).error(function (err, status) {
                                logOut();
                                deferred.reject(err);
                            });

                            return deferred.promise;
                        }

                        var register = function (registration) {
                            logOut();

                            return $http.post(fleetmaticsAppconst.baseUrl + "/register", registration).then(function (response) {
                                return response;
                            });
                        };

                        var fillAuthData = function () {
                            var authData = localStorageService.get("authorizationData");
                            if (authData) {
                                authenticationInfo.isAuth = true;
                                authenticationInfo.userName = authData.userName;
                            }

                        };

                        authenticationServiceFactory.logIn = logIn;
                        authenticationServiceFactory.logOut = logOut;
                        authenticationServiceFactory.register = register;
                        authenticationServiceFactory.authenticationInfo = authenticationInfo;
                        authenticationServiceFactory.fillAuthData = fillAuthData;

                        return authenticationServiceFactory;

                    }]);

})();