(function () {
    "use strict";

    angular
        .module("app.customer")
        .controller("CustomerAccountsController", CustomerAccountsController);

    CustomerAccountsController.$inject = ["$q", "logger", '$stateParams', "$state", "customerService"];
    function CustomerAccountsController($q, logger, $stateParams, $state, customerService) {
        var vm = this;
        vm.accounts = [];
        vm.customerNumber = "";

        function activate() {

            if ($stateParams.customerNumber) {
                vm.customerNumber = $stateParams.customerNumber;
                getAccounts();
            }

        }

        function getAccounts() {
            return customerService.getCustomerAccounts(vm.customerNumber).then(function (data) {
                if (data) {
                    vm.accounts = data;
                    console.log(data);
                }
            });

        }

        activate();
    }
})();
