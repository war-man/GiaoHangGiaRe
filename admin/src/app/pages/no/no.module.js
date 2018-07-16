/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.no', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
      var controller='nocontroller';
      var baseurl='app/pages/no/'

      $stateProvider
          .state('no', {
            url: '/no',
            template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
            abstract: true,
            title: 'Nợ',
            sidebarMeta: {
              icon: 'ion-grid',
              order: 110,
            },
          }).state('no.list', {
            url: '/list',
            templateUrl: baseurl+'table/list.html',
            controller: controller,
            title: 'Quản lý nợ',
            sidebarMeta: {
              order: 0,
            },
          }).state('no.add', {
            url: '/add',
            templateUrl: baseurl+'form/form.html',
            controller: controller,
            title: 'Thêm mới nợ',
            sidebarMeta: {
              order: 100,
            },
          }).state('no.edit', {
            url: '/edit/:id',
            templateUrl: baseurl+'form/editform.html',
            controller: controller,
            title: 'Cập nhật nợ',
          });
      $urlRouterProvider.when('/no','/no/list');
    }
  
  })();
  