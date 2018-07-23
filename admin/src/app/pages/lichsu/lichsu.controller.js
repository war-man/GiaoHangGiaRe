(function () {
    'use strict';
    angular.module('BlurAdmin.pages.lichsu')
        .controller('lichsucontroller', lichsucontroller);
    /** @ngInject */

    function lichsucontroller($scope, GetLichSuAPI, $uibModal) {
        $scope.params = {};
        $scope.params.size = 15;

        $scope.search = function(){
            $scope.modal = $uibModal.open({
                animation: false,
                templateUrl: 'app/pages/ui/modals/modalTemplates/loading.html'
            });
            var params = $scope.params;
            $scope.resdata = {};
            GetLichSuAPI.lichsu_get_all(params).success(function (res) {
                $scope.resdata = res.data;
                $scope.params.page = res.page;
                $scope.arrayPage = [];
                for (var i = 0; i < Math.ceil(res.total / res.size); i++) {
                    $scope.arrayPage.push(i);
                }
                $scope.modal.dismiss();
            }).error(function () {
                $scope.modal.dismiss();
            });
        }
    }
})();