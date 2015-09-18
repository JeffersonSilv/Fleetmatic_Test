(function () {
    "use strict";

    angular.module("FleetmaticsApp")
       .controller("productController", ["$scope", "productService",  function ($scope, productService) {

           $scope.products = [];


            productService.getProducts().then(function(results) {
                $scope.products = results.data;
            },
                function(error) {
                  //  alert("Error");
                }
            );
        }]);

})();
