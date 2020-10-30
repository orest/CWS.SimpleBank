(function () {
    "use strict";

    angular.module("app.core").factory("userService", userService);
    userService.$inject = ["$window", "$injector"];
    function userService($window, $injector) {
        var currentUser = initUser();
        var storage = $window.sessionStorage,
            userInfo = "pw.userInfo";

        var service = {
            setUser: setUser,
            getUser: getUser,
            resetUser: resetUser,
            setSelectedAccount: setSelectedAccount
        }

        return service;
        /////


        function setUser(user) {
            if (currentUser.userId !== user.userId) {
                currentUser.userId = user.userId;
                currentUser.userName = user.userName;
                currentUser.accountId = user.accountId;
                currentUser.isAdmin = user.isAdmin;
                var utils = $injector.get("utilityService");
                utils.accountNameChanged();
                persistUser();
            }
        }

        function resetUser() {
            storage.removeItem(userInfo);
            currentUser = initUser();
        }


        function setSelectedAccount(accountId) {
            currentUser = getUser();
            currentUser.accountId = accountId;
            persistUser();
        }


        function getUser() {
            if (!currentUser.userId) {
                currentUser = angular.fromJson(storage.getItem(userInfo));
            }
            return currentUser;
        }

        function persistUser() {
            storage.setItem(userInfo, angular.toJson(currentUser));
        }

        function initUser() {
            return { userId: "", userName: "", accountId: 0 };
        }
    }
}());