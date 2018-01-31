(function () {
    'use strict';

    angular.module('BlurAdmin.pages.bando').controller('bandocontroller', bandocontroller);
    function bandocontroller($scope, $timeout, $rootScope) {
        $rootScope.maphub.client.DanhSachOnline = function (data) {
            console.log(data);
            $scope.$apply(function () {
                $scope.danhSachonline = data;
            })
        }

        $rootScope.maphub.client.layToaDo = function (data) {
            $scope.$apply(function () {
                $scope.layToaDo = data;
            })
        }

        $.connection.hub.start().done(function () {
            $rootScope.maphub.server.guiToaDo(123, 321);
        });



        function initMap() {
            var image = 'assets/img/app/map/posstion_maker.png';
            var mapCanvas = document.getElementById('google-maps');
            var mapOptions = {
                center: new google.maps.LatLng(21.022736, 105.8019441, 13),
                zoom: 14,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(mapCanvas, mapOptions);
            var infoWindow;
            infoWindow = new google.maps.InfoWindow;
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    var pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude
                    };
                    var beachMarker = new google.maps.Marker({
                        position: { lat: pos.lat, lng: pos.lng },
                        map: map,
                        icon: image
                    });
                    infoWindow.setPosition(pos);
                    
                    map.setCenter(pos);
                    google.maps.event.addListener(beachMarker, "mouseout", function () {
                        infoWindow.close();
                    })
                    google.maps.event.addListener(beachMarker, "mouseover", function () {
                        infoWindow.setContent('Vi tri nenenenenen.');
                        infoWindow.open(map);
                    });
                }, function () {
                    handleLocationError(true, infoWindow, map.getCenter());
                });
            } else {
                // Browser doesn't support Geolocation
                handleLocationError(false, infoWindow, map.getCenter());
            }

            function handleLocationError(browserHasGeolocation, infoWindow, pos) {
                infoWindow.setPosition(pos);
                infoWindow.setContent(browserHasGeolocation ? 'Error: The Geolocation service failed.' :
                    'Error: Your browser doesn\'t support geolocation.');
                infoWindow.open(map);
            }

        }
        $timeout(function () {
            initMap();
        }, 100);
    }
})();