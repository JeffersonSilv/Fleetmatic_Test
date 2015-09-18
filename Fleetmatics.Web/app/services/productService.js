(function () {
    "use strict";

    angular.module("FleetmaticsApp")
        .factory("productService", [
                    "$http", "fleetmaticsAppconst",
                    function ($http, fleetmaticsAppconst) {

                        var productServiceFactory = {};

                        var getProducts = function() {
                            return $http.get(fleetmaticsAppconst.baseProductUrl + "products").then(function (response) {
                                return response;
                            });
                        }

                        productServiceFactory.getProducts = getProducts;
                        return productServiceFactory;

                    }]);

})();