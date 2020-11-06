(function () {
    "use strict";

    angular
        .module("app.customer")
        .controller("CustomerAccountsController", CustomerAccountsController);

    CustomerAccountsController.$inject = ["$q", "logger", '$stateParams', "$state", "customerService","_"];
    function CustomerAccountsController($q, logger, $stateParams, $state, customerService, _) {
        var vm = this;
        vm.accounts = [];
        vm.customerNumber = "";

        function activate() {
             
        }

        function getAccounts() {
            
        }

        activate();
    }
})();
