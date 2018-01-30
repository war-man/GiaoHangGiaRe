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
angular.module('BlurAdmin').constant('BASE', 'http://117.0.11.152:8080/');

// angular.module('BlurAdmin', ['ng.epoch','n3-pie-chart']);
angular.module('BlurAdmin').value('backendServerUrl', 'http://117.0.11.152:8080');
/* Init global settings request run the app */
angular.module("BlurAdmin").config(["BASE", function (BASE) {

}]);

angular.module("BlurAdmin").run(["$rootScope", "$state", "$http", function ($rootScope, $state, $http) {
    var auth = localStorage.getItem("token");// Không có token sẽ nhảy về auth.html
    var token = JSON.parse(auth);
    if (auth == undefined) {
        window.location = "/auth.html";
    }
    else {
        $http.defaults.headers.common.Authorization = token.token_type + ' ' + token.access_token;
        $.signalR.ajaxDefaults.headers = { 'Authorization': token.token_type + ' ' + token.access_token};
        $.connection.hub.url = "http://117.0.11.152:8080/signalr";
        $rootScope.maphub = $.connection.myHub;
        $rootScope.maphub.client.SoNguoiOnline = function (data) {
            $rootScope.soNguoiOnline = data;
            console.log(data);
         }
    }
    $rootScope.logout = function () {
        localStorage.removeItem("token");
        window.location = "/auth.html";
    }

    $rootScope.$on("$locationChangeStart", function (event, next, current) {

    });
}
]);