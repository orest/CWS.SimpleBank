(function () {
    "use strict";

    angular
        .module("app.customer")
        .controller("CustomersController", CustomersController);

    CustomersController.$inject = ["$q", "logger", '$stateParams', "$state", "customerService"];
    function CustomersController($q, logger, $stateParams, $state, customerService) {
        var vm = this;
        vm.customers = [];

        function activate() {
            refresh();
        }

        function refresh() {
            return customerService.getAllCustomers().then(function (data) {
                if (data) {
                    vm.customers = data;
                }
            });
        }

        activate();
    }
})();
