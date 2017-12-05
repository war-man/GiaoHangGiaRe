(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.khachhang')
        .controller('khachhangcontroller', khachhangcontroller);
    function khachhangcontroller($scope, $filter,$state,$stateParams,GetKhachHangAPI) {
        $scope.resdata={};
        $scope.model={};

        $scope.init = function () {

            GetKhachHangAPI.khachhang_get_all(null,null).success(function(response) {
                
                $scope.resdata = response.data;        
                
            });

        }

        $scope.gotoAddKhachHang=function(){
            $state.go('khachhang.add');
        }

        // add khachhang
        $scope.addKhachHang=function(model){

            GetKhachHangAPI.khachhang_create(model)

            .success(function (data, status) {
                
                $state.go('khachhang.list');
                
            }).error(function (data, status) {

                alert('Dường như đã có lỗi nào đó xảy ra! \n' + status+'\n'+ data.Message);

            });
            
        };

        //get by id KhachHang
        $scope.getById = function(){
            GetKhachHangAPI.khachhang_getby_id($stateParams)
            .success(function(data){
                
                $scope.model = data;

            }).error(function(){
                $scope.errorMessage="Không thể lấy dữ liệu có mã là "+ $stateParams + "!";
                //console.log($scope.errorMessage);
            });
        };

        //edit KhachHang
        $scope.editKhachHang=function(model){
            console.log(model);
            GetKhachHangAPI.khachhang_update(model)         
            .success(function (data, status) {
                
                $state.go('khachhang.list');
                
            }).error(function (data, status) {

                $scope.errorMessage="Không thể update dữ liệu !";
                alert('Dường như đã có lỗi nào đó xảy ra!');

            });
            
        };

        //delete KhachHang
        $scope.deleteKhachHang=function(id){
            GetKhachHangAPI.khachhang_delete(id)
            .success(function(data,status){          
                $state.go('khachhang.list', {}, { reload: true });
            }).error(function(data,status){
                alert('Dường như đã có lỗi nào đó xảy ra! Xóa user thất bại');
            });

        };

    }  
})();