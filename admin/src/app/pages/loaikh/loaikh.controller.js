(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.loaikh')
        .controller('loaikhcontroller', loaikhcontroller);
    function loaikhcontroller($scope,$state, $filter,GetLoaiKHAPI,$stateParams, $uibModal) {

        $scope.resdata={};
        $scope.model={};

        $scope.init = function () {
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            GetLoaiKHAPI.loaikh_get_all(null,null).success(function(response) {
                $scope.resdata = response.data;                
                $scope.modal.dismiss();    
            }).error(function ( error) {
                $scope.modal.dismiss();
            });
        };

        $scope.gotoAddLoaiKH=function(){
            $state.go('loaikh.add');
        };

        // add LoaiKH
        $scope.addLoaiKH = function(model){
            GetLoaiKHAPI.loaikh_create(model)
            .success(function () {    
                $state.go('loaikh.list');
            }).error(function (data, status) {
                alert('Dường như đã có lỗi nào đó xảy ra! \n' + status);
            });    
        };

        //get by id LoaiKH
        $scope.getById = function(){
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });

            GetLoaiKHAPI.loaikh_getby_id($stateParams)
            .success(function(data){
                $scope.model = data;
                $scope.modal.dismiss();
            }).error(function(){
                $scope.modal.dismiss();
                $scope.errorMessage="Không thể lấy dữ liệu có mã là "+ $stateParams + "!";
            });
        };

        //edit LoaiKH
        $scope.editLoaiKH=function(model){
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });

            GetLoaiKHAPI.loaikh_update(model)         
            .success(function () {
                $scope.modal.dismiss();
                $state.go('loaikh.list');
            }).error(function () {
                $scope.errorMessage="Không thể update dữ liệu !";
                $scope.modal.dismiss();
            });
            
        };

        //delete LoaiKH
        $scope.deleteLoaiKH=function(id){
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });

            GetLoaiKHAPI.loaikh_delete(id)
            .success(function(){    
                $scope.modal.dismiss();      
                $state.go('loaikh.list', {}, { reload: true });
            }).error(function(error){
                $scope.modal.dismiss();
                $uibModal.open({
                    animation: false,
                    templateUrl: 'app/pages/ui/modals/modalTemplates/errormessage.html',
                    controller: function ($scope) {
                        $scope.title = error.Message;
                        $scope.content = error.Message;
                        $scope.ok = 'Đồng ý';
                    },
                })
            });
        };
    }  
})();