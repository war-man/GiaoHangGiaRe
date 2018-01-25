//Tran Ngoc Minh 
//17/10/2017
(function () {
    'use strict';
    angular.module('BlurAdmin.pages')
        .controller('usermanagercontroller', usermanagercontroller);
    /** @ngInject */
    function usermanagercontroller($scope, $rootScope, $state, $stateParams, GetRoleAPI, GetUserAPI, $filter, $uibModal) {
        $scope.Size = 5;
        $scope.listUser;
        $scope.tablePage= {};
        $scope.model = {};
        $scope.currentstate = $state.current.name;
        $scope.errorMessage;
        $scope.roleSelect;
        $scope.gotoAddUser = function () {
            $state.go('usermanager.add');
        };
        GetUserAPI.user_get_all().then((res) => {
            if (res.status == '200') {
                $scope.listUser = res.data.data;
                innitTableParams($scope.Size, 0, res.data.total);
            }
        })
        $scope.gotoPage = function (page) {
            GetUserAPI.user_get_all(page, $scope.Size).then((res) => {
                if (res.status == '200') {
                    $scope.listUser = res.data.data;
                    innitTableParams($scope.Size, page, res.data.total);
                }
            })
        }
        function innitTableParams(size, currenPage, totalRecord){
            $scope.tablePage.totalRecord = totalRecord;
            $scope.tablePage.size = size;
            $scope.tablePage.totalPage = totalRecord/size;
            $scope.tablePage.currenPage = currenPage;
            $scope.tablePage.arrayPage= [];  
            for(var i=0;i< $scope.tablePage.totalPage;  i++){
                $scope.tablePage.arrayPage.push(i);
            }  
        }

        GetRoleAPI.role_get_all().then(function (res) { //Lấy danh sách Role       
            $scope.roleSelect = res.data.data;
            console.log($scope.roleSelect);
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
        $scope.deleteUser = function (page,id) {
           
                $uibModal.open({
                  animation: true,
                  templateUrl: page,
                //   size: size,
                  resolve: {
                    items: function () {
                    //   return $scope.items;
                    console.log(111);
                    }
                  }
                });
            
            // GetUserAPI.user_delete(id).success(function (data, status) {
            //         $state.go('usermanager.list', {}, { reload: true });
            //     })
        }
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