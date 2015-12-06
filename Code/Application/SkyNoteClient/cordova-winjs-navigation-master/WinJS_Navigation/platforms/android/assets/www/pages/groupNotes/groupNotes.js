(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/groupNotes/groupNotes.html", {
        ready: function (element, options) {

            var noteService = new NoteService();

            var GroupNotesViewModel = function () {
                var self = this;
                self.myNotesArray = ko.observableArray([]);

                var getGroupNotes = function () {
                    noteService.getGroupNotes(options.groupId, function (data) {
                        self.myNotesArray(data);
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

                self.refresh = function () {
                    getGroupNotes();
                };

                self.showGroupMembers = function () {
                    WinJS.Navigation.navigate('pages/groupMembers/groupMembers.html', { groupId: options.groupId, userId: options.userId });
                }

                getGroupNotes();
                                              

                self.back = function () {
                    WinJS.Navigation.navigate('pages/groups/groups.html', { groupId: options.groupId, id: options.userId});
                };
                                
            };
            ko.applyBindings(new GroupNotesViewModel(), document.getElementById("group-notes-container"));

        }
    });
})();
