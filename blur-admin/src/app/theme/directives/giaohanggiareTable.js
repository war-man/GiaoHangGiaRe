/**
 * Animated load block
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.theme')
        .directive('giaohanggiareTable', giaohanggiareTable);
  
    /** @ngInject */
    function giaohanggiareTable($timeout, $rootScope, $location) {
      return {
        restrict: 'EA',
        scope: {
            tableConfig: '=giaohanggiareTable',
            title: '@'
        },
        controller: function($scope, $element, $state, Restangular, $rootScope, $location, $compile){

        },
        link: function ($scope, elem) {
         
        }
      };
    }
  
  })();