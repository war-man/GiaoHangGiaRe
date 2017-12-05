/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.lichsu', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
      var controller='lichsucontroller';
      var baseurl='app/pages/lichsu/'

      $stateProvider
          .state('lichsu', {
            url: '/lichsu',
            //template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
            templateUrl: baseurl+'table/list.html',
            controller: controller,
            abstract: false,
            title: 'Lịch sử',
            sidebarMeta: {
              icon: 'ion-ios-filing-outline',
              order: 110,
            },
            authenticate: true
          });
    }
  
  })();
  