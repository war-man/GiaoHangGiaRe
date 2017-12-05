//Tran Ngoc Minh 
//17/10/2017

(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.usermanager') 
        .controller('usermanagercontroller', usermanagercontroller);
        /** @ngInject */

  function usermanagercontroller($scope,$rootScope,$state,$stateParams,GetUserAPI,GetRoleAPI, $filter, editableOptions, editableThemes) {

        $scope.PageSize=5;
        $scope.resdata;
        $scope.model={};
        $scope.currentstate=$state.current.name;
        $scope.errorMessage;
        $scope.roleSelect;
        $scope.init = function () {          

        }
        GetUserAPI.user_get_all(null,null).success(function(response) {
            
            $scope.resdata = response.data;
            
        });
       
        $scope.gotoAddUser=function(){

            $state.go('usermanager.add');

        };

        GetRoleAPI.role_get_all(null,null).success(function(response) { //Lấy danh sách Role       
            $scope.roleSelect = response.data;
           
        });

        $scope.getbyid = function(){
            console.log($stateParams);
            GetUserAPI.user_getby_id($stateParams)
            .success(function(data){
                
                $scope.model = data;

            }).error(function(){
                $scope.errorMessage="Không thể lấy dữ liệu có mã là "+ $stateParams + "!";
                console.log($scope.errorMessage);
            });

        };

        $scope.editUser=function(model){
            //console.log(model);

            GetUserAPI.user_update(model)

            .success(function (data, status) {
                
                $state.go('usermanager.list');
                
            }).error(function (data, status) {

                $scope.errorMessage="Không thể update dữ liệu !";
                alert('Dường như đã có lỗi nào đó xảy ra!');

            });
            
        };

        $scope.deleteUser=function(id){
            GetUserAPI.user_delete(id)
            .success(function(data,status){          
                $state.go('usermanager.list', {}, { reload: true });
            }).error(function(data,status){
                alert('Dường như đã có lỗi nào đó xảy ra! Xóa user thất bại');
            });

        };

        $scope.addUser=function(model){
            model.Role=model.SelectRole.value.Name.Name; // Chuyển giá trị từ select role vào role
            console.log(model);
            GetUserAPI.user_create(model)

            .success(function (Response) {
                if(!Response.Succeeded){
                    $scope.errorMessage=Response.Errors;
                }
                else{
                    $state.go('usermanager.list');
                }            
            }).error(function (data, status) {

                $scope.errorMessage='Dường như đã có lỗi nào đó xảy ra!';

            });
            
        };

  };

})();