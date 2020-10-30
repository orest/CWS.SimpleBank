(function () {
    "use strict";
    angular.module("app.customer")
        .factory("customerService", customerService);
    //var config = {}
    //config.apiUrl = "/api/";

    customerService.$inject = ["$http", "exception","config"];
    function customerService($http, exception, config) {
        var service = {
            getAllCustomers: getAllCustomers,
            getCustomerAccounts: getCustomerAccounts
        }
        return service;
        ///----


        function getAllCustomers() {
            return $http.get(config.apiUrl + "customerApi").then(function (response) {
                return success(response);
            }).catch(fail);
        };


        function getCustomerAccounts(customerNumber) {
            return $http.get(config.apiUrl + "accountsapi/" + customerNumber).then(function (response) {
                return success(response);
            }).catch(fail);
        };




        function fail(error) {
            return exception.catcher("")(error);
        }

        function success(response) {

            return response.data;
        }

    }

})();