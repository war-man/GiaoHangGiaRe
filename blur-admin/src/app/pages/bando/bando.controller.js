(function () {
    'use strict';

    angular.module('BlurAdmin.pages.bando').controller('bandocontroller', bandocontroller);
    function bandocontroller($scope, $timeout ,$rootScope) {
        $rootScope. maphub.client.DanhSachOnline = function (data) {
           console.log(data);
           $scope.$apply(function (){
            $scope.danhSachonline = data;
            })
        }

        $rootScope.maphub.client.layToaDo = function (data) {
            $scope.$apply(function (){
                $scope.layToaDo = data;
            })    
         }

        $.connection.hub.start().done(function () {
            $rootScope.maphub.server.guiToaDo(123,321);
        });



        function initMap() {
            var mapCanvas = document.getElementById('google-maps');
            var mapOptions = {
                center: new google.maps.LatLng(21.022736, 105.8019441, 13),
                zoom: 14,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(mapCanvas, mapOptions);
        }
        $timeout(function(){
            initMap();
          }, 100);
    }
})();