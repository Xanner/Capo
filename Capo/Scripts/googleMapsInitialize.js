$(document).ready(function () {
                Initialize();
            });

            // Where all the fun happens
            function Initialize() {

                // Google has tweaked their interface somewhat - this tells the api to use that new UI
                window.google.maps.visualRefresh = true;
                var cracov = new window.google.maps.LatLng(10, 20);

                // These are options that set initial zoom level, where the map is centered globally to start, and the type of map to show
                var mapOptions = {
                    zoom: 4,
                    center: cracov,
                    mapTypeId: window.google.maps.MapTypeId.G_NORMAL_MAP,
                    styles: [
                        {
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#212121"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.icon",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.stroke",
                            "stylers": [
                                {
                                    "color": "#212121"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.country",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.land_parcel",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.locality",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#bdbdbd"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#181818"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text.stroke",
                            "stylers": [
                                {
                                    "color": "#1b1b1b"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "geometry.fill",
                            "stylers": [
                                {
                                    "color": "#2c2c2c"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#8a8a8a"
                                }
                            ]
                        },
                        {
                            "featureType": "road.arterial",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#373737"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#3c3c3c"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway.controlled_access",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#4e4e4e"
                                }
                            ]
                        },
                        {
                            "featureType": "road.local",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "featureType": "transit",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#000000"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#3d3d3d"
                                }
                            ]
                        }
                    ]
                };

                // This makes the div with id "map_canvas" a google map
                var map = new window.google.maps.Map(document.getElementById("map_canvas"), mapOptions);

                // a sample list of JSON encoded data of places to visit in Tunisia
                // you can either make up a JSON list server side, or call it from a controller using JSONResult
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
                        marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png');

                        // put in some information about each json object - in this case, the opening hours.
                        var infowindow = new window.google.maps.InfoWindow({
                            content: "<div class='infoDiv'><h2>" +
                                item.PlaceName +
                                "</h2>" +
                                "<h3>Opis</h3>" +
                                "<a>Zgwałcę kogoś chętnie</a>" +
                                "<h4>Kliknij aby skontaktować się z Marcin Miazga</h4>" +
                                "</div></div>"
                        });

                        // finally hook up an "OnClick" listener to the map so it pops up out info-window when the marker-pin is clicked!
                        window.google.maps.event.addListener(marker,
                            'click',
                            function () {
                                infowindow.open(map, marker);
                            });
                    });
            }