(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/note/note.html", {
        ready: function (element, options) {

            var $noteForm = $("#note-form");

            $noteForm.validate({
                rules: {
                    topic: "required",
                    content: "required",
                },
                messages: {
                    topic: "Please enter note topic",
                    content: "Please enter note content",
                }
            });

            var noteService = new NoteService();

            var NoteAddViewModel = function () {
                var self = this;
                self.NoteId = ko.observable(options.id)
                self.Topic = ko.observable();
                self.Content = ko.observable();

                var isNew = self.NoteId() === 0;
                self.headerText = isNew ? 'Add new note' : 'Edit note';

                self.loadNoteData = function (data) {
                    self.Topic(data.Topic());
                    self.Content(data.Content());
                };

                var geocoder = new google.maps.Geocoder;


                self.addNote = function () {
                    var options = {
                        enableHighAccuracy: true
                    };

                    navigator.geolocation.getCurrentPosition(function (position) {
                        var longitude = position.coords.longitude;
                        var latitude = position.coords.latitude;
                        var altitude = position.coords.altitude;

                        alert("longitude " + longitude + " latitude " + latitude + " altitude " + altitude);

                        geocoder.geocode({ 'location': { lat: latitude, lng: longitude } }, function (results, status) {
                            if (status === google.maps.GeocoderStatus.OK) {
                                if (results[0]) {
                                    var address = results[0].formatted_address;
                                    alert(address);
                                    noteService.addNote(
                                    {
                                        Topic: self.Topic(),
                                        Content: self.Content(),
                                        UserId: 1,
                                        xCord: longitude,
                                        yCord: latitude,
                                        zCord: altitude,
                                        TypeId: 1
                                    });
                                }
                            }
                        });

                    }, function () {
                        alert("error");
                    }, options);
                };

                self.editNote = function () {
                    noteService.editNote(
                      {
                          NoteId: self.NoteId(),
                          Topic: self.Topic(),
                          Content: self.Content()
                      });
                };

                self.save = function () {
                    if ($noteForm.valid()) {
                        if (isNew) {
                            self.addNote();
                        }
                        else {
                            self.editNote();
                        }
                    }
                };

                self.back = function () {
                    WinJS.Navigation.navigate('pages/home/home.html');
                };

                if (!isNew) {

                    noteService.getNote(options.id, function (data) {
                        self.loadNoteData(data);
                    });
                }
            };
            ko.applyBindings(new NoteAddViewModel(), document.getElementById("note-edit-container"));

        }
    });
})();
