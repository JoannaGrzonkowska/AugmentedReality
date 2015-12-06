(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/home/home.html", {

        ready: function (element, options) {

            var noteService = new NoteService();

            var NotesListViewModel = function () {
                var self = this;
                self.myNotesArray = ko.observableArray([]);
                self.lastRefresh = ko.observable();

                self.range = ko.observable(20);
                self.selectedCategoryId = ko.observable();
                self.selectedTypeId = ko.observable();
                self.selectedGroupIds = ko.observableArray([]);
                self.selectedGroupIdsString = ko.computed(function () {
                    return self.selectedGroupIds().join("|");
                });

                var currentPositionOptions = {
                    enableHighAccuracy: true
                };

                self.groups = ko.observableArray([]);
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

                var searchNotes = function () {

                    navigator.geolocation.getCurrentPosition(function (position) {
                        noteService.getNotesByLocation(function (data) {

                            var notesToRemove = $.grep(self.myNotesArray(), function (n, i) {
                                return data.NotesToDelete().indexOf(n.NoteId()) >= 0;
                            });

                            notesToRemove.forEach(function (item) {
                                self.myNotesArray.remove(item);
                            });

                            if (data.Notes != null) {
                                data.Notes().forEach(function (item) {
                                    self.myNotesArray.push(item);
                                });
                            };

                            self.lastRefresh(new Date());
                        }, options.id, position.coords.longitude, position.coords.latitude, self.range(), self.selectedCategoryId(), self.selectedTypeId(), self.selectedGroupIdsString());

                    }, function () {
                        alert("error");
                    }, currentPositionOptions);
                };

                var getNotesByLocationViewModel = function (id) {
                    navigator.geolocation.getCurrentPosition(function (position) {

                          noteService.getNotesByLocationViewModel(function (data) {
                            self.groups(data.Groups());
                            self.categories(data.Categories());
                            self.myNotesArray(data.Notes());
                            self.lastRefresh(new Date());
                        },
                        id, position.coords.longitude, position.coords.latitude, self.range(), self.selectedCategoryId(), self.selectedTypeId(), self.selectedGroupIdsString());
          
                            }, function () {
                        alert("error");
                    }, currentPositionOptions);
                };

                self.showOnMap = function (item) {
                    item.IsSelected(true);
                    gotoMap();
                };


                self.navigateTo = function (item) {
                    navigator.geolocation.getCurrentPosition(function (position) {

                        launchnavigator.navigate(
                         [item.Latitude(), item.Longitude()],
                          [position.coords.latitude, position.coords.longitude],
                          function () {
                              alert("Plugin success");
                          },
                          function (error) {
                              alert("Plugin error: " + error);
                          });
                    }, function () {
                        alert("error");
                    }, currentPositionOptions);

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
                    gotoMap();
                };

                getNotesByLocationViewModel(options.id);

                self.gotoGroups = function () {
                    WinJS.Navigation.navigate('pages/groups/groups.html', { id: options.id });
                };

                self.gotoFriends = function () {
                    WinJS.Navigation.navigate('pages/userFriends/userFriends.html', { id: options.id });
                };

                self.gotoNotes = function () {
                    WinJS.Navigation.navigate('pages/home/home.html', { id: options.id });
                };

            };

            var notesListViewModel = new NotesListViewModel();
            ko.applyBindings(notesListViewModel, document.getElementById("notes-container"));
        }
    });
})();
