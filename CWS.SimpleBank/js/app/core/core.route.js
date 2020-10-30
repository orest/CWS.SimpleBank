(function () {
    'use strict';

    angular
      .module('app.core')
      .run(appRun);

    /* @ngInject */
    function appRun(routerHelper) {
        var otherwise = "/customers";
        routerHelper.configureStates(getStates(), otherwise);
    }

    function getStates() {
        return [
          {
              state: '404',
              config: {
                  url: '/404',
                  templateUrl: 'js/app/core/404.html',
                  title: '404'
              }
          }
          //{
          //    state: "plan", config: {
          //        url: "/plan",
          //        abstruct: true,
          //        templateUrl: "app/layout/shell.html",
          //        controller: "ShellController",
          //        controllerAs: "vm"
          //    }
          //}
        ];
    }
})();
