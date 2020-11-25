(function () {
    "use strict";

    angular
        .module("app.todo-admin")
        .controller("ToDoAdminController", ToDoAdminController);

    ToDoAdminController.$inject = ["$q", "logger", '$stateParams', "$state"];
    function ToDoAdminController($q, logger, $stateParams, $state) {
        var vm = this;
        vm.pageTitle = "Active Tasks";
        vm.tasks = [];
        function activate() {
            getTasks();
        }

        activate();

        function getTasks() {
            vm.tasks = [
                { id: 1, title: "Walk the dog", completed: true },
                { id: 2, title: "Wash the car", completed: false }
            ];
        }
    }
})();
