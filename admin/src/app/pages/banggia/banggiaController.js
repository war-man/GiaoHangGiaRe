(function() {
	"use strict";
	angular
		.module("BlurAdmin.pages.banggia")
		.controller("banggiacontroller", banggiacontroller);
	function banggiacontroller($scope, $state, $stateParams, GetBangGiaAPI) {
		$scope.resdata = {};
		$scope.model = {};
		$scope.init = function() {
			GetBangGiaAPI.banggia_get_all(null, null).success(function(response) {
				$scope.resdata = response.data;
			});
		};
		$scope.gotoAddBangGia = function() {
			$state.go("banggia.add");
		};

		// add banggia
		$scope.addBangGia = function(model) {
			GetBangGiaAPI.banggia_create(model)
				.success(function(data, status) {
					$state.go("banggia.list");
				})
				.error(function(data, status) {
					alert(
						"Dường như đã có lỗi nào đó xảy ra! \n" +
							status +
							"\n" +
							data.Message
					);
				});
		};

		//get by id BangGia
		$scope.getById = function() {
			GetBangGiaAPI.banggia_getby_id($stateParams)
				.success(function(data) {
					$scope.model = data;
				})
				.error(function() {
					$scope.errorMessage =
						"Không thể lấy dữ liệu có mã là " + $stateParams + "!";
				});
		};

		//edit BangGia
		$scope.editBangGia = function(model) {
			console.log(model);
			GetBangGiaAPI.banggia_update(model)
				.success(function(status) {
					$state.go("banggia.list");
				})
				.error(function(status) {
					$scope.errorMessage = "Không thể update dữ liệu !";
					alert("Dường như đã có lỗi nào đó xảy ra!");
				});
		};

		//delete BangGia
		$scope.deleteBangGia = function(id) {
			GetBangGiaAPI.banggia_delete(id)
				.success(function(data, status) {
					$state.go("banggia.list", {}, { reload: true });
				})
				.error(function(data, status) {
					alert("Dường như đã có lỗi nào đó xảy ra! Xóa user thất bại");
				});
		};
	}
})();
