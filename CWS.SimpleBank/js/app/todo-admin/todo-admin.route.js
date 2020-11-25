(function () {
    "use strict";

    angular
        .module("app.todo-admin")
        .run(appRun);

    appRun.$inject = ["routerHelper"];
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [{
            state: "todo-admin",
            config: {
                url: "/todo-admin",
                views: {
                    'mainContent': {
                        templateUrl: "/js/app/todo-admin/templates/todo-admin.html",
                        controller: "ToDoAdminController",
                        controllerAs: "vm"
                    }
                },
                title: "Todo Admin"
            }
        }
        ];
    }
})();
