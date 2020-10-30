(function () {
    "use strict";

    angular
        .module("app.core", [
            "ui.router", "ngSanitize", "common.exception", "common.logger", "common.router"
        ]);
})();
