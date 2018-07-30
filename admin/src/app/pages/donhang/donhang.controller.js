(function() {
	"use strict";
	angular
		.module("BlurAdmin.pages.donhang")
		.controller("donhangcontroller", donhangcontroller);
	/** @ngInject */
	function donhangcontroller(
		$scope,
		GetDonHangAPI,
		$state,
		$stateParams,
		$uibModal
	) {
		$scope.listDonHang = {};

		$scope.model = {};
		$scope.errorMessage;
		$scope.params = {};

		$scope.gotoAddDonHang = function() {
			$state.go("donhang.add");
		};

		//SEARCH
		$scope.search = function() {
			$scope.modal = $uibModal.open({
				animation: false,
				templateUrl: "app/pages/ui/modals/modalTemplates/loading.html"
			});
			GetDonHangAPI.donhang_get_all($scope.params)
				.success(res => {
					$scope.listDonHang = res.list;
					$scope.arrayPage = [];
					for (var i = 0; i < Math.ceil(res.total / res.size); i++) {
						$scope.arrayPage.push(i);
					}
					$scope.modal.dismiss();
				})
				.error(function() {
					$scope.modal.dismiss();
				});
		};

		//Detail don hang
		$scope.details_don_hang = function() {
			$scope.modal = $uibModal.open({
				animation: false,
				templateUrl: "app/pages/ui/modals/modalTemplates/loading.html"
			});
			GetDonHangAPI.donhang_getby_id($stateParams)
				.success(res => {
					$scope.donhang = res.donhang;
					$scope.kienhang = res.kienhang;
					$scope.modal.dismiss();
				})
				.error(function() {
					$scope.modal.dismiss();
				});
		};

		//Lấy đon hàng vi phạm
		$scope.getDonHangViPham = function() {
			$scope.modal = $uibModal.open({
				animation: false,
				templateUrl: "app/pages/ui/modals/modalTemplates/loading.html"
			});
			$scope.params.TinhTrang = -1;
			GetDonHangAPI.donhang_get_all($scope.params)
				.success(res => {
					$scope.listDonHang = res.list;
					$scope.arrayPage = [];
					for (var i = 0; i < Math.ceil(res.total / res.size); i++) {
						$scope.arrayPage.push(i);
					}
					$scope.modal.dismiss();
				})
				.error(function() {
					$scope.modal.dismiss();
				});
		};
		function validate() {
			var error = [];
			if ($scope.listKienHang.length == 0) {
				error.push("Kiên hàng bắt buộc.");
			}
			return error;
		}
		//Them kien hang
		$scope.addKienHang = function() {
			$uibModal
				.open({
					animation: true,
					templateUrl:
						"app/pages/ui/modals/modalTemplates/addKienHangModal.html",
					controller: function($scope) {
						$scope.ok = "Đồng ý";
					}
				})
				.result.then(
					function() {},
					function(data) {
						if (data && data != "backdrop click") {
							$scope.addKienHangCache(data);
						}
					}
				);
		};
		$scope.listKienHang = [];
		$scope.addKienHangCache = function(data) {
			$scope.listKienHang.push(data);
		};

		//Create Them Don Hang
		$scope.addDonHang = function() {
			var error = validate();
			if (error.length == 0) {
				var input = {};
				input.kienHang = $scope.listKienHang;
				input.donHang = $scope.model;
				$scope.modal = $uibModal.open({
					animation: false,
					templateUrl: "app/pages/ui/modals/modalTemplates/loading.html"
				});
				GetDonHangAPI.donhang_create(input)
					.success(function() {
						$scope.modal.dismiss();
						$state.go("donhang.list", {}, { reload: true });
					})
					.error(function() {
						$scope.modal.dismiss();
					});
			} else {
				$scope.validate_error = error[0];
			}
		};

		//Xac nhan don hang
		$scope.xac_nhan_donhang = function(MaDonHang) {
			$scope.modal = $uibModal.open({
				animation: false,
				templateUrl: "app/pages/ui/modals/modalTemplates/loading.html"
			});

			GetDonHangAPI.xac_nhan_donhang(MaDonHang)
				.success(function() {
					$scope.modal.dismiss();
					$state.go("donhang.list", {}, { reload: true });
				})
				.error(function() {
					$scope.modal.dismiss();
				});
		};

		//PUT HUY Don Hang
		$scope.huy_donhang = function(MaDonHang) {
			$scope.modal = $uibModal.open({
				animation: false,
				templateUrl: "app/pages/ui/modals/modalTemplates/loading.html"
			});
			GetDonHangAPI.huy_donhang(MaDonHang)
				.success(function() {
					$scope.modal.dismiss();
					$state.go("donhang.list", {}, { reload: true });
				})
				.error(function() {
					$scope.modal.dismiss();
				});
		};
	}
})();
