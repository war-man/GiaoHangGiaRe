//Tran Ngoc Minh 
//17/10/2017
(function () {
    'use strict';
    angular.module('BlurAdmin.pages')
        .controller('usermanagercontroller', usermanagercontroller);
    /** @ngInject */
    function usermanagercontroller($scope, $rootScope, $state, $stateParams, GetRoleAPI, GetUserAPI, $filter, $uibModal, toastr,$timeout,baProgressModal) {
        $scope.tablePage = {};
        $scope.model = {};
        $scope.currentstate = $state.current.name;
        $scope.errorMessage;
        $scope.roleSelect;
        $scope.filter = {};
        $scope.params = {};
        $scope.gotoAddUser = function () {
            $state.go('usermanager.add');
        };

        GetRoleAPI.role_get_all().then(function (res) { //Lấy danh sách Role       
            $scope.roleSelect = res.data.data;
        });
        //GET BY ID
        $scope.getbyid = function () {
            GetUserAPI.user_getby_id($stateParams)
                .success(function (data) {
                    $scope.model = data;
                }).error(function () {
                    $scope.errorMessage = "Không thể lấy dữ liệu có mã là " + $stateParams + "!";
                });
        };

        //SEARCH
        $scope.search = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            
            console.log($scope.modal);
            var params = {};
            if($scope.params.page != null){
                params.page = $scope.params.page;
            }
            if($scope.params.size != null){
                params.size = $scope.params.size;
            }
            if($scope.filter.user_name != null){
                params.user_name = $scope.filter.user_name;
            }
            if($scope.filter.name != null){
                params.name = $scope.filter.name;
            }
            if($scope.filter.id != null){
                params.id = $scope.filter.id;
            }

            GetUserAPI.user_get_all(params).then((res) => {
                if (res.status == '200') {
                    $scope.listUser = res.data.data;
                    $scope.arrayPage = [];
                    for (var i = 0; i < Math.round(res.data.total/res.data.size); i++) {
                        $scope.arrayPage.push(i);
                    }
                }
                $scope.modal.dismiss();
            })
        }

        //EDIT USER
        $scope.editUser = function (model) {
            GetUserAPI.user_update(model)
                .success(function (data, status) {
                    $state.go('usermanager.list')
                }).error(function (data, status) {
                    $scope.errorMessage = "Không thể update dữ liệu !";
                    alert('Dường như đã có lỗi nào đó xảy ra!');
                });
        };

        //DELETE USER
        $scope.deleteUser = function (id) {
            var modal = $uibModal.open({
                animation: true,
                templateUrl: 'app/pages/ui/modals/modalTemplates/basicModal.html',
                controller: function ($scope, $uibModalInstance) {
                    $scope.message = 'Bạn có chắc muốn xóa người dùng ' + id + '?';
                    $scope.title = 'Xóa user ' + id;
                    $scope.ok = 'Đồng ý';
                },
            }).result.then(function (data) {
                GetUserAPI.user_delete(id).success(function (data, status) {
                    $state.go('usermanager.list', {}, { reload: true });
                })
            }, function () {
            });
        }

        //EDIT ROLES USER
        $scope.editRolesUser = function (user ,roleSelect = $scope.roleSelect) {
            var modal = $uibModal.open({
                animation: true,
                templateUrl: 'app/pages/ui/modals/modalTemplates/editRolesUser.html',
                controller: function ($scope, $uibModalInstance) {
                    $scope.title = 'Sửa roles của user có id là:  ' + user.Id;
                    $scope.ok = 'Đồng ý';
                    $scope.roles = [];
                    for(let i =0; i< user.Roles.length; i++){
                        $scope.roles.push(user.Roles[i].RoleId)
                    }
                    console.log($scope.roles);
                    $scope.roleSelect = roleSelect;
                },
            }).result.then(function (data) {
                let input = {userId: user.Id,roleId: data};
                GetUserAPI.user_add_roles(input).success(function (res) {
                    $state.go('usermanager.list', {}, { reload: true });
                })
            }, function () {
            });
        }

        //Add USER 
        $scope.addUser = function (model) {
            if(model.SelectRole){
                model.Role = model.SelectRole.value.Name.Name; // Chuyển giá trị từ select role vào role
            }else{
                model.Role = [];
            }
            GetUserAPI.user_create(model)
                .success(function (Response) {
                    if (!Response.Succeeded) {
                        $scope.errorMessage = Response.Errors;
                    }
                    else {
                        $state.go('usermanager.list');
                    }
                }).error(function (data, status) {
                    $scope.errorMessage = 'Dường như đã có lỗi nào đó xảy ra!';
                });
        };
    };
})();