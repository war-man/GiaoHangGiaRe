(function () {
    'use strict';
    //Services cho NhanVien
    angular.module('BlurAdmin.pages')
        .factory('GetNhanVienAPI', GetNhanVienAPI);
    /** @ngInject */

    function GetNhanVienAPI($http, $rootScope, localStorage, BASE) {
        var host = BASE + 'api/';
        //get-all NhanVien
        var nhanvien_get_all = function (page, size) {
            var result = $http.get(host + 'nhanvien/get-all?page=' + page + '&size=' + size)
                .success(function (data) {
                })
                .error(function () {
                });
            return result;
        };

        //craete NhanVien
        var nhanvien_create = function (input) {
            var url = host + 'nhanvien/create';
            var result = $http.post(url, input).success(function (data, status) {
            })
                .error(function (data, status) {
                });
            return result;
        }

        //delete NhanVien
        var nhanvien_delete = function (id) {
            var url = host + 'nhanvien/delete?id=' + id;
            var result = $http.delete(url)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result
        }

        //Update NhanVien
        var nhanvien_update = function (input) {
            var url = host + 'nhanvien/update';
            return $http.put(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
        };

        //get-by-id NhanVien
        var nhanvien_getby_id = function (id) {
            var result = $http.get(host + 'nhanvien/get-by-id?id=' + id.id)
                .success(function (data) {
                })
                .error(function () {
                });
            return result;;
        };
        return {
            nhanvien_get_all: nhanvien_get_all,
            nhanvien_create: nhanvien_create,
            nhanvien_delete: nhanvien_delete,
            nhanvien_update: nhanvien_update,
            nhanvien_getby_id: nhanvien_getby_id
        };
    }
})();