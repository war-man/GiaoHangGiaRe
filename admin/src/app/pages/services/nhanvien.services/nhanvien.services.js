(function () {
    'use strict';
    //Services cho NhanVien
    angular.module('BlurAdmin.pages')
        .factory('GetNhanVienAPI', GetNhanVienAPI);
    /** @ngInject */

    function GetNhanVienAPI($http, BASE) {
        var host = BASE + 'api/';
        //get-all NhanVien
        var nhanvien_get_all = function (params) {
            return $http.post(host + 'nhanvien/get-all', params);
        };

        //craete NhanVien
        var nhanvien_create = function (input) {
            return $http.post(host + 'nhanvien/create', input);
        }

        //delete NhanVien
        var stop_active_nhanvien = function (id) {
            return $http.put(host + 'nhanvien/change_tinh_trang?id=' + id)
        }

        //Update NhanVien
        var nhanvien_update = function (input) {
            return $http.put(host + 'nhanvien/update', input)
        };

        //get-by-id NhanVien
        var nhanvien_getby_id = function (id) {
            return $http.get(host + 'nhanvien/get-by-id?id=' + id.id)
        };
        return {
            nhanvien_get_all: nhanvien_get_all,
            nhanvien_create: nhanvien_create,
            stop_active_nhanvien: stop_active_nhanvien,
            nhanvien_update: nhanvien_update,
            nhanvien_getby_id: nhanvien_getby_id
        };
    }
})();