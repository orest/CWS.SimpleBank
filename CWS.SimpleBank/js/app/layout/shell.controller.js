(function () {
    "use strict";

    angular
        .module("app.layout")
        .controller("ShellController", ShellController);

    ShellController.$inject = ["$rootScope", "$timeout", "config", "logger", "$scope"];
    /* @ngInject */
    function ShellController($rootScope, $timeout, config, logger, $scope) {
        var vm = this;
        vm.busyMessage = "Please wait ...";
        vm.isBusy = true;
        vm.toggleMenu = toggleMenu;
        vm.showMenu = false;
        vm.selectedMenuItem = null;
        vm.today = new Date();

        $rootScope.showSplash = true;

        activate();

        function activate() {
            hideSplash();
        }

        function toggleMenu() {
            vm.showMenu = !vm.showMenu;
        }

        function hideSplash() {
            //Force a 1 second delay so we can see the splash.
            $timeout(function () {
                $rootScope.showSplash = false;
            }, 1000);
        }

        vm.bodyClass = "page";

        // this'll be called on every state change in the app
        $scope.$on('page.changed', function (event, data) {
            if (angular.isDefined(data.bodyClass)) {
                vm.bodyClass = data.bodyClass;
                return;
            }
            vm.bodyClass = "page";
        });

        $scope.$on("vessel.name.change", function (event, data) {
            vm.vesselName = data;
        });



    }
})();
