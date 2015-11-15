(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/home/home.html", {

        ready: function (element, options) {
        
            var noteService = new NoteService();

            var NotesListViewModel = function () {
                var self = this;
                self.myNotesArray = ko.observableArray([]);
                
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

            };

            var notesListViewModel = new NotesListViewModel();
            noteService.getUserNotes(function (data) {
                notesListViewModel.myNotesArray(data);
            })

            ko.applyBindings(notesListViewModel, document.getElementById("notes-container"));

        }
    });
})();
