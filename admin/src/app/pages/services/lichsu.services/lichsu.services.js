(function () {
    'use strict';
    angular.module('BlurAdmin.pages')
        .factory('GetLichSuAPI', GetLichSuAPI);

    /** @ngInject */
    function GetLichSuAPI($http, BASE) {
        var host = BASE + 'api/';
        //get-all Lich Su
        var lichsu_get_all = function (params) {
            return $http.post(host + 'lichsu/get-all', params);
        };
        return {
            lichsu_get_all: lichsu_get_all
        }
    }
})();