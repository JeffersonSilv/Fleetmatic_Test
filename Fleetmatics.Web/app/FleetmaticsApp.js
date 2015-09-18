(function() {
    "use strict";

    function configuration($routeProvider, $httpProvider) {
        $routeProvider.when("/home", {
            controller: "homeController",
            templateUrl: "/app/views/home.html"
        });

        $routeProvider.when("/login", {
            controller: "loginController",
            templateUrl: "/app/views/login.html"
        });

        $routeProvider.when("/registration", {
            controller: "registrationController",
            templateUrl: "/app/views/registration.html"
        });


        $routeProvider.when("/product", {
            controller: "productController",
            templateUrl: "/app/views/product.html"
        });

        $routeProvider.otherwise({ redirectTo: "/home" });
        $httpProvider.interceptors.push("interceptorService");
    }

    configuration.inject = ["$routeProvider", "$httpProvider"];

    angular.module("FleetmaticsApp",
        ["ngRoute", "LocalStorageModule"])
        .config(configuration)
        .constant("fleetmaticsAppconst", {
            "baseUrl": "http://localhost:46168/",
            "baseProductUrl": "http://localhost:10907/"
        });

    angular.module("FleetmaticsApp").run(["authenticationService", function (authenticationService) {
        authenticationService.fillAuthData();
    }]);

})();