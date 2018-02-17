(function () {
    'use strict';
    //Services cho DonHang
    angular.module('BlurAdmin.pages')
        .factory('GetDonHangAPI', GetBangGiaAPI);
    /** @ngInject */
    function GetBangGiaAPI($http, $rootScope, localStorage, BASE) {
        var host = BASE + 'api/';
        //get-all DonHang
        var donhang_get_all = function (params) {
            var result = $http.get(host + 'donhang/get-all',{params})
                .success(function (data) {
                })
                .error(function () {
                    toastr.error('Error');
                });
            return result;
        };

        //craete DonHang
        var donhang_create = function (input) {
            var url = host + 'donhang/create';
            var result = $http.post(url, input)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //delete DonHang
        var donhang_delete = function (id) {
            var url = host + 'donhang/delete?id=' + id;
            var result = $http.delete(url)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        }

        //Update DonHang
        var donhang_update = function (input) {
            var url = host + 'donhang/update';
            var result = $http.put(url, data)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
            return result;
        };

        //get-by-id DonHang
        var donhang_getby_id = function (id) {
            var result = $http.get(host + 'donhang/get-by-id?id=' + id.id)
                .success(function (data) {
                }).error(function () {
                });
            return result;;
        };
        return {
            donhang_get_all: donhang_get_all,
            donhang_create: donhang_create,
            donhang_delete: donhang_delete,
            donhang_update: donhang_update,
            donhang_getby_id: donhang_getby_id
        }
    }
})();