/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.nhanvien', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
      var controller='nhanviencontroller';
      var baseurl='app/pages/nhanvien/'

      $stateProvider
          .state('nhanvien', {
            url: '/nhanvien',
            template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
            abstract: true,
            title: 'Nhân viên',
            sidebarMeta: {
              icon: 'ion-person',
              order: 110,
            },
          }).state('nhanvien.list', {
            url: '/list',
            templateUrl: baseurl+'table/list.html',
            controller: controller,
            title: 'Quản lý nhân viên',
            sidebarMeta: {
              order: 0,
            },
          }).state('nhanvien.add', {
            url: '/add',
            templateUrl: baseurl+'form/form.html',
            controller: controller,
            title: 'Thêm nhân viên',
            sidebarMeta: {
              order: 100,
            },
          }).state('nhanvien.edit', {
            url: '/edit/:id',
            templateUrl: baseurl+'form/editform.html',
            controller: controller,
            title: 'Sửa nhân viên',
          });
      $urlRouterProvider.when('/nhanvien','/nhanvien/list');
    }
  
  })();
  