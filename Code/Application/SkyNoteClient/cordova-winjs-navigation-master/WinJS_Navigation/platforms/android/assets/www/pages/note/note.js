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
            var categoriesService = new CategoriesService();
            var groupService = new GroupService();

            var NoteAddViewModel = function () {
                var self = this;
                self.myGroupsArray = ko.observableArray([]);
                self.selectedGroup= ko.observableArray([1]);
                self.NoteId = ko.observable(options.id);
                self.Topic = ko.observable();
                self.Content = ko.observable();
                self.Images = ko.observableArray([]);
                self.ImageName = ko.observable();
                self.LocationAddress = ko.observable();

                self.selectedCategoryId = ko.observable();
                self.selectedTypeId = ko.observable();

                self.categories = ko.observableArray([]);
                self.types = ko.computed(function () {
                    self.selectedTypeId(null);
                    $('#typeSelect').trigger('change');
                    if (self.selectedCategoryId()) {
                        var selectedCategoryItem = $.grep(self.categories(), function (n, i) {
                            return n.CategoryId() == self.selectedCategoryId();
                        });

                        if (selectedCategoryItem.length > 0) {
                            return selectedCategoryItem[0].Types();
                        }
                    }
                    return null;
                });

                self.isNew = self.NoteId() === 0;
                self.headerText = self.isNew ? 'Add new note' : 'Edit note';

                var getImagesList = function () {
                    var noteImages = [];
                    self.Images().forEach(function (item) {
                        noteImages.push({
                            ImageBase64: item.ImageBase64(),
                            Filename: item.Filename()
                        });
                    });
                    return noteImages;
                }

                var getUserGroups = function () {
                    groupService.getUserGroups(options.userId, function (data) {
                        self.myGroupsArray(data);
                    });
                };

                self.loadNoteData = function (data) {
                    self.Topic(data.Topic());
                    self.Content(data.Content());
                    self.Images(data.Images());
                    self.LocationAddress(data.LocationAddress);

                    self.selectedCategoryId(data.CategoryId());
                    self.selectedTypeId(data.TypeId());

                    $('#categorySelect').trigger('change');
                    $('#typeSelect').trigger('change');

                    $('#slider').rhinoslider();
                };

                var cropBoxHelper = new CropBoxHelper(null, $("#note-image-edit-container"), function (img) {
                    self.Images.push(new NoteImageModel({ ImageBase64: img }));
                });

                this.DeleteImage = function (item) {
                    self.Images.remove(item);
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



                        geocoder.geocode({ 'location': { lat: latitude, lng: longitude } }, function (results, status) {
                            if (status === google.maps.GeocoderStatus.OK) {
                                if (results[0]) {                                    
                                    noteService.addNote(JSON.stringify(
                                    {
                                        Topic: self.Topic(),
                                        Content: self.Content(),
                                        UserId: options.userId,
                                        xCord: longitude,
                                        yCord: latitude,
                                        zCord: altitude,
                                        TypeId: self.selectedTypeId(),
                                        Images: getImagesList(),
                                        Address: results[0].formatted_address
                                    }));
                                }
                            }
                        });

                    }, function () {
                        alert("error");
                    }, options);
                };

                self.editNote = function () {
                    noteService.editNote(JSON.stringify(
                      {
                          NoteId: self.NoteId(),
                          Topic: self.Topic(),
                          Content: self.Content(),
                          TypeId: self.selectedTypeId(),
                          Images: getImagesList()
                      }));
                };

                self.save = function () {
                    if ($noteForm.valid()) {
                        if (self.isNew) {
                            self.addNote();
                        }
                        else {
                            self.editNote();
                        }
                    }
                };

                self.back = function () {
                    WinJS.Navigation.navigate('pages/home/home.html', {id: options.userId});
                };

                if (!self.isNew) {

                    noteService.getNote(options.id, function (data) {
                        self.categories(data.Categories());
                        self.loadNoteData(data.Note);
                    });
                } else {
                    categoriesService.getCategoriesSelectList(function (data) {
                        self.categories(data);
                    });
                }

                getUserGroups();
            };
            ko.applyBindings(new NoteAddViewModel(), document.getElementById("note-edit-container"));

        }
    });
})();
