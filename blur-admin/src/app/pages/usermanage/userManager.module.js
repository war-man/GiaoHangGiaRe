/**
 * @author Tran Ngoc Minh
 * created on 10.17.2017
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.usermanager', [])
        .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
        var controller='usermanagercontroller';

        $stateProvider
            .state('usermanager', {
              url: '/usermanager',
              template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
              abstract: true,
              title: 'User',
              sidebarMeta: {
                order: 2,
                icon:'ion-person', 
              },
            }).state('usermanager.add', {
              url: '/add',
              templateUrl: '/app/pages/usermanage/form/form.html',
              controller: controller, 
              title: 'Thêm User',
              sidebarMeta: {
                order: 2,
              },
            }).state('usermanager.list', {
              url: '/list',
              templateUrl: '/app/pages/usermanage/table/list.html',
              controller: controller, 
              title: 'Quản lý User',
              sidebarMeta: {
                order: 1,
              },
            })
            .state('usermanager.edit', {
              url: '/edit/:id',
              templateUrl: '/app/pages/usermanage/form/editform.html',
              controller: controller,       
            })
            .state('usermanager.delete', {
              url: '/delete/:id',
              //templateUrl: '/app/pages/usermanage/table/list.html',
              controller: controller,       
            });
      $urlRouterProvider.when('/usermanager','/usermanager/list');
    }

  })();