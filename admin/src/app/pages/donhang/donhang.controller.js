(function () {
    'use strict';
    angular.module('BlurAdmin.pages.donhang')
        .controller('donhangcontroller', donhangcontroller);
    /** @ngInject */
    function donhangcontroller($scope, $filter, GetDonHangAPI, $state, $stateParams, $uibModal) {
        $scope.listDonHang = {};
        $scope.Size = 5;

        $scope.tablePage = {};
        $scope.model = {};
        $scope.currentstate = $state.current.name;
        $scope.errorMessage;
        $scope.filter = {};
        $scope.params = { page: $scope.tablePage.currenPage, size: $scope.Size };
        $scope.gotoAddDonHang = function () {
            $state.go('donhang.add');
        };
        innitTableParams($scope.Size, 0);
        GetDonHangAPI.donhang_get_all($scope.params).then((res) => {
            if (res.status == '200') {
                $scope.listDonHang = res.data.list;
                innitTableParams($scope.Size, 0, res.data.total);
            }
        })
        $scope.gotoPage = function (page) {
            GetDonHangAPI.donhang_get_all($scope.params).then((res) => {
                if (res.status == '200') {
                    $scope.listDonHang = res.data.list;
                    innitTableParams($scope.Size, page, res.data.total);
                }
            })
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
        //SEARCH
        $scope.SelectChange = function (tinhtrang) {
            $scope.params.tinhtrang = $scope.filter.TinhTrang;
            $scope.search();
        }
        $scope.search = function () {
            $scope.params.user_name = $scope.filter.user_name;

            GetDonHangAPI.donhang_get_all($scope.params).then((res) => {
                if (res.status == '200') {
                    $scope.listDonHang = res.data.list;
                }
            })
        }

        //Lấy đon hàng vi phạm
        $scope.getDonHangViPham = function () {
            GetDonHangAPI.donhang_vipham().then((res) => {
                if (res.status == '200') {
                    $scope.listDonHangViPham = res.data.list;
                    console.log($scope.listDonHangViPham);
                }
            })
        }

        //Them don hang moi
        //Them kien hang
        $scope.editRolesUser = function () {
            var modal = $uibModal.open({
                animation: true,
                templateUrl: 'app/pages/ui/modals/modalTemplates/addKienHangModal.html',
                controller: function ($scope, $uibModalInstance) {
                    $scope.title = '';
                    $scope.ok = 'Đồng ý';
                    $scope.roles = [];

                },
            }).result.then(function (data) {
                let input = { userId: user.Id, roleId: data };
                GetUserAPI.user_add_roles(input).success(function (res) {
                    $state.go('donhang.list', {}, { reload: true });
                })
            }, function () {
            });
        }
    };
})();