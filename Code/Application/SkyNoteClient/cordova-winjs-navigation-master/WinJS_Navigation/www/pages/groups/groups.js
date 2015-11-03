// For an introduction to the Page Control template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232511
(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/groups/groups.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            // TODO: Initialize the page here.

            var elem = document.querySelector(".navButton");
            elem.addEventListener('click', this.btnHandler);

            var groupService = new GroupService();

            var ToDoViewModel = function () {
                var self = this;
                self.toDoItems = ko.observableArray([]);
                self.newGroupName = ko.observable("");

                self.addNewItem = function () {
                    alert("Dodaję nową grupę");
                    groupService.addGroup(
                        {
                            Content: self.newGroupName()
                        },
                        function () {
                            alert("Dodano pomyślnie");
                            self.toDoItems.push(new ToDoItem(self.newGroupName()));
                            self.newGroupName("");
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
                function ToDoItem(groupName) {
                    this.groupName = ko.observable(groupName);
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
            WinJS.Navigation.navigate('pages/home/home.html', args);
        }

    });
})();
