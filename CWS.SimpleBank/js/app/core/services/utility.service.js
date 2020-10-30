(function () {
    "use strict";

    angular.module("app.core").factory("utilityService", utilityService);
    utilityService.$inject = ["$window", "$rootScope",  "config", "$filter", "logger"];
    function utilityService($window, $rootScope,  config, $filter, logger) {

        var service = {
            $broadcast: $broadcast,
            popError: popError,
            transformErrorResponse: transformErrorResponse,
            planChanged: planChanged,
            popPrompt: popPrompt,
            getGuid: getGuid
        }

        return service;
        /////

        function planChanged() {
            $rootScope.$broadcast("plan.changed");
        }

        function $broadcast() {
            return $rootScope.$broadcast.apply($rootScope, arguments);
        }

        function transformErrorResponse(httpError) {
            var response = {
                errorMessage: config.errorMessge
            }

            if (httpError.data && httpError.data.message) {
                var message = httpError.data.message;
                if (message.indexOf(" ") === -1) {
                    response.errorCode = message;
                    var translatedMessage = $filter('translate')(httpError.data.message);
                    if (translatedMessage !== message) {
                        response.errorMessage = translatedMessage;
                    } else {
                        logger.warning("No translation found for: " + logger);
                        response.errorCode = message;
                    }
                } else {
                    response.errorMessage = message;
                }
            }

            return response;
        }

        function popPrompt(inTitle, inMessage) {
            return $ionicPopup.confirm({
                title: inTitle,
                template: inMessage
            });
        }

        function getGuid() {
            return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
                return v.toString(16);
            });

        }

        function popError(error, errorTitle) {
            error = error || {};
            if (typeof error === "string") {
                var s = error;
                error = {
                    message: s
                }
            }

            var title = errorTitle || config.errorTitle;
            if (error.errorCode) {
                var translation = $filter('translate')(error.errorCode);
                if (translation) {
                    error.message = translation;
                }

            }

            if (!error.message)
                error.message = config.errorMessge;

            if (error.stateErrors && error.stateErrors.length) {
                title = errorTitle || error.message;
                if (error.stateErrors.length === 1) {
                    error.message = error.stateErrors[0];
                    error.stateErrors = null;
                } else {
                    error.message = "";
                }
            }

            var errorScope = $rootScope.$new();
            errorScope.error = error;
            errorScope.title = title;
            logger.error(error,null,title);
        }


    }
}());