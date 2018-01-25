(function () {
    'use strict';
    //Services cho Role
    angular.module('BlurAdmin.pages')
        .factory('GetRoleAPI', GetRoleAPI);

    /** @ngInject */
    function GetRoleAPI($http, $rootScope, localStorage, BASE) {
        var host = BASE + 'api/';
        //get-all Role
        var role_get_all = function (page, size) {
            var result = $http.get(host + 'role/get-all?page=' + page + '&size=' + size)
                .success(function (data) {
                })
                .error(function () {
                });
            return result;
        };
        //craete Role
        var role_create = function (input) {
            var url = host + 'role/create';
            var result = $http.post(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //get-by-id Role
        var role_getby_id = function (id) {
            var result = $http.get(host + 'role/get-by-id?id=' + id.id)
                .success(function (data) {
                })
                .error(function () {
                });
            return result;;
        };

        //Update Role
        var role_update = function (input) {
            var url = host + 'role/update';
            result = $http.put(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        };

        //delete Role
        var role_delete = function (id) {
            var url = host + 'role/delete?id=' + id;
            var result = $http.delete(url)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }
        return {
            role_get_all: role_get_all,
            role_create: role_create,
            role_getby_id: role_getby_id,
            role_update: role_update,
            role_delete: role_delete
        }
    }
})();