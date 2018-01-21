/**
 * @author v.lugovsky
 * created on 03.05.2016
 */
import { _const } from '../../config'

(function () {
    'use strict';

    angular.module('BlurAdmin.services')
        .factory('userServices', userServices);

           /** @ngInject */
    function GetUserAPI($http, $rootScope, localStorage, httpServices) {

        // var host = _const.base_url + "api/";
        // var token;
        // var access_token;

        //get-all TaiKhKhoan
        var user_get_all = function (page, size) {
            var result = null;
            // httpServices.get('taikhoan/get-all?page=' + page + '&size=' + size).success(function (data) {
            //     result = data;
            // }).error(function () {
            // });
            return result;
        };
        //get-current user TaiKhoan
        var user_current_user = function () {

            token = localStorage.getObject('token');

            if (token == null)

                token = $rootScope.token;

            access_token = token.token_type + ' ' + token.access_token

            var result = null;

            result = $http.get(host + 'taikhoan/get-current-user', {

                headers: {

                    "Authorization": access_token
                }

            }).success(function (data) {

                result = data;


            }).error(function () {

            });

            return result;;

        };
        //get-by-id TaiKhoan
        var user_getby_id = function (id) {

            token = localStorage.getObject('token');

            if (token == null)

                token = $rootScope.token;

            access_token = token.token_type + ' ' + token.access_token

            var result = null;

            result = $http.get(host + 'taikhoan/get-by-id?id=' + id.id, {

                headers: {

                    "Authorization": access_token
                }

            }).success(function (data) {

                result = data;


            }).error(function () {

            });

            return result;;

        };

        //update     
        var user_update = function (input) {

            token = localStorage.getObject('token');

            if (token == null)

                token = $rootScope.token;

            access_token = token.token_type + ' ' + token.access_token

            var result = null;

            var url = host + 'taikhoan/update';

            var data = input;

            result = $http.put(url, data, {

                headers: {

                    "Authorization": access_token
                }

            })
                .success(function (data, status) {

                    result = data, status;
                    //alert(result);

                })

                .error(function (data, status) {

                });

            return result;

        }

        //craete TaiKhoan
        var user_create = function (input) {

            token = localStorage.getObject('token');

            if (token == null)

                token = $rootScope.token;

            access_token = token.token_type + ' ' + token.access_token

            var result = null;

            var url = host + 'taikhoan/create';

            var data = input;

            result = $http.post(url, data, {

                headers: {

                    "Authorization": access_token
                }

            })
                .success(function (Response) {

                    result = Response;

                })

                .error(function (data, status, Errors) {

                });

            return result;

        }

        //delete TaiKhoan
        var user_delete = function (id) {

            token = localStorage.getObject('token');

            if (token == null)

                token = $rootScope.token;

            access_token = token.token_type + ' ' + token.access_token

            var result = null;

            var url = host + 'taikhoan/delete?id=' + id;


            result = $http.delete(url, {

                headers: {
                    "Authorization": access_token
                }

            })
                .success(function (data, status) {


                })

                .error(function (data, status) {

                });

            return result;

        }

        //tao access_token = login taikoan
        var user_login = function (input) {

            var result = null;

            var url = 'http://117.0.66.58/token';

            var data = input;
            result = $http.post(url, data,
                { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .success(function (data, status) {

                    result = data, status;

                })

                .error(function (data, status) {

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
        };
    }
})();