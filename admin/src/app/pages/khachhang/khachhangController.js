(function () {
    'use strict';

    angular.module('BlurAdmin.pages.khachhang')
        .controller('khachhangcontroller', khachhangcontroller);
    function khachhangcontroller($scope, $uibModal, $state, $stateParams, GetKhachHangAPI) {
        $scope.resdata = {};
        $scope.model = {};
        $scope.params = {};

        $scope.search = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            var params = $scope.params;
            GetKhachHangAPI.khachhang_get_all(params).success(function (res) {
                $scope.resdata = res.data;
                $scope.arrayPage = [];
                for (var i = 0; i < Math.round(res.total / res.size); i++) {
                    $scope.arrayPage.push(i);
                }
                $scope.modal.dismiss();
            });
        }

        $scope.gotoAddKhachHang = function () {
            $state.go('khachhang.add');
        }

        // add khachhang
        $scope.addKhachHang = function (model) {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetKhachHangAPI.khachhang_create(model)
                .success(function (data, status) {
                    $scope.modal.dismiss();
                    $state.go('khachhang.list');
                }).error(function (data, status) {
                    $scope.modal.dismiss();
                    alert('Dường như đã có lỗi nào đó xảy ra! \n' + status + '\n' + data.Message);
                });
        };

        //get by id KhachHang
        $scope.getById = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetKhachHangAPI.khachhang_getby_id($stateParams)
                .success(function (data) {
                    $scope.model = data;
                    $scope.modal.dismiss();
                }).error(function () {
                    $scope.modal.dismiss();
                    $scope.errorMessage = "Không thể lấy dữ liệu có mã là " + $stateParams + "!";
                });
        };

        //edit KhachHang
        $scope.editKhachHang = function (model) {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetKhachHangAPI.khachhang_update(model)
                .success(function () {
                    $scope.modal.dismiss();
                    $state.go('khachhang.list');
                }).error(function () {
                    $scope.modal.dismiss();
                    $scope.errorMessage = "Không thể update dữ liệu !";
                    alert('Dường như đã có lỗi nào đó xảy ra!');
                });
        };

        //delete KhachHang
        $scope.deleteKhachHang = function (id) {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetKhachHangAPI.khachhang_delete(id)
                .success(function () {
                    $scope.modal.dismiss();
                    $state.go('khachhang.list', {}, { reload: true });
                }).error(function () {
                    $scope.modal.dismiss();
                    alert('Dường như đã có lỗi nào đó xảy ra! Xóa user thất bại');
                });
        };
    }
})();