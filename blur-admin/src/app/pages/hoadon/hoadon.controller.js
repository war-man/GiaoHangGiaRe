(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.hoadon')
        .controller('hoadoncontroller', hoadoncontroller);
    function hoadoncontroller($scope,$state, $filter,GetHoaDonAPI,$stateParams) {

        $scope.resdata={};
        $scope.model={};

        $scope.init = function () {

            GetHoaDonAPI.hoadon_get_all(null,null).success(function(response) {
                
                $scope.resdata = response.data;                    
                
            });

        }

        $scope.gotoAddHoaDon=function(){
            $state.go('hoadon.add');
        }

        // add HoaDon
        $scope.addHoaDon=function(model){

            GetHoaDonAPI.hoadon_create(model)

            .success(function (data, status) {
                
                $state.go('hoadon.list');
                
            }).error(function (data, status) {

                alert('Dường như đã có lỗi nào đó xảy ra! \n' + status);

            });
            
        };

        //get by id HoaDon
        $scope.getById = function(){
            GetHoaDonAPI.hoadon_getby_id($stateParams)
            .success(function(data){
                
                $scope.model = data;

            }).error(function(){
                $scope.errorMessage="Không thể lấy dữ liệu có mã là "+ $stateParams + "!";
                //console.log($scope.errorMessage);
            });
        };

        //edit HoaDon
        $scope.editHoaDon=function(model){
          
            GetHoaDonAPI.hoadon_update(model)         
            .success(function (data, status) {
                
                $state.go('hoadon.list');
                
            }).error(function (data, status) {

                $scope.errorMessage="Không thể update dữ liệu !";
                alert('Dường như đã có lỗi nào đó xảy ra!');

            });
            
        };

        //delete HoaDon
        $scope.deleteHoaDon=function(id){
            GetHoaDonAPI.hoadon_delete(id)
            .success(function(data,status){          
                $state.go('hoadon.list', {}, { reload: true });
            }).error(function(data,status){
                alert('Dường như đã có lỗi nào đó xảy ra! Xóa user thất bại');
            });

        };
    }  
})();