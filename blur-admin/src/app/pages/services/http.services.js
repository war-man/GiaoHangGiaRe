/**
 * @author v.lugovsky
 * created on 03.05.2016
 */
import { _const } from '../../config'

(function () {
    'use strict';

    angular.module('BlurAdmin.services')
        .factory('httpServices', httpServices);

    /** @ngInject */
    function httpServices($http, $rootScope, localStorage) {

        //GET
        var get = function (inner_url) {

            var token = localStorage.getObject('token');
            if (token == null)
                token = $rootScope.token;

            var access_token = token.token_type + ' ' + token.access_token

            var result = null;

            result = $http.get(_const.base_url, inner_url, {

                headers: {

                    "Authorization": access_token
                }

            }).success(function (data) {

                result = data;

            }).error(function () {

            });

            return result;

        };
        return {
            get: get
        }
    }
})();