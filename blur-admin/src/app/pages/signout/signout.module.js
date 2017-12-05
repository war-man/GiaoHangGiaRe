(function() {
    'use strict';
  
    angular.module('BlurAdmin.pages.signout', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider) {
      $stateProvider
        .state('signout', {
          url: '/signout',
          templateUrl: 'app/pages/signout/signout.html',
          controller: 'signoutcontroller',
          authenticate: false
        });
    }
  
  })();