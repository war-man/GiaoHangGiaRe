(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.rolemanager')
        .controller('rolemanagercontroller', rolemanagercontroller);
    function rolemanagercontroller($scope,$rootScope,$stateParams, $state,GetRoleAPI) {

        $scope.resdata={};
        $scope.model;

        $scope.init = function () {

            GetRoleAPI.role_get_all(null,null).success(function(response) {
                
                $scope.resdata = response.data;            
                
            });

        }

        //get Role By Role.Id (string)
        $scope.getById=function(){
            GetRoleAPI.role_getby_id($stateParams)
            .success(function(data){
                
                $scope.model = data;

            }).error(function(){
                $scope.errorMessage="Không thể lấy dữ liệu có mã là "+ $stateParams + "!";
                console.log($scope.errorMessage);
            });

        };

        $scope.addRole=function(model){
            //console.log(model);

            GetRoleAPI.role_create(model)

            .success(function (data, status) {
                
                $state.go('rolemanager.list',{},{reload:true});
                
            }).error(function (data, status) {

                alert('Dường như đã có lỗi nào đó xảy ra!' + status+ data.Message);

            });
            
        };


        $scope.deleteRole=function(id){
            GetRoleAPI.role_delete(id)
            .success(function(data,status){          
                $state.go('rolemanager.list', {}, { reload: true });
            }).error(function(data,status){
                alert('Dường như đã có lỗi nào đó xảy ra! Xóa Role thất bại');
            });
        };

        $scope.updateRole=function(model){
            //console.log(model);

            GetRoleAPI.role_update(model)

            .success(function (data, status) {
                
                $state.go('rolemanager.list',{},{reload:true});
                
            }).error(function (data, status) {

                alert('Dường như đã có lỗi nào đó xảy ra!' + status+ data.Message);

            });
            
        };

    }  
})();