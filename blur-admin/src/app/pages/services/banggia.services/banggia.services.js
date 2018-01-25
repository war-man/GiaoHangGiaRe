(function () {
    'use strict';
    //Services cho BangGia
    angular.module('BlurAdmin.pages')
        .factory('GetBangGiaAPI', GetBangGiaAPI);

    /** @ngInject */
    function GetBangGiaAPI($http, $rootScope, localStorage, BASE) {
        var host =BASE+'api/';
        //get-all BangGia
        var banggia_get_all = function (page, size) {
            var result = $http.get(host + 'banggia/get-all?page=' + page + '&size=' + size)
            .success(function (data) {
            })
            .error(function () {
            });
            return result;
        };

        //craete BangGia
        var banggia_create = function (input) {
            var url = host + 'banggia/create';
            var result = $http.post(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //delete BangGia
        var banggia_delete = function (id) {
            var url = host + 'banggia/delete?id=' + id;
            var result = $http.delete(url)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //Update BangGia
        var banggia_update = function (input) {
            var url = host + 'banggia/update';
            var result = $http.put(url, data)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        };

        //get-by-id BangGia
        var banggia_getby_id = function (id) {
            var result = $http.get(host + 'banggia/get-by-id?id=' + id.id)
            .success(function (data) {
            }).error(function () {
            });
            return result;;
        };
        return {
            banggia_get_all: banggia_get_all,
            banggia_create: banggia_create,
            banggia_delete: banggia_delete,
            banggia_update: banggia_update,
            banggia_getby_id: banggia_getby_id
        }
    }
})();