/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.bando', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider) {
      var controller='bandocontroller';
      var baseurl='app/pages/bando/'

      // $stateProvider
      //     .state('bando', {
      //       url: '/bando',
      //       //template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
      //       templateUrl: baseurl+'bando.html',
      //       controller:controller,
      //       abstract: false,
      //       title: 'Bản đồ',
      //       sidebarMeta: {
      //         icon: 'ion-grid',
      //         order: 110,
      //       },
      //     });
    }
  
  })();
  