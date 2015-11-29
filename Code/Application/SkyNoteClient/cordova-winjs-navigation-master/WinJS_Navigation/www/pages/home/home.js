(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/home/home.html", {

        ready: function (element, options) {

            if (typeof options === "undefined")
            {
                var options = { id: 1 };
            }
            options.id = (typeof options.id === "undefined") ? "1" : options.id;
            var noteService = new NoteService();

            var NotesListViewModel = function () {
                var self = this;
                self.myNotesArray = ko.observableArray([]);
                self.lastRefresh = ko.observable(); 

                self.selectedCategoryId = ko.observable();
                self.selectedTypeId = ko.observable();

                self.categories = ko.observableArray([]);
                self.types = ko.computed(function () {
                    self.selectedTypeId(null);
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

                var getNotes = function () {
                    noteService.getUserNotes(function (data) {
                        self.myNotesArray(data);
                        self.lastRefresh(new Date());
                    });
                };

                var searchNotes = function () {

                    var options = {
                        enableHighAccuracy: true
                    };

                    navigator.geolocation.getCurrentPosition(function (position) {
                        var longitude = position.coords.longitude;
                        var latitude = position.coords.latitude;
                        var altitude = position.coords.altitude;

                        

                        noteService.getNotesByLocation(function (data) {
                            self.myNotesArray(data);
                            self.lastRefresh(new Date());
                        }, longitude, latitude, 20, self.selectedCategoryId(), self.selectedTypeId());

                    }, function () {
                        alert("error");
                    }, options);
                };

                var getMyNotesViewModel = function () {
                    noteService.getMyNotesViewModel(function (data) {
                        self.categories(data.Categories());
                        self.myNotesArray(data.Notes());
                        self.lastRefresh(new Date());
                    });
                };

                self.showOnMap = function (item) {
                    alert(item.Topic());
                };

                self.edit = function (item) {
                    WinJS.Navigation.navigate('pages/note/note.html', { id: item.NoteId() });
                };

                self.delete = function (item) {
                    noteService.deleteNote(item);
                };

                self.gotoAddNote = function () {
                    WinJS.Navigation.navigate('pages/note/note.html', { id: 0 });
                };

                self.refresh = function () {
                    getNotes(1); // wstawic current user id
                };

                self.search = function () {
                    searchNotes();
                };

                getNotes(options.id);

                self.showNotesOnMap = function () {
                    WinJS.Navigation.navigate('pages/map/map.html', {
                        Notes: self.myNotesArray(),
                        BackLink: 'pages/home/home.html'
                    });
                };

                getMyNotesViewModel();

            };

            var notesListViewModel = new NotesListViewModel();
            ko.applyBindings(notesListViewModel, document.getElementById("notes-container"));

        }
    });
})();
