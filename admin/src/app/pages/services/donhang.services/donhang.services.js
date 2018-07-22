(function () {
    'use strict';
    //Services cho DonHang
    angular.module('BlurAdmin.pages')
        .factory('GetDonHangAPI', GetBangGiaAPI);
    /** @ngInject */
    function GetBangGiaAPI($http, BASE, toastr) {
        var host = BASE + 'api/';
        //get-all DonHang
        var donhang_get_all = function (params) {
            return $http.post(host + 'donhang/get-all',{params});
        }

        //get-all DonHang vi pham
        var donhang_vipham = function (params) {
            return $http.get(host + 'donhang/get-donhang-vipham',{params});
        }

        //craete DonHang
        var donhang_create = function (input) {
            return $http.post(host + 'donhang/create', input);
        }

        //delete DonHang
        var donhang_delete = function (id) {
            return $http.delete(host + 'donhang/delete?id=' + id);
        }

        //Update DonHang
        var donhang_update = function (input) {
            return $http.put(host + 'donhang/update', input);
        }
        
        //PUT xac nhan
        var xac_nhan_donhang = function(MaDonHang) {
            return $http.put(host + 'donhang/xac-nhan-don-hang?MaDonHang=' + MaDonHang);
        }

        //get-by-id DonHang
        var donhang_getby_id = function (id) {
            return $http.get(host + 'donhang/get-by-id?id=' + id.id);
        }
        return {
            xac_nhan_donhang: xac_nhan_donhang,
            donhang_get_all: donhang_get_all,
            donhang_create: donhang_create,
            donhang_delete: donhang_delete,
            donhang_update: donhang_update,
            donhang_getby_id: donhang_getby_id,
            donhang_vipham: donhang_vipham
        }
    }
})();