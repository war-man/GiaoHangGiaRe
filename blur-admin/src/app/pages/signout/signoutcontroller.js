(function() {
    'use strict';
  
    angular.module('BlurAdmin.pages.signout')
      .controller('signoutcontroller', signoutcontroller);
  
    /** @ngInject */
    function signoutcontroller($scope,$rootScope, localStorage, $state,GetUserAPI) {
      localStorage.clear();
      $rootScope.token=null;
      window.location = "/auth.html";    
    }
  
  })();