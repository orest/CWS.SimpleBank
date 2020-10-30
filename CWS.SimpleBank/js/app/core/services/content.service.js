//http://localhost:3000/api/page-content/test/r1
(function () {
    "use strict";
    angular.module("app.core").factory("contentService", contentService);
    contentService.$inject = ["$http", "config", "$state", "$window", "exception", "CacheFactory", "$q"];
    function contentService($http, config, $state, $window, exception, CacheFactory, $q) {
        var service = {
            getPageContent: getPageContent

        };
        return service;
        //

        function getPageContent(planCode, pageName, regionCode) {

            var cache = CacheFactory.get("content-cache");
            var cacheKey = getCacheKey(planCode, pageName, regionCode);
            var cachedContent = cache.get(cacheKey);

            if (cachedContent) {
                var deferred = $q.defer();

                if (cachedContent.cache) {
                    deferred.resolve({ html: cachedContent.cache.html });
                } else {
                    deferred.resolve({ html: "" });
                }

                return deferred.promise;
            } else {
                return $http.get(config.apiUrl + "page-content/" + planCode + "/" + pageName + "/" + regionCode).then(function (data) {
                    var cacheData = { cache: data.data }
                    cache.put(cacheKey, cacheData);
                    if (data) {
                        return { html: data.data.html }
                    }
                }, function (error) {
                    return fail(" Error", error);
                });
            }
        }

        function getCacheKey(planCode, pageName, regionCode) {
            if (pageName && regionCode) {
                return planCode + "-" + pageName + "-" + regionCode;
            }
            return "";

        }



        function fail(source, error) {
            return exception.catcher(source)(error);
        }

    }

})();