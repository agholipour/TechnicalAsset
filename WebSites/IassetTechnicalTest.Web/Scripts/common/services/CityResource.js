(function () {
    "use strict";

    function cityResource($resource) {
        return $resource("http://localhost:53725/api/cities/:countryName");
    }

    angular.module("common.services")
    .factory("cityResource", ["$resource", cityResource]);
}());