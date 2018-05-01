(function () {
    'use strict';
    angular.module('BlurAdmin.pages.dashboard')
        .controller('dashboardcontroller', dashboardcontroller);
    function dashboardcontroller($scope, $filter, GetDashBoardAPI, $state, $stateParams) {
        $scope.dashboard = {};
        GetDashBoardAPI.get_so_nhanvien().then((res) => {
            console.log(res.data);
            $scope.dashboard.soNhanVien = res.data;
        });
        GetDashBoardAPI.get_nhanvien().then((res) => {
            console.log(res.data);
            $scope.dashboard.getNhanVien = res.data;
        })
        GetDashBoardAPI.get_so_donhangdanggiao().then((res) => {
            console.log(res.data);
            $scope.dashboard.soDHDangGiao = res.data;
        })
        GetDashBoardAPI.get_so_donhanglayhang().then((res) => {
            console.log(res.data);
            $scope.dashboard.soDHLayHang = res.data;
        })
        GetDashBoardAPI.get_so_donhangvaokho().then((res) => {
            console.log(res.data);
            $scope.dashboard.soDHVaoKho = res.data;
        })
        GetDashBoardAPI.get_so_donhangcho().then((res) => {
            console.log(res.data);
            $scope.dashboard.soDHCho = res.data;
        })
    }
})();