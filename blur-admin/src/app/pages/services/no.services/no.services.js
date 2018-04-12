(function () {
    'use strict';
    //Services cho No
    angular.module('BlurAdmin.pages')
        .factory('GetNoAPI', GetNoAPI);

    /** @ngInject */
    function GetNoAPI($http, $rootScope, localStorage, BASE) {
        var host = BASE + 'api/';
        //get-all NhanVien
        var no_get_all = function (params) {
            var result = $http.get(host + 'no/get-all',{ params })
                .success(function (data) {
                })
                .error(function () {
                });
            return result;
        };

        //craete No
        var no_create = function (input) {
            var url = host + 'no/create';
            result = $http.post(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //delete No
        var no_delete = function (id) {
            var url = host + 'no/delete?id=' + id;
            var result = $http.delete(url)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //Update No
        var no_update = function (input) {
            var url = host + 'no/update';
            result = $http.put(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        };

        //get-by-id No
        var no_getby_id = function (id) {
            var result = $http.get(host + 'no/get-by-id?id=' + id.id)
                .success(function (data) {
                })
                .error(function () {
                });
            return result;
        };

        return {
            no_get_all: no_get_all,
            no_create: no_create,
            no_delete: no_delete,
            no_update: no_update,
            no_getby_id: no_getby_id
        }
    }
})();