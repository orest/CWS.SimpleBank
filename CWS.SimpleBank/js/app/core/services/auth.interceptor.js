(function () {
    "use strict";
    angular.module("app.core").
        factory("authInterceptor", authInterceptor);

    authInterceptor.$inject = ["authTokenService", "$q", "$injector", "config", "$window"];
    function authInterceptor(authTokenService, $q, $injector, appConfig, $window) {
        return {
            request: function (config) {
                config.headers = config.headers || {};
                var token = authTokenService.getToken();

                if (token) {
                    config.headers[appConfig.tokenNames.accessToken] = token;
                }

                if (appConfig.appVersion) {
                    config.headers[appConfig.tokenNames.appVersion] = appConfig.appVersion;
                }

                return config;
            },
            responseError: function (rejection) {
                console.log(rejection);
                var msg = rejection.data + ": " + rejection.config.url;
                console.log(msg);
                if (rejection.status === 401) {
                    var stateService = $injector.get("$state");
                    authTokenService.removeToken();
                    var storage = $window.localStorage;
                    var lastLocation = storage.getItem(appConfig.storageKeys.lastKnownLocation);
                    if (!lastLocation) {
                        var routeName = stateService.current.name;
                        if (routeName && routeName !== appConfig.loginState) {
                            storage.setItem(appConfig.storageKeys.lastKnownLocation, routeName);
                        }
                    }
                    stateService.go(appConfig.loginState);
                    return;
                }
                return $q.reject(rejection);
            },
            response: function (response) {
                return response;
            }
        };
    };
}());
