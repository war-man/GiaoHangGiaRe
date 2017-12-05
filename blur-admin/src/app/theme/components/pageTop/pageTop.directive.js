/**
 * @author v.lugovksy
 * created on 16.12.2015
 */
(function () {
  'use strict';

  angular.module('BlurAdmin.theme.components')
      .directive('pageTop', pageTop);

  /** @ngInject */
  function pageTop($http) {
    return {
      restrict: 'E',
      templateUrl: 'app/theme/components/pageTop/pageTop.html',
      controller:function($scope,GetUserAPI){
      $scope.user = [];
      GetUserAPI.user_current_user()
      .success(function(data){
        console.log(data);
        $scope.user=data;
      });
      } 
    };
  }

})();