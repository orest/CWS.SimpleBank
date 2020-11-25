(function () {
    "use strict";

    angular.module("app.todo-admin", ["ui.router","common.exception", "common.logger"]).constant("toastr", toastr)
        .constant("_", window._).config(toastrConfig);

    toastrConfig.$inject = ["toastr"];
    function toastrConfig(toastr) {
        toastr.options.timeOut = 2000;
        toastr.options.positionClass = "toast-bottom-right";
    };

})();
