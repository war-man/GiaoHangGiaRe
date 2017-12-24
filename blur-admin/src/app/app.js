'use strict';

angular.module('BlurAdmin', [
  'ngAnimate',
  'ui.bootstrap',
  'ui.sortable',
  'ui.router',
  'ngTouch',
  'toastr',
  'smart-table',
  "xeditable",
  'ui.slimscroll',
  'ngJsTree',
  'angular-progress-button-styles',

  
  'BlurAdmin.theme',
  'BlurAdmin.pages'
]);

/* Init global settings request run the app */
angular.module("BlurAdmin").config([ function () {
  
      var auth = localStorage.getItem("token");// Không có token sẽ nhảy về auth.html
  
      if (auth == undefined) {
          window.location = "/auth.html";
      }
  
      //auth = JSON.parse(auth);
    //   if(auth!=null){
    //       var token = auth.accessToken;
          
    //   }
     
  }]);

  angular.module("BlurAdmin").run(["$rootScope", "$state", function ($rootScope, $state) {
    
        $rootScope.logout = function () {
            localStorage.removeItem("token");
            window.location = "/auth.html";
        }
        console.log('chạy app run');
    
        $rootScope.$on("$locationChangeStart", function (event, next, current) {
        });
    
       
    }]);