(function () {
    'use strict';
    //Services cho GetDashBoardAPI
    angular.module('BlurAdmin.pages')
        .factory('GetDashBoardAPI', GetDashBoardAPI);
    /** @ngInject */
    function GetDashBoardAPI($http, $rootScope, localStorage, BASE, toastr) {
        var host = BASE + 'api/';
        //getSoNhanVien
        var get_so_nhanvien = function (params) {
            var result = $http.get(host + 'dashBoard/get-so-nhanvien',params)
                .success(function (data) {
                })
                .error(function () {
                    toastr.error('Error');
                });
            return result;
        }
        var get_nhanvien = function (params) {
            var result = $http.get(host + 'dashBoard/get-nhanvien',params)
                .success(function (data) {
                })
                .error(function () {
                    toastr.error('Error');
                });
            return result;
        }

        var get_so_donhangcho = function (params) {
            var result = $http.get(host + 'dashBoard/get-so-donhangcho',params)
                .success(function (data) {
                })
                .error(function () {
                    toastr.error('Error');
                });
            return result;
        }

        var get_so_donhangdanggiao = function (params) {
            var result = $http.get(host + 'dashBoard/get-so-donhangdanggiao',params)
                .success(function (data) {
                })
                .error(function () {
                    toastr.error('Error');
                });
            return result;
        }
        var get_so_donhanglayhang = function (params) {
            var result = $http.get(host + 'dashBoard/get-so-donhanglayhang',params)
                .success(function (data) {
                })
                .error(function () {
                    toastr.error('Error');
                });
            return result;
        }
        var get_so_donhangvaokho = function (params) {
            var result = $http.get(host + 'dashBoard/get-so-donhangvaokho',params)
                .success(function (data) {
                })
                .error(function () {
                    toastr.error('Error');
                });
            return result;
        }
        return {
            get_so_nhanvien: get_so_nhanvien,
            get_nhanvien: get_nhanvien,
            get_so_donhangcho: get_so_donhangcho,
            get_so_donhangdanggiao: get_so_donhangdanggiao,
            get_so_donhanglayhang: get_so_donhanglayhang,
            get_so_donhangvaokho: get_so_donhangvaokho
        }
    }
})();