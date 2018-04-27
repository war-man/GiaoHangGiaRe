(function () {
    'use strict';
    //Services cho LoaiKH
    angular.module('BlurAdmin.pages')
        .factory('GetLoaiKHAPI', GetLoaiKHAPI);

    /** @ngInject */
    function GetLoaiKHAPI($http, $rootScope, localStorage, BASE) {
        var host = BASE+'api/';
        //get-all LoaiKH
        var loaikh_get_all = function (page, size) {
            var result = null;
            result = $http.get(host + 'loaikh/get-all?page=' + page + '&size=' + size)
            .success(function (data) {
            })
            .error(function () {
            });
            return result;
        };

        //craete loaikh
        var loaikh_create = function (input) {
            var url = host + 'loaikh/create';
            var result = $http.post(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //delete loaikh
        var loaikh_delete = function (id) {
            var url = host + 'loaikh/delete?id=' + id;
            var result = $http.delete(url)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //Update loaikh
        var loaikh_update = function (input) {
            var url = host + 'loaikh/update';
            result = $http.put(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        };

        //get-by-id loaikh
        var loaikh_getby_id = function (id) {
            var result = $http.get(host + 'loaikh/get-by-id?id=' + id.id)
            .success(function (data) {
            }).error(function () {
            });
            return result;;
        };
        return {
            loaikh_get_all: loaikh_get_all,
            loaikh_create: loaikh_create,
            loaikh_delete: loaikh_delete,
            loaikh_update: loaikh_update,
            loaikh_getby_id: loaikh_getby_id
        }
    }
})();



