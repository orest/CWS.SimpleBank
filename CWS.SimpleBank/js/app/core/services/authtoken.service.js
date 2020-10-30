(function () {
    "use strict";

    angular.module("app.core")
        .factory("authTokenService", authTokenService);

    authTokenService.$inject = ["$window", "$cordovaDevice", "userService", "config"];
    function authTokenService($window, $cordovaDevice, userService, config) {
        var storage = $window.localStorage,
            cachedToken,
            userToken = "dw.token",
            rememberMeKey = "dw.remember.me",
            userNameKey = "dw.remembered.user"
            ;

        var service = {
            setToken: setToken,
            setRememberMe: setRememberMe,
            getRememberMe: getRememberMe,
            getToken: getToken,
            isAuthenticated: isAuthenticated,
            removeToken: removeToken,
            getDeviceInfo: getDeviceInfo,
            setUserName: setUserName,
            getUserName: getUserName
        }

        return service;
        /////

        function setToken(token) {
            cachedToken = token;
            storage.setItem(userToken, token);
            isAuthenticated = true;
        }

        function setRememberMe(selection) {
            storage.setItem(rememberMeKey, selection);
        }

        function getRememberMe() {
            var value = storage.getItem(rememberMeKey);
            return value || false;
        }

        function setUserName(userName) {
            storage.setItem(userNameKey, userName);
        }

        function getUserName() {
            var userName = storage.getItem(userNameKey);
            return userName || "";
        }

        function getToken() {
            if (!cachedToken)
                cachedToken = storage.getItem(userToken);
            return cachedToken;
        }

        function isAuthenticated() {
            return !!service.getToken();
        };

        function removeToken() {
            cachedToken = null;
            storage.removeItem(userToken);
            isAuthenticated = false;
        }


        function getDeviceInfo() {
            var info = {
                cordova: "4.1.1",
                manufacturer: "HTC",
                model: "One M9",
                platform: "Android",
                UUID: "1233",
                version: "5.0.2"
            }
            try {
                if ($window.cordova) {
                    info = $cordovaDevice.getDevice();
                }
            } catch (e) {

            }

            return info;
        };
    }
}());