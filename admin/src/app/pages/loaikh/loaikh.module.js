/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.loaikh', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
      var controller='loaikhcontroller';
      var baseurl='app/pages/loaikh/'

      $stateProvider
          .state('loaikh', {
            url: '/loaikh',
            template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
            abstract: true,
            title: 'Loại khách hàng',
            sidebarMeta: {
              icon: 'ion-grid',
              order: 110,
            },
          }).state('loaikh.list', {
            url: '/loaikh',
            templateUrl: baseurl+'table/list.html',
            controller: controller,
            title: 'Quản lý loại khách',
            sidebarMeta: {
              order: 0,
            },
          }).state('loaikh.add', {
            url: '/add',
            templateUrl: baseurl+'form/form.html',
            controller: controller,
            title: 'Thêm lọai khách',
            sidebarMeta: {
              order: 100,
            },
          }).state('loaikh.edit', {
            url: '/edit/:id',
            templateUrl: baseurl+'form/editform.html',
            controller: controller,
            title: 'Sửa thông tin loại khách hàng',         
          });
      $urlRouterProvider.when('/loaikh','/loaikh/list');
    }
  
  })();
  