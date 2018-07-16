/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.hoadon', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
      var controller='hoadoncontroller';
      var baseurl='app/pages/hoadon/'

      $stateProvider
          .state('hoadon', {
            url: '/hoadon',
            templateUrl: baseurl+'table/list.html',
            controller: controller,
            abstract: false,
            title: 'Hóa đơn',
            sidebarMeta: {
              icon: 'ion-ios-pricetag-outline',
              order: 110,
            },
          // }).state('hoadon.list', {
          //   url: '/list',
          //   templateUrl: baseurl+'table/list.html',
          //   controller: controller,
          //   title: 'Quản lý hóa đơn',
          //   sidebarMeta: {
          //     order: 0,
          //   },
          // }).state('hoadon.add', {
          //   url: '/add',
          //   templateUrl: baseurl+'form/form.html',
          //   controller: controller,
          //   title: 'Thêm hóa đơn',
          //   sidebarMeta: {
          //     order: 100,
          //   },
          });
      $urlRouterProvider.when('/hoadon','/hoadon/list');
    }
  
  })();
  