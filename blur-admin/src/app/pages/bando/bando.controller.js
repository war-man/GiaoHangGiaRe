(function () {
    'use strict';

    angular.module('BlurAdmin.pages.bando').controller('bandocontroller', bandocontroller);
    function bandocontroller($scope, $timeout, backendHubProxy) {
        $scope.googleMapsUrl = "https://maps.googleapis.com/maps/api/js?key=AIzaSyC8vez2woeH1gzyog7_CO5M7DpzqNDl83Q&callback=initMap";

        function initialize() {
            var mapCanvas = document.getElementById('google-maps');
            var mapOptions = {
                center: new google.maps.LatLng(21.022736, 105.8019441, 13),
                zoom: 14,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(mapCanvas, mapOptions);
            console.log('trying to connect to service')
            var performanceDataHub = backendHubProxy(backendHubProxy.defaultServer, 'myHub');
            console.log('connected to service')
          console.log(performanceDataHub);

            performanceDataHub.on('broadcastPerformance', function (data) {
                // data.forEach(function (dataItem) {
                //     switch (dataItem.categoryName) {
                //         case 'Processor':
                //             break;
                //         case 'Memory':
                //             $scope.currentRamNumber = dataItem.value;
                //             break;
                //         case 'Network In':
                //             break;
                //         case 'Network Out':
                //             break;
                //         case 'Disk Read Bytes/Sec':
                //             break;
                //         case 'Disk Write Bytes/Sec':
                //             break;
                //         default:
                //             //default code block
                //             break;
                //     }
                // })
                console.log(data);
            })
        }
        $timeout(function () {
            initialize();
        }, 100);
    }
})();