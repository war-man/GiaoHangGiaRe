(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.bando')
        .controller('bandocontroller', bandocontroller);
    function bandocontroller($scope,$timeout) {

        $scope.googleMapsUrl="https://maps.googleapis.com/maps/api/js?key=AIzaSyC8vez2woeH1gzyog7_CO5M7DpzqNDl83Q&callback=initMap";

        function initialize() {
            var mapCanvas = document.getElementById('google-maps');
            var mapOptions = {
              center: new google.maps.LatLng(21.022736,105.8019441,13),
              zoom: 14,
              mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(mapCanvas, mapOptions);
          }
      
          $timeout(function(){
            initialize();
          }, 100);
    }  
})();