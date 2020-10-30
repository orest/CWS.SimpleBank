(function () {
    "use strict";

    angular.module("app.core").factory("planService", planService);
    planService.$inject = ["$window", "$injector", "$http", "exception", "config"];
    function planService($window, $injector, $http, exception, config) {
        
        var storage = $window.sessionStorage,
            planInfoKey = "pw.planInfo";
        var currentUserPlan = getUserPlan();
        var service = {
            setUserPlan: setUserPlan,
            getUserPlan: getUserPlan,
            resetUserPlan: resetUserPlan,
            setSelectedAccount: setPlanCode,
            getPlanInfo: getPlanInfo,
            current: getUserPlan
        }

        return service;
        /////


        function setUserPlan(plan) {
            currentUserPlan = initUserPlan();
            //if (currentUserPlan.planCode !== plan.planCode) {
            currentUserPlan.planCode = plan.planCode;
            currentUserPlan.webConfigurationRules = plan.webConfigurationRules;
            currentUserPlan.webHTMLRegions = plan.webHTMLRegions;
            //var utils = $injector.get("utilityService");
            //utils.planChanged();
            persistUserPlan();
            //}
        }

        function resetUserPlan() {
            storage.removeItem(planInfoKey);
            currentUserPlan = initUserPlan();
        }


        function setPlanCode(planCode) {
            currentUserPlan = getUserPlan();
            currentUserPlan.planCode = planCode;
            persistUserPlan();
        }
        function getUserPlan() {
            if (!currentUserPlan || !currentUserPlan.planCode) {
                currentUserPlan = angular.fromJson(storage.getItem(planInfoKey));
            }
            if (!currentUserPlan) {
                currentUserPlan = initUserPlan();
            }

            return currentUserPlan;
        }

        function getPlanInfo(planCode) {

            return $http.get(config.apiUrl + "site-config/" + planCode).then(function (response) {

                if (response) {

                    setUserPlan(response.data);
                    return {
                        plan: response.data
                    }
                }
            }).catch(fail);
        }

        function persistUserPlan() {
            storage.setItem(planInfoKey, angular.toJson(currentUserPlan));
        }

        function initUserPlan() {
            return { planCode: "", webConfigurationRules: {}, webHTMLRegions: {} };
        }

        function fail(error) {
            return exception.catcher("")(error);
        }
    }
}());