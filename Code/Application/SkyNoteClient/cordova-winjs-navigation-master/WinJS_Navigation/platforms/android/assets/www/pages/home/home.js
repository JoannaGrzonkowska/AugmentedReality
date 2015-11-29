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

                var getNotes = function (id) {
                    noteService.getUserNotes(id, function (data) {
                        self.myNotesArray(data);
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

                getNotes(options.id);

            };

            var notesListViewModel = new NotesListViewModel();
            ko.applyBindings(notesListViewModel, document.getElementById("notes-container"));

        }
    });
})();
