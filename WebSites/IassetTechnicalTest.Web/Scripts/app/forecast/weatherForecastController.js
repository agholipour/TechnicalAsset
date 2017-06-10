(function() {

    "use strict";
    function weatherForecastController(cityResource, weatherResource) {
        var vm = this;
        vm.countryName = "";
        vm.cities = new Array();
        vm.city = "";
        
        vm.getCities = function () {
            cityResource.query({ country: vm.countryName }, function (data) {
                vm.cities = data;
            });
        };

        vm.getForecastWeather = function (cityname) {
            vm.city = cityname;
            weatherResource.get({ cityName: vm.city, countryName: vm.countryName }, function (data) {
                vm.weatherforcast = data;
            });
        };

    }

    angular.module("weatherforecast")
        .controller("weatherForecastController", ["cityResource","weatherResource", weatherForecastController]);
}());