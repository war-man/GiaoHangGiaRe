//Tran Ngoc Minh 
//17/10/2017
(function () {
    'use strict';
    angular.module('BlurAdmin.pages')
        .controller('usermanagercontroller', usermanagercontroller);
    /** @ngInject */
    function usermanagercontroller($scope, $rootScope, $state, $stateParams, GetRoleAPI, GetUserAPI, $filter, $uibModal, toastr) {
        $scope.Size = 50;
        $scope.listUser;
        $scope.tablePage = {};
        $scope.model = {};
        $scope.currentstate = $state.current.name;
        $scope.errorMessage;
        $scope.roleSelect;
        $scope.filter = {};
        $scope.params = { page: $scope.tablePage.currenPage, size: $scope.Size };
        $scope.gotoAddUser = function () {
            $state.go('usermanager.add');
        };
        innitTableParams($scope.Size, 0);
        Init();
        function Init() {
            GetUserAPI.user_get_all($scope.params).then((res) => {
                if (res.status == '200') {
                    $scope.listUser = res.data.data;
                    innitTableParams($scope.Size, 0, res.data.total);
                }
            })
        }
        $scope.gotoPage = function (page) {
            $scope.params.page = page;
            GetUserAPI.user_get_all($scope.params).then((res) => {
                if (res.status == '200') {
                    $scope.listUser = res.data.data;
                    innitTableParams($scope.Size, page, res.data.total);
                }
            })
        }
        function innitTableParams(size, currenPage, totalRecord) {
            $scope.tablePage.totalRecord = totalRecord;
            $scope.tablePage.size = size;
            $scope.tablePage.totalPage = totalRecord / size;
            $scope.tablePage.currenPage = currenPage;
            $scope.tablePage.arrayPage = [];
            for (var i = 0; i < $scope.tablePage.totalPage; i++) {
                $scope.tablePage.arrayPage.push(i);
            }
        }

        GetRoleAPI.role_get_all().then(function (res) { //Lấy danh sách Role       
            $scope.roleSelect = res.data.data;
        });

        $scope.getbyid = function () {
            console.log($stateParams);
            GetUserAPI.user_getby_id($stateParams)
                .success(function (data) {
                    $scope.model = data;
                }).error(function () {
                    $scope.errorMessage = "Không thể lấy dữ liệu có mã là " + $stateParams + "!";
                    console.log($scope.errorMessage);
                });
        };

        //SEARCH
        $scope.search = function () {
            $scope.params.page = 0;
            $scope.params.size = null;
            $scope.params.user_name = $scope.filter.user_name ? $scope.filter.user_name : null;
            $scope.params.user_id = $scope.filter.id ? $scope.filter.id : null;
            $scope.params.name = $scope.filter.name ? $scope.filter.name : null;
            GetUserAPI.user_get_all($scope.params).then((res) => {
                if (res.status == '200') {
                    $scope.listUser = res.data.data;
                    innitTableParams(res.data.size, res.data.page, res.data.total);
                }
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

        //Add USER 
        $scope.addUser = function (model) {
            model.Role = model.SelectRole.value.Name.Name; // Chuyển giá trị từ select role vào role
            console.log(model);
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