/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.donhang', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
      var controller='donhangcontroller';
      var baseurl='app/pages/donhang/'

      $stateProvider
          .state('donhang', {
            url: '/donhang',
            template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
            abstract: true,
            title: 'Đơn hàng',
            sidebarMeta: {
              icon: 'ion-drag',
              order: 110,
            },
          }).state('donhang.list', {
            url: '/list',
            templateUrl: baseurl+'table/list.html',
            controller: controller,
            title: 'Quản lý đơn hàng',
            sidebarMeta: {
              order: 0,
            },
          }).state('donhang.add', {
            url: '/add',
            templateUrl: baseurl+'form/form.html',
            controller: controller,
            title: 'Thêm đơn hàng',
            sidebarMeta: {
              order: 100,
            },
          }).state('donhang.report', {
            url: '/report',
            templateUrl: baseurl+'table/listdonhang.report.html',
            controller: controller,
            title: 'Đơn hàng vi phạm',
            sidebarMeta: {
              order: 100,
            },
          });
      $urlRouterProvider.when('/donhang','/donhang/list');
    }
  
  })();
  