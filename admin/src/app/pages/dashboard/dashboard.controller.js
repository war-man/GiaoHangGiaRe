(function() {
	"use strict";
	angular
		.module("BlurAdmin.pages.dashboard")
		.controller("dashboardcontroller", dashboardcontroller);
	function dashboardcontroller($scope, GetDashBoardAPI, $uibModal) {
		$scope.dashboard = {};
		$scope.modal = $uibModal.open({
			animation: false,
			templateUrl: "app/pages/ui/modals/modalTemplates/loading.html"
		});
		GetDashBoardAPI.get_so_nhanvien().then(res => {
			$scope.dashboard.soNhanVien = res.data;
		});
		GetDashBoardAPI.get_nhanvien().then(res => {
			$scope.dashboard.getNhanVien = res.data;
		});
		GetDashBoardAPI.get_so_donhangdanggiao().then(res => {
			$scope.dashboard.soDHDangGiao = res.data;
		});
		GetDashBoardAPI.get_so_donhanglayhang().then(res => {
			$scope.dashboard.soDHLayHang = res.data;
		});
		GetDashBoardAPI.get_so_donhangvaokho().then(res => {
			$scope.dashboard.soDHVaoKho = res.data;
		});
		GetDashBoardAPI.get_so_donhangcho().then(res => {
			$scope.dashboard.soDHCho = res.data;
			$scope.modal.dismiss();
		});
	}
})();
