(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/home/home.html", {

        ready: function (element, options) {
        
            var noteService = new NoteService();

            var NotesListViewModel = function () {
                var self = this;
                self.myNotesArray = ko.observableArray([]);
                self.lastRefresh = ko.observable();

                var getNotes = function () {
                    noteService.getUserNotes(function (data) {
                        notesListViewModel.myNotesArray(data);
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
                    alert(item.Topic());
                };

                self.gotoAddNote = function () {
                    WinJS.Navigation.navigate('pages/note/note.html', { id: 0 });
                };

                self.refresh = function () {
                    getNotes();
                };

                getNotes();

            };

            var notesListViewModel = new NotesListViewModel();
            ko.applyBindings(notesListViewModel, document.getElementById("notes-container"));

        }
    });
})();
