(function () {
    'use strict';
    angular.module('BlurAdmin.pages')
        .factory('GetUserAPI', GetUserAPI);

    /** @ngInject */
    function GetUserAPI($http, $rootScope, localStorage, BASE, toastr) {
        var host = BASE + 'api/';
        //get-all TaiKhKhoan
        var user_get_all = function (params) {
            var result = $http.get(host + 'taikhoan/get-all', { params }).success(function (data) {
            }).error(function () {
                toastr.error('Error');
            });
            return result
        };
        //get-current user TaiKhoan
        var user_current_user = function () {
            var result = $http.get(host + 'taikhoan/get-current-user').success(function (data) {
            }).error(function (err) {
                toastr.error('Error');
                console.log(err);
                localStorage.clear();
                $rootScope.token=null;
                window.location = "/auth.html";    
            });
            return result;;
        };

        //get-by-id TaiKhoan
        var user_getby_id = function (id) {
            var result = $http.get(host + 'taikhoan/get-by-id?id=' + id.id).success(function (data) {
            }).error(function () {
                toastr.error('Error');
            });
            return result;;
        };

        //update     
        var user_update = function (input) {
            var url = host + 'taikhoan/update';
            var result = $http.put(url, input).success(function (data, status) {
                oastr.success('Cập nhật thành công!');
            })
                .error(function (data, status) {
                    toastr.error('Error');
                });
            return result;
        }

        //craete TaiKhoan
        var user_create = function (input) {
            var url = host + 'taikhoan/create';
            var data = input;
            var result = $http.post(url, data).success(function (Response) {
            })
                .error(function (data, status, Errors) {
                });
            return result;
        }

        //delete TaiKhoan
        var user_delete = function (id) {
            var url = host + 'taikhoan/delete?id=' + id;
            var result = $http.delete(url).success(function (ré) {
                toastr.success('Đã xóa thành công!');
            })
                .error(function (err) {
                    toastr.error('Error');
                });
            return result;
        }

        //tao access_token = login taikoan
        var user_login = function (input) {
            var url = BASE + '/token';
            var result = $http.post(url, input,
                { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (data, status) {
                    toastr.success('Thành công!');
                })
                .error(function (data, status) {
                    toastr.error('Error');
                });
            return result;
        }

        return {
            user_get_all: user_get_all,
            user_getby_id: user_getby_id,
            user_create: user_create,
            user_login: user_login,
            user_delete: user_delete,
            user_update: user_update,
            user_current_user: user_current_user
        }
    }
})();