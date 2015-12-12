(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/map/map.html", {

        ready: function (element, options) {

            var noteService = new NoteService();

            var NotesMapViewModel = function () {
                var self = this;
                self.notesArray = ko.observableArray(options.Notes);
                self.backLink = ko.observable(options.BackLink);
                self.userId = ko.observable(options.UserId);
                self.lastRefresh = ko.observable(new Date());

                var loadMarkersToMap = function () {
                    var options = {
                        enableHighAccuracy: true
                    };

                    navigator.geolocation.getCurrentPosition(function (position) {
                        var longitude = position.coords.longitude;
                        var latitude = position.coords.latitude;

                        var mapProp = {
                            center: new google.maps.LatLng(latitude, longitude),
                            zoom: 19,
                            panControl: true,
                            zoomControl: true,
                            mapTypeControl: true,
                            scaleControl: true,
                            streetViewControl: true,
                            overviewMapControl: true,
                            rotateControl: true,
                            mapTypeId: google.maps.MapTypeId.ROADMAP
                        };
                        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

                        self.notesArray().forEach(function (item) {

                            var markerData = {
                                position: new google.maps.LatLng(item.Latitude(), item.Longitude()),
                                //    icon:'pinkball.png'
                            };

                            if (item.IsSelected()) {
                                markerData.animation = google.maps.Animation.BOUNCE;
                            }

                            var infowindow = new google.maps.InfoWindow({
                                content: '<div>' + item.LocationAddress() + '</div>' +
                                    '<div>' + item.Topic() + '</div>' +
                                     '<div>' + item.Content() + '</div>'
                            });

                            var marker = new google.maps.Marker(markerData);

                            google.maps.event.addListener(marker, 'click', function () {
                                infowindow.open(map, marker);
                            });

                            marker.setMap(map);
                        });


                    }, function () {
                        alert("error");
                    }, options);
                };

                self.back = function () {
                    WinJS.Navigation.navigate(self.backLink(), { id: self.userId() });
                };
                loadMarkersToMap();
            };

            var notesMapViewModel = new NotesMapViewModel();
            ko.applyBindings(notesMapViewModel, document.getElementById("notes-map-container"));

        }
    });
})();
