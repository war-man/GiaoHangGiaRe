(function () {
    'use strict';
    //Services cho HoaDon
    angular.module('BlurAdmin.pages')
        .factory('GetHoaDonAPI', GetHoaDonAPI);

    /** @ngInject */
    function GetHoaDonAPI($http, $rootScope, localStorage, BASE) {
        var host = BASE + 'api/';
        //get-all HoaDon
        var hoadon_get_all = function (page, size) {
            var result = $http.get(host + 'hoadon/get-all?page=' + page + '&size=' + size)
                .success(function (data) {
                })
                .error(function () {
                });
            return result;
        };

        //craete hoadon
        var hoadon_create = function (input) {
            var result = $http.post(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //delete hoadon
        var hoadon_delete = function (id) {
            var url = host + 'hoadon/delete?id=' + id;
            var result = $http.delete(url)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //Update hoadon
        var hoadon_update = function (input) {
            var url = host + 'hoadon/update';
            result = $http.put(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        };

        //get-by-id Nohoadon

        var hoadon_getby_id = function (id) {
            var result = $http.get(host + 'hoadon/get-by-id?id=' + id.id)
                .success(function (data) {
                })
                .error(function () {
                });
            return result;;
        };

        return {
            hoadon_get_all: hoadon_get_all,
            hoadon_create: hoadon_create,
            hoadon_delete: hoadon_delete,
            hoadon_update: hoadon_update,
            hoadon_getby_id: hoadon_getby_id
        }
    }
})();