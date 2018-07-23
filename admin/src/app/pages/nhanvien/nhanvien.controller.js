(function () {
    'use strict';

    angular.module('BlurAdmin.pages.nhanvien')
        .controller('nhanviencontroller', nhanviencontroller);

    /** @ngInject */
    function nhanviencontroller($scope, $state, GetNhanVienAPI, $stateParams, $uibModal, toastr) {

        $scope.resdata = {};
        $scope.model = {};
        $scope.params = {};

        $scope.search = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            var params = {};
            if ($scope.params.page != null) {
                params.page = $scope.params.page;
            }
            if ($scope.params.size != null) {
                params.size = $scope.params.size;
            }
            if ($scope.params.TenTaiKhoan != null) {
                params.TenTaiKhoan = $scope.params.TenTaiKhoan;
            }
            if ($scope.params.ChucVu != null) {
                params.ChucVu = $scope.params.ChucVu;
            }
            if ($scope.params.Email != null) {
                params.Email = $scope.params.Email;
            }
            if ($scope.params.TenNhanVien != null) {
                params.TenNhanVien = $scope.params.TenNhanVien;
            }
            params.TrangThai = 1;
            GetNhanVienAPI.nhanvien_get_all(params)
                .success(function (res) {
                    $scope.resdata = res.data;
                    $scope.arrayPage = [];
                    for (var i = 0; i < Math.ceil(res.total / res.size); i++) {
                        $scope.arrayPage.push(i);
                    }
                    $scope.modal.dismiss();
                }).error(function () {
                    $scope.modal.dismiss();
                    toastr.error('Error');
                });
        }
        $scope.search_nhanvien_dung = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            var params = $scope.params;
            params.TrangThai = 0;
            GetNhanVienAPI.nhanvien_get_all(params)
            .success(function (res) {
                $scope.resdata = res.data;
                $scope.arrayPage = [];
                for (var i = 0; i < Math.ceil(res.total / res.size); i++) {
                    $scope.arrayPage.push(i);
                }
                $scope.modal.dismiss();
            }).error(function () {
                $scope.modal.dismiss();
                toastr.error('Error');
            });
        }
        $scope.gotoAddNhanVien = function () {
            $state.go('nhanvien.add');
        }

        // ADD NhanVien
        $scope.addNhanVien = function (model) {
            GetNhanVienAPI.nhanvien_create(model)
                .success(function () {
                    $state.go('nhanvien.list');
                }).error(function () {
                });
        };

        //GET BY ID NhanVien
        $scope.getById = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetNhanVienAPI.nhanvien_getby_id($stateParams)
                .success(function (data) {
                    $scope.model = data;
                    $scope.modal.dismiss();
                }).error(function () {
                    $scope.modal.dismiss();
                    toastr.error("Không thể lấy dữ liệu có mã là " + $stateParams + "!");
                    $scope.errorMessage = "Không thể lấy dữ liệu có mã là " + $stateParams + "!";
                });
        };

        //EDIT NhanVien
        $scope.editNhanVien = function (model) {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetNhanVienAPI.nhanvien_update(model)
                .success(function () {
                    $scope.modal.dismiss();
                    $state.go('nhanvien.list');
                }).error(function () {
                    $scope.modal.dismiss();
                    $scope.errorMessage = "Không thể update dữ liệu !";
                });
        };

        //Change ACTIVE NhanVien
        $scope.stopActiveNhanVien = function (nhan_vien) {
            $uibModal.open({
                animation: true,
                templateUrl: 'app/pages/ui/modals/modalTemplates/basicModal.html',
                controller: function ($scope) {
                    if(nhan_vien.TrangThai == 0){
                        $scope.message = 'Bạn có chắc muốn phục hồi nhân viên ' + nhan_vien.MaNhanVien + '?';
                        $scope.title = 'Phục hồi nhân viên ' + nhan_vien.MaNhanVien;
                    }else{
                        $scope.message = 'Bạn có chắc muốn dừng hoạt động nhân viên ' + nhan_vien.MaNhanVien + '?';
                        $scope.title = 'Nhân viên ngừng hoạt động ' + nhan_vien.MaNhanVien;
                    }
                    $scope.ok = 'Đồng ý';
                },
            }).result.then(function (data) {
                $scope.modal = $uibModal.open({
                    animation: false,
                    templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
                });
                GetNhanVienAPI.stop_active_nhanvien(nhan_vien.MaNhanVien).success(function () {
                    $scope.modal.dismiss();
                    $state.go('nhanvien.list', {}, { reload: true });
                })
            }, function () {
            });
        };
    }
})();