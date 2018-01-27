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
angular.module('BlurAdmin').constant('BASE', 'http://localhost:8195/');

// angular.module('BlurAdmin', ['ng.epoch','n3-pie-chart']);
angular.module('BlurAdmin').value('backendServerUrl', 'http://localhost:8195/');
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
    }
    $rootScope.logout = function () {
        localStorage.removeItem("token");
        window.location = "/auth.html";
    }
    console.log('chạy app run');
    $rootScope.$on("$locationChangeStart", function (event, next, current) {
    });
}
]);

//
angular.module("BlurAdmin").factory('backendHubProxy', ['$rootScope', 'backendServerUrl', function ($rootScope, backendServerUrl) {
    function backendFactory(serverUrl, hubName) {
        // console.log(serverUrl);
        // console.log(hubName);
        var connection = $.hubConnection(backendServerUrl);
        var proxy = connection.createHubProxy(hubName);
        console.log(connection);
        console.log(proxy);
        connection.start().done(function () { });

        return {
            on: function (eventName, callback) {
                proxy.on(eventName, function (result) {
                    $rootScope.$apply(function () {
                        if (callback) {
                            callback(result);
                        }
                    });
                });
            },
            invoke: function (methodName, callback) {
                proxy.invoke(methodName)
                    .done(function (result) {
                        $rootScope.$apply(function () {
                            if (callback) {
                                callback(result);
                            }
                        });
                    });
            }
        };
    };
    return backendFactory;
}]);