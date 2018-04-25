(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.no')
        .controller('nocontroller', TablesPageCtrl);
    /** @ngInject */
    function TablesPageCtrl($scope,$state, $filter,GetNoAPI,$stateParams) {
        $scope.resdata={};
        $scope.model={};
        $scope.Size = 1000;
        $scope.listNo = {};

        $scope.tablePage = {currenPage: 0};
        $scope.currentstate = $state.current.name;
        $scope.errorMessage;
        $scope.filter = {};
        $scope.params = { page: $scope.tablePage.currenPage, size: $scope.Size };

        innitTableParams($scope.Size, 0);
        $scope.init = function () {
            GetNoAPI.no_get_all($scope.params).success(function(response) {           
                $scope.listNo = response.data;                    
            });

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
        $scope.gotoAddNo=function(){
            $state.go('no.add');
        }

        //SEARCH
        $scope.search = function () {
            if($scope.filter.kyhieu){
                if($scope.filter.kyhieu!=""){
                    $scope.params.kyhieu = $scope.filter.kyhieu;
                }
            }else{
                $scope.params.kyhieu = null;
            }
            GetNoAPI.no_get_all($scope.params).then((res) => {
                if (res.status == '200') {
                    $scope.listNo = res.data.data;
                }
            })
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
        // $scope.getById = function(){
        //     GetNoAPI.no_getby_id($stateParams)
        //     .success(function(data){
                
        //         $scope.model = data;

        //     }).error(function(){
        //         $scope.errorMessage="Không thể lấy dữ liệu có mã là "+ $stateParams + "!";
        //         //console.log($scope.errorMessage);
        //     });
        // };

        //edit No
        // $scope.editNo=function(model){
          
        //     GetNoAPI.no_update(model)         
        //     .success(function (data, status) {
                
        //         $state.go('no.list');
                
        //     }).error(function (data, status) {

        //         $scope.errorMessage="Không thể update dữ liệu !";
        //         alert('Dường như đã có lỗi nào đó xảy ra!');

        //     });
            
        // };

        //delete No
        // $scope.deleteNo=function(id){
        //     GetNoAPI.no_delete(id)
        //     .success(function(data,status){          
        //         $state.go('no.list', {}, { reload: true });
        //     }).error(function(data,status){
        //         alert('Dường như đã có lỗi nào đó xảy ra! Xóa user thất bại');
        //     });

        // };
    }  
})();