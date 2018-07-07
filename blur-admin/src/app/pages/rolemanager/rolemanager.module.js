/**
 * @author Tran Ngoc Minh
 * created on 
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.rolemanager', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
      var controller='rolemanagercontroller';
      var baseurl='app/pages/rolemanager/'

      $stateProvider
          .state('rolemanager', {
            url: '/rolemanager',
            template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
            abstract: true,
            title: 'Role',
            sidebarMeta: {
              icon: 'ion-key',
              order: 110,
            },
          }).state('rolemanager.list', {
            url: '/list',
            templateUrl: baseurl+'table/list.html',
            controller: controller,
            title: 'Quản lý Role',
            sidebarMeta: {
              order: 0,
            },
          }).state('rolemanager.add', {
            url: '/add',
            templateUrl: baseurl+'form/form.html',
            controller: controller,
            title: 'Thêm mới Role',
            sidebarMeta: {
              order: 100,
            },
          }).state('rolemanager.edit', {
            url: '/edit/:id',
            templateUrl: baseurl+'form/editform.html',
            controller: controller,
            title: 'Cập nhật nhóm phân quyền Role',
          });
      $urlRouterProvider.when('/rolemanager','/rolemanager/list');
    }
  
  })();
  