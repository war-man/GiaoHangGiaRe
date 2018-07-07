var map, infoWindow;
var time = 5000; // Thiet lap thoi gian
var laodmap = setInterval(getlocl, time);
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 15
    });
    infoWindow = new google.maps.InfoWindow;
    //setTimeout(function, time)
    // Try HTML5 geolocation.
    if (navigator.geolocation) {
      
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            infoWindow.setPosition(pos);
            infoWindow.setContent('Đang trong quá trình giao hàng.');
            infoWindow.open(map);
            map.setCenter(pos);
            //$.connection.hub.start().done(function () {
            //    maphub.server.guiToaDo(pos.lat, pos.lng);
            //});
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}
function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
                          'Error: The Geolocation service failed.' :
                          'Error: Your browser doesn\'t support geolocation.');
    infoWindow.open(map);
}
function huyloadmap() {
    clearInterval(loadmap);
}
function getlocl() {
    if (navigator.geolocation) {

        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            $.connection.hub.start().done(function () {
                maphub.server.guiToaDo(pos.lat, pos.lng);            
            });
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    }
}