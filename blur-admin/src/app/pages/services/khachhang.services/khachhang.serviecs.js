(function () {
    'use strict';
    //Services cho KhachHang
    angular.module('BlurAdmin.pages')
        .factory('GetKhachHangAPI', GetKhachHangAPI);

    /** @ngInject */
    function GetKhachHangAPI($http, $rootScope, localStorage, BASE) {
        var host = BASE + 'api/';
        //get-all KhachHang
        var khachhang_get_all = function (page, size) {
            var result = $http.get(host + 'khachhang/get-all?page=' + page + '&size=' + size)
            .success(function (data) {
            }).error(function () {
            });
            return result;
        };
        //craete KhachHang
        var khachhang_create = function (input) {
            var url = host + 'khachhang/create';
            result = $http.post(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //delete KhachHang
        var khachhang_delete = function (id) {
            var url = host + 'khachhang/delete?id=' + id;
            var result = $http.delete(url)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //Update KhachHang
        var khachhang_update = function (input) {
            var url = host + 'khachhang/update';
            var result = $http.put(url, data)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        };

        //get-by-id KhachHang
        var khachhang_getby_id = function (id) {
            var result = $http.get(host + 'khachhang/get-by-id?id=' + id.id)
            .success(function (data) {
            }).error(function () {
            });
            return result;;
        };
        return {
            khachhang_get_all: khachhang_get_all,
            khachhang_create: khachhang_create,
            khachhang_delete: khachhang_delete,
            khachhang_update: khachhang_update,
            khachhang_getby_id: khachhang_getby_id
        };
    }
})();
