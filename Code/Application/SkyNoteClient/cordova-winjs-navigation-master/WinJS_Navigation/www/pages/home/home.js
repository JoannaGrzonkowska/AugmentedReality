(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/home/home.html", {

        ready: function (element, options) {

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

                var getNotes = function (id) {
                    noteService.getUserNotes(id, function (data) {
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

                var getMyNotesViewModel = function (id) {
                    noteService.getMyNotesViewModel(id, function (data) {
                        self.categories(data.Categories());
                        self.myNotesArray(data.Notes());
                        self.lastRefresh(new Date());
                    });
                };

                self.showOnMap = function (item) {
                    item.IsSelected(true);
                    gotoMap();
                };

                self.edit = function (item) {
                    WinJS.Navigation.navigate('pages/note/note.html', { id: item.NoteId(), userId: options.id, userName: options.userName });
                };

                self.delete = function (item) {
                    noteService.deleteNote(item);
                };

                self.gotoAddNote = function () {
                    WinJS.Navigation.navigate('pages/note/note.html', { id: 0, userId: options.id, userName: options.userName });
                };

                self.refresh = function () {
                    getMyNotesViewModel(options.id);
                };

                self.search = function () {
                    searchNotes();
                };

                self.showNotesOnMap = function () {
                    WinJS.Navigation.navigate('pages/map/map.html', {
                        Notes: self.myNotesArray(),
                        BackLink: 'pages/home/home.html',
                        UserId: options.id
                    });
                };

                self.showNotesOnMap = function () {
                    //gotoMap();

                    launchnavigator.navigate(
                     [50.279306, -5.163158],
                      [50.342847, -4.749904],
                      function () {
                          alert("Plugin success");
                      },
                      function (error) {
                          alert("Plugin error: " + error);
                      });

                };

                getMyNotesViewModel(options.id);

                self.gotoGroups = function () {
                    WinJS.Navigation.navigate('pages/groups/groups.html', { userId: options.id });
                };

                self.gotoFriends = function () {
                    WinJS.Navigation.navigate('pages/userFriends/userFriends.html', { userId: options.id });
                };

                self.gotoProfile = function () {
                    WinJS.Navigation.navigate('pages/profile/profile.html', { userId: options.id });
                };

                self.logout = function () {
                    WinJS.Navigation.navigate('pages/signIn/signIn.html');
                };

            };

            var notesListViewModel = new NotesListViewModel();
            ko.applyBindings(notesListViewModel, document.getElementById("notes-container"));

        }
    });
})();
