(function () {
    'use strict';
    angular.module('BlurAdmin.pages.donhang')
        .controller('donhangcontroller', donhangcontroller);
    function donhangcontroller($scope, $filter, GetDonHangAPI) {
        $scope.resdata={};
        $scope.model;
        
        GetDonHangAPI.donhang_get_all({page: 0, size: 10}).success(function(response) {
            $scope.resdata = response.data;            
        });
    }
})();