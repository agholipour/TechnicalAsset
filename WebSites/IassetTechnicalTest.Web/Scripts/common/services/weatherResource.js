(function () {
    "use strict";

    function weatherResource($resource) {
        return $resource("http://localhost:53725/api/weather/Current?cityName=:cityName&countryName=:countryName");
    }

    angular.module("common.services")
    .factory("weatherResource", ["$resource", weatherResource]);
}());