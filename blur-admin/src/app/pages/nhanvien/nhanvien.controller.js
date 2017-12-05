(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.nhanvien')
        .controller('nhanviencontroller', nhanviencontroller);
    function nhanviencontroller($scope,$state, $filter,GetNhanVienAPI,$stateParams,$uibModal
    ,baProgressModal,$timeout) {

        $scope.resdata={};
        $scope.model={};

        $scope.init = function () {

            GetNhanVienAPI.nhanvien_get_all(null,null).success(function(response) {
                
                $scope.resdata = response.data;                    
                
            });

        }

        $scope.gotoAddNhanVien=function(){
            $state.go('nhanvien.add');
        }

        // add NhanVien
        $scope.addNhanVien=function(model){

            GetNhanVienAPI.nhanvien_create(model)

            .success(function (data, status) {
               
                $state.go('nhanvien.list');
                
            }).error(function (data, status) {

                

            });
            
        };

        //get by id NhanVien
        $scope.getById = function(){
            GetNhanVienAPI.nhanvien_getby_id($stateParams)
            .success(function(data){
                
                $scope.model = data;

            }).error(function(){
                $scope.errorMessage="Không thể lấy dữ liệu có mã là "+ $stateParams + "!";
                //console.log($scope.errorMessage);
            });
        };

        //edit NhanVien
        $scope.editNhanVien=function(model){
          
            GetNhanVienAPI.nhanvien_update(model)         
            .success(function (data, status) {
                
                $state.go('nhanvien.list');
                
            }).error(function (data, status) {

                $scope.errorMessage="Không thể update dữ liệu !";

            });
            
        };

        //delete NhanVien
        $scope.deleteNhanVien=function(id){
            
            GetNhanVienAPI.nhanvien_delete(id)
            .success(function(data,status){          
                $state.go('nhanvien.list', {}, { reload: true });
            }).error(function(data,status){
                alert('Dường như đã có lỗi nào đó xảy ra! Xóa user thất bại');
            });

        };

        //Modal
        $scope.open = function (page, size) {
            $uibModal.open({
              animation: true,
              templateUrl: page,
              size: size,
              resolve: {
                items: function () {
                  return $scope.items;
                }
              }
            });
          };
        $scope.openProgressDialog = baProgressModal.open;
        // baProgressModal.setProgress(0);
        
        // (function changeValue() {
        //     if (baProgressModal.getProgress() >= 100) {
        //         baProgressModal.close();
        //     } else {
        //         baProgressModal.setProgress(baProgressModal.getProgress() + 10);
        //         $timeout(changeValue, 300);
        //     }
        // })();
    }  
})();