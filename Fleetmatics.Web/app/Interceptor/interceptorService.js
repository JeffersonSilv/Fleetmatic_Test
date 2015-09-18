(function () {
    "use strict";

    angular.module("FleetmaticsApp")
        .factory("interceptorService", ["$q", "$injector", "$location", "localStorageService", function ($q, $injector, $location, localStorageService) {

            var interceptorServiceFactory = {};

        var request = function (config) {

            config.headers = config.headers || {};

            var authorizationData = localStorageService.get("authorizationData");
            if (authorizationData) {
                config.headers.Authorization = "Bearer " + authorizationData.token;
            }

            return config;
        }

        var responseError = function (rejection) {
            $location.path("/login");
            return $q.reject(rejection);
        }

        interceptorServiceFactory.request = request;
        interceptorServiceFactory.responseError = responseError;

        return interceptorServiceFactory;
    }]);
})();


