(function () {
    'use strict';
    angular.module('BlurAdmin.pages.donhang')
        .controller('donhangcontroller', donhangcontroller);
    /** @ngInject */
    function donhangcontroller($scope, $filter, GetDonHangAPI, $state, $stateParams, $uibModal) {
        $scope.listDonHang = {};

        $scope.model = {};
        $scope.currentstate = $state.current.name;
        $scope.errorMessage;
        $scope.params = {};

        $scope.gotoAddDonHang = function () {
            $state.go('donhang.add');
        };

        //SEARCH
        $scope.search = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetDonHangAPI.donhang_get_all($scope.params)
            .success(res => {
                $scope.listDonHang = res.list;
                $scope.modal.dismiss();                
            }).error(function () {
                $scope.modal.dismiss();
            });
        }

        //Detail don hang
        $scope.details_don_hang = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetDonHangAPI.donhang_getby_id($stateParams)
            .success(res => {
                $scope.donhang = res.donhang;
                $scope.kienhang = res.kienhang;
                $scope.modal.dismiss();                
            }).error(function () {
                $scope.modal.dismiss();
            });
        }

        //Lấy đon hàng vi phạm
        $scope.getDonHangViPham = function () {
            GetDonHangAPI.donhang_vipham().then((res) => {
                if (res.status == '200') {
                    $scope.listDonHangViPham = res.data.list;
                    console.log($scope.listDonHangViPham);
                }
            })
        }

        //Them kien hang
        $scope.addKienHang = function () {
            $uibModal.open({
                animation: true,
                templateUrl: 'app/pages/ui/modals/modalTemplates/addKienHangModal.html',
                controller: function ($scope) {
                    $scope.ok = 'Đồng ý';
                },
            }).result.then(function () {
            }, function (data) {
                $scope.addKienHangCache(data);
            });
        }
        $scope.listKienHang = [];
        $scope.addKienHangCache = function (data) {
            $scope.listKienHang.push(data);
        }

        //Create Them Don Hang
        $scope.addDonHang = function () {
            let input = {};
            input.kienHang = $scope.listKienHang;
            input.donHang = $scope.model;
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetDonHangAPI.donhang_create(input)
                .success(function () {
                    $scope.modal.dismiss();
                }).error(function () {
                    $scope.modal.dismiss();
                });
        }

        //Xac nhan don hang
        $scope.xac_nhan_donhang = function (MaDonHang) {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });

            GetDonHangAPI.xac_nhan_donhang(MaDonHang)
                .success(function () {
                    $scope.modal.dismiss();
                    $state.go('donhang.list', {}, { reload: true });
                }).error(function () {
                    $scope.modal.dismiss();
                });
        }
    };
})();