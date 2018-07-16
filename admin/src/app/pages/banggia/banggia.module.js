/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.banggia', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
      var controller='banggiacontroller';
      var baseurl='app/pages/banggia/'

      $stateProvider
          .state('banggia', {
            url: '/banggia',
            template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
            abstract: true,
            title: 'Bảng giá',
            sidebarMeta: {
              icon: 'ion-clipboard',
              order: 110,
            },
            authenticate: true
          }).state('banggia.list', {
            url: '/list',
            templateUrl: baseurl+'table/list.html',
            controller: controller,
            title: 'Quản lý bảng giá',
            sidebarMeta: {
              order: 0,
            },
          }).state('banggia.add', {
            url: '/add',
            templateUrl: baseurl+'form/form.html',
            controller: controller,
            title: 'Thêm bảng giá',
            sidebarMeta: {
              order: 100,
            },
          }).state('banggia.edit', {
            url: '/edit/:id',
            templateUrl: baseurl+'form/editform.html',
            controller: controller,
            title: 'Sửa thông tin bảng giá',
           
          });
      $urlRouterProvider.when('/banggia','/banggia/list');
    }
  
  })();
  