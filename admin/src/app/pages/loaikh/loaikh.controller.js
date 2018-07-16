(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.loaikh')
        .controller('loaikhcontroller', loaikhcontroller);
    function loaikhcontroller($scope,$state, $filter,GetLoaiKHAPI,$stateParams) {

        $scope.resdata={};
        $scope.model={};

        $scope.init = function () {

            GetLoaiKHAPI.loaikh_get_all(null,null).success(function(response) {
                
                $scope.resdata = response.data;                    
                
            });

        };

        $scope.gotoAddLoaiKH=function(){
            $state.go('loaikh.add');
        };

        // add LoaiKH
        $scope.addLoaiKH = function(model){

            GetLoaiKHAPI.loaikh_create(model)

            .success(function (data, status) {
                
                $state.go('loaikh.list');
                
            }).error(function (data, status) {

                alert('Dường như đã có lỗi nào đó xảy ra! \n' + status);

            });
            
        };

        //get by id LoaiKH
        $scope.getById = function(){
            GetLoaiKHAPI.loaikh_getby_id($stateParams)
            .success(function(data){
                
                $scope.model = data;

            }).error(function(){
                $scope.errorMessage="Không thể lấy dữ liệu có mã là "+ $stateParams + "!";
                //console.log($scope.errorMessage);
            });
        };

        //edit LoaiKH
        $scope.editLoaiKH=function(model){
          
            GetLoaiKHAPI.loaikh_update(model)         
            .success(function (data, status) {
                
                $state.go('loaikh.list');
                
            }).error(function (data, status) {

                $scope.errorMessage="Không thể update dữ liệu !";
                alert('Dường như đã có lỗi nào đó xảy ra!');

            });
            
        };

        //delete LoaiKH
        $scope.deleteLoaiKH=function(id){
            GetLoaiKHAPI.loaikh_delete(id)
            .success(function(data,status){          
                $state.go('loaikh.list', {}, { reload: true });
            }).error(function(data,status){
                alert('Dường như đã có lỗi nào đó xảy ra!');
            });

        };
    }  
})();