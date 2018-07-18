(function () {
    'use strict';

    angular.module('BlurAdmin.pages.rolemanager')
        .controller('rolemanagercontroller', rolemanagercontroller);
    function rolemanagercontroller($scope, $stateParams, $state, GetRoleAPI, $uibModal) {

        $scope.resdata = {};
        $scope.model;

        $scope.init = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetRoleAPI.role_get_all(null, 10).success(function (response) {
                $scope.resdata = response.data;
                $scope.modal.dismiss();
            });
        }

        //get Role By Role.Id (string)
        $scope.getById = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetRoleAPI.role_getby_id($stateParams)
                .success(function (data) {
                    $scope.model = data;
                    $scope.modal.dismiss();
                }).error(function () {
                    $scope.errorMessage = "Không thể lấy dữ liệu có mã là " + $stateParams + "!";
                    $scope.modal.dismiss();
                });

        };

        $scope.addRole = function (model) {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetRoleAPI.role_create(model)
                .success(function () {
                    $scope.modal.dismiss();
                    $state.go('rolemanager.list', {}, { reload: true });
                }).error(function () {
                    $scope.modal.dismiss();
                });
        };


        $scope.deleteRole = function (id) {
            GetRoleAPI.role_delete(id)
                .success(function () {
                    $state.go('rolemanager.list', {}, { reload: true });
                }).error(function () {
                    alert('Dường như đã có lỗi nào đó xảy ra! Xóa Role thất bại');
                });
        };

        $scope.updateRole = function (model) {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetRoleAPI.role_update(model)
                .success(function () {
                    $scope.modal.dismiss();
                    $state.go('rolemanager.list', {}, { reload: true });
                }).error(function (data, status) {
                    $scope.modal.dismiss();
                    alert('Dường như đã có lỗi nào đó xảy ra!' + status + data.Message);
                });
        };
        $scope.listUserOfRole = function (roleId) {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetRoleAPI.get_user_of_role({ role: roleId })
                .success(function (data) {
                    $scope.modal.dismiss();
                    $uibModal.open({
                        animation: true,
                        templateUrl: 'app/pages/ui/modals/modalTemplates/roleOfUser.html',
                        controller: function ($scope) {
                            $scope.listUser = data;
                            $scope.role = roleId;
                        },
                    }).result.then(function (data) {
                    }, function () {
                    });
                }).error(function (data) {
                    $scope.modal.dismiss();
                    alert('Dường như đã có lỗi nào đó xảy ra!');
                });
        }
    }
})();