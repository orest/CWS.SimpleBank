(function () {
    "use strict";

    angular
        .module("app.customer")
        .run(appRun);

    appRun.$inject = ["routerHelper"];
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [{
            state: "customers",
            config: {
                url: "/customers",
                views: {
                    'mainContent': {
                        templateUrl: "/js/app/customer/templates/customer.html",
                        controller: "CustomersController",
                        controllerAs: "vm"
                    }
                },
                title: "Customers"
            }
        },
            {
                state: "customer-accounts",
                config: {
                    url: "/customer-accounts/:customerNumber",
                    views: {
                        'mainContent': {
                            templateUrl: "/js/app/customer/templates/customer-accounts.html",
                            controller: "CustomerAccountsController",
                            controllerAs: "vm"
                        }
                    },
                    title: "Customer Accounts"
                }
            }
        ];
    }
})();
