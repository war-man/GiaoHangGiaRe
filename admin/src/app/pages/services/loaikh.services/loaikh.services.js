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
            return $http.get(host + 'loaikh/get-all?page=' + page + '&size=' + size);
        };

        //craete loaikh
        var loaikh_create = function (input) {
            var url = host + 'loaikh/create';
            var result = $http.post(url, input);
            return result;
        }

        //delete loaikh
        var loaikh_delete = function (id) {
            return $http.delete(host + 'loaikh/delete?id=' + id);
        }

        //Update loaikh
        var loaikh_update = function (input) {
            return $http.put(host + 'loaikh/update', input);
        };

        //get-by-id loaikh
        var loaikh_getby_id = function (id) {
            return $http.get(host + 'loaikh/get-by-id?id=' + id.id);;
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



