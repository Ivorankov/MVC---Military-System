var googleMap = (function () {
    function initialize() {
        var lat = $("#Lat").attr("data-lat");
        var lgn = $("#Lgn").attr("data-lgn");
        var myLatlng = new google.maps.LatLng(lat, lgn);
        var mapOptions = {
            zoom: 8,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.TERRAIN
        };
        var map = new google.maps.Map(document.getElementById("map"),
            mapOptions);

        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: 'Hello World!'
        });

        //marker.SetMap(map);

    }

    return {
        initialize: initialize
    }
}())