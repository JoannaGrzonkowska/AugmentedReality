// For an introduction to the Page Control template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232511
(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/home/home.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            // TODO: Initialize the page here.

            var elem = document.querySelector(".navButton");
            elem.addEventListener('click', this.btnHandler);

            var noteService = new NoteService();
            
            var ToDoViewModel = function () {
                var self = this;
                self.toDoItems = ko.observableArray([]);
                self.newDescription = ko.observable("");
                
                self.addNewItem = function () {
                    alert("sfd");
                    noteService.addNote(
                        {
                            Content: self.newDescription()
                        },
                        function () {
                            alert("ttt");
                            self.toDoItems.push(new ToDoItem(self.newDescription()));
                            self.newDescription("");
                        });



                };

                self.removeItem = function (item) {
                    self.toDoItems.remove(item);
                };

                self.listViewUnshift = function (e) {
                    alert("test");
                };
            };
            var ToDoItem = (function () {
                function ToDoItem(description) {
                    this.description = ko.observable(description);
                    this.done = ko.observable(false);
                }
                return ToDoItem;
            })();

            ko.applyBindings(new ToDoViewModel());

        },

        unload: function () {
            // TODO: Respond to navigations away from this page.
        },

        updateLayout: function (element, viewState, lastViewState) {
            /// <param name="element" domElement="true" />

            // TODO: Respond to changes in viewState.
        },

        btnHandler: function (args) {
            WinJS.Navigation.navigate('pages/page2/page2.html', args);
        }

    });
})();
