/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.khachhang', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
      var controller='khachhangcontroller';
      var baseurl='app/pages/khachhang/'

      $stateProvider
          .state('khachhang', {
            url: '/khachhang',
            template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
            abstract: true,
            title: 'Khách hàng',
            sidebarMeta: {
              icon: 'ion-ios-people-outline',
              order: 110,
            },
            authenticate: true
          }).state('khachhang.list', {
            url: '/list',
            templateUrl: baseurl+'table/list.html',
            controller: controller,
            title: 'Quản lý khách hàng',
            sidebarMeta: {
              order: 0,
            },
          }).state('khachhang.add', {
            url: '/add',
            templateUrl: baseurl+'form/form.html',
            controller: controller,
            title: 'Thêm khách hàng',
            sidebarMeta: {
              order: 100,
            },
          }).state('khachhang.edit', {
            url: '/edit/:id',
            templateUrl: baseurl+'form/editform.html',
            controller: controller,
            title: 'Sửa thông tin khách hàng',
           
          });
      $urlRouterProvider.when('/khachhang','/khachhang/list');
    }
  
  })();
  