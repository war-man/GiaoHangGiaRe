(function () {
    'use strict';
    angular.module('BlurAdmin.pages.lichsu')
        .controller('lichsucontroller', lichsucontroller);
    /** @ngInject */
    
    function lichsucontroller($scope, $filter,toastr,GetLichSuAPI, editableOptions, editableThemes) {
        $scope.smartTablePageSize = 10;
        $scope.resdata={};
        $scope.model;
        //$scope.ad = 10;
        GetLichSuAPI.lichsu_get_all(null,null).success(function(response) {        
            $scope.resdata = response.data;
            $scope.editableTableData=response.data;
            //toastr.success('Your information has been saved successfully!');
        });
    }  
})();