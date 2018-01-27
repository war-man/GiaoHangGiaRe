(function () {
    'use strict';
    angular.module('BlurAdmin.pages')
        .factory('GetLichSuAPI', GetLichSuAPI);

    /** @ngInject */
    function GetLichSuAPI($http, $rootScope, localStorage, BASE) {
        var host = BASE + 'api/';
        //get-all Lich Su
        var lichsu_get_all = function (page, size) {
            var result = $http.get(host + 'lichsu/get-all')
            .success(function (data) {
            }).error(function () {
            });
            return result;
        };
        return {
            lichsu_get_all: lichsu_get_all
        }
    }
})();