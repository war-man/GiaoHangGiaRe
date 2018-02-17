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
angular.module('BlurAdmin').constant('BASE', 'http://116.111.54.160:8080/');

/* Init global settings request run the app */
angular.module("BlurAdmin").config(["BASE", function (BASE) {

}]);

angular.module("BlurAdmin").run(["BASE", "$rootScope", "$state", "$http", function (BASE, $rootScope, $state, $http) {
    var auth = localStorage.getItem("token");// Không có token sẽ nhảy về auth.html
    var token = JSON.parse(auth);
    if (auth == undefined) {
        window.location = "/auth.html";
    }
    else {
        $http.defaults.headers.common.Authorization = token.token_type + ' ' + token.access_token;
        $.signalR.ajaxDefaults.headers = { 'Authorization': token.token_type + ' ' + token.access_token };
        $.connection.hub.url = BASE + "signalr";
        $rootScope.maphub = $.connection.myHub;
        $rootScope.maphub.client.SoNguoiOnline = function (data) {
            $rootScope.$apply(function () {
                $rootScope.soNguoiOnline = data;
            })
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