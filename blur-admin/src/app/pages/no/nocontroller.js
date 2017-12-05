(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.no')
        .controller('nocontroller', TablesPageCtrl);
    function TablesPageCtrl($scope,$state, $filter,GetNoAPI,$stateParams) {
        $scope.resdata={};
        $scope.model={};

        $scope.init = function () {

            GetNoAPI.no_get_all(null,null).success(function(response) {
                
                $scope.resdata = response.data;                    
                
            });

        }

        $scope.gotoAddNo=function(){
            $state.go('no.add');
        }

        // add No
        $scope.addNo=function(model){

            GetNoAPI.no_create(model)

            .success(function (data, status) {
                
                $state.go('no.list');
                
            }).error(function (data, status) {

                alert('Dường như đã có lỗi nào đó xảy ra! \n' + status);

            });
            
        };

        //get by id No
        $scope.getById = function(){
            GetNoAPI.no_getby_id($stateParams)
            .success(function(data){
                
                $scope.model = data;

            }).error(function(){
                $scope.errorMessage="Không thể lấy dữ liệu có mã là "+ $stateParams + "!";
                //console.log($scope.errorMessage);
            });
        };

        //edit No
        $scope.editNo=function(model){
          
            GetNoAPI.no_update(model)         
            .success(function (data, status) {
                
                $state.go('no.list');
                
            }).error(function (data, status) {

                $scope.errorMessage="Không thể update dữ liệu !";
                alert('Dường như đã có lỗi nào đó xảy ra!');

            });
            
        };

        //delete No
        $scope.deleteNo=function(id){
            GetNoAPI.no_delete(id)
            .success(function(data,status){          
                $state.go('no.list', {}, { reload: true });
            }).error(function(data,status){
                alert('Dường như đã có lỗi nào đó xảy ra! Xóa user thất bại');
            });

        };
    }  
})();