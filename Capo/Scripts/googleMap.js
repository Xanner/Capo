var map;
var cracovGeoLocation = { lat: 50.0646501, lng: 19.9449799 };

function addYourLocationButton(map, marker) {
    var controlDiv = document.createElement("div");

    var firstChild = document.createElement("button");
    firstChild.style.backgroundColor = "#fff";
    firstChild.style.border = "none";
    firstChild.style.outline = "none";
    firstChild.style.width = "28px";
    firstChild.style.height = "28px";
    firstChild.style.borderRadius = "2px";
    firstChild.style.boxShadow = "0 1px 4px rgba(0,0,0,0.3)";
    firstChild.style.cursor = "pointer";
    firstChild.style.marginRight = "10px";
    firstChild.style.padding = "0px";
    firstChild.title = "Your Location";
    controlDiv.appendChild(firstChild);

    var secondChild = document.createElement("div");
    secondChild.style.margin = "5px";
    secondChild.style.width = "18px";
    secondChild.style.height = "18px";
    secondChild.style.backgroundImage = "url(https://maps.gstatic.com/tactile/mylocation/mylocation-sprite-1x.png)";
    secondChild.style.backgroundSize = "180px 18px";
    secondChild.style.backgroundPosition = "0px 0px";
    secondChild.style.backgroundRepeat = "no-repeat";
    secondChild.id = "you_location_img";
    firstChild.appendChild(secondChild);

    window.google.maps.event.addListener(map, "dragend", function () {
        $("#you_location_img").css("background-position", "0px 0px");
    });

    firstChild.addEventListener("click", function () {
        var imgX = "0";
        var animationInterval = setInterval(function () {
            if (imgX === "-18") imgX = "0";
            else imgX = "-18";
            $("#you_location_img").css("background-position", imgX + "px 0px");
        }, 500);

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var latlng = new window.google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                marker.setPosition(latlng);
                map.setCenter(latlng);
                window.smoothZoom(map, 19, map.getZoom());
                clearInterval(animationInterval);
                $("#you_location_img").css("background-position", "-144px 0px");

                var infowindow = new google.maps.InfoWindow({
                    map: map,
                    position: latlng,
                    content:
                        "<h3>Twoja lokalizacja</h3>" +
                            "<h4>Latitude: " + position.coords.latitude + "</h4>" +
                            "<h4>Longitude: " + position.coords.longitude + "</h4>"
                });

                map.setCenter(latlng, infowindow);
            });
        }
        else {
            clearInterval(animationInterval);
            $("#you_location_img").css("background-position", "0px 0px");
        }
    });

    controlDiv.index = 1;
    map.controls[window.google.maps.ControlPosition.RIGHT_BOTTOM].push(controlDiv);
}

function smoothZoom(mapName, targetZoom, currentZoom) {
    if (currentZoom >= targetZoom) {
        return;
    }
    else {
        var changedZoom = window.google.maps.event.addListener(mapName, "zoom_changed", function () {
            window.google.maps.event.removeListener(changedZoom);
            smoothZoom(mapName, targetZoom, currentZoom + 1);
        });
        setTimeout(function () { mapName.setZoom(currentZoom) }, 100);
    }
}

function initMap() {
    window.google.maps.visualRefresh = true;

    map = new window.google.maps.Map(document.getElementById("map"), {
        zoom: 8,
        center: cracovGeoLocation
    });

    var myMarker = new window.google.maps.Marker({
        map: map,
        animation: window.google.maps.Animation.DROP,
    });

    var icon = {
        url: "https://png.icons8.com/nolan/2x/street-view.png",
        scaledSize: new window.google.maps.Size(64, 64)
    };

    myMarker.setIcon(icon);

    addYourLocationButton(map, myMarker);

    getPlaces();
}

function getPlaces() {
    var data = [
        { "Id": 1, "PlaceName": "Kraków", "GeoLong": "50.0647", "GeoLat": "19.945" }
    ];

    // Using the JQuery "each" selector to iterate through the JSON list and drop marker pins
    $.each(data,
        function (i, item) {
            var marker = new window.google.maps.Marker({
                'position': new window.google.maps.LatLng(item.GeoLong, item.GeoLat),
                'map': map,
                'title': item.PlaceName
            });

            // Make the marker-pin blue!
            marker.setIcon("http://maps.google.com/mapfiles/ms/icons/blue-dot.png");

            // finally hook up an "OnClick" listener to the map so it pops up out info-window when the marker-pin is clicked!
            window.google.maps.event.addListener(marker,
                "click",
                function () {
                    infowindow.open(map, marker);
                });
        });
}

$(document).ready(function (e) {
    initMap();
});