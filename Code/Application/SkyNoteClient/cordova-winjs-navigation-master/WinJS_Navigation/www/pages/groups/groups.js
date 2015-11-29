(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/groups/groups.html", {

        ready: function (element, options) {

            var groupService = new GroupService();

            var GroupsListViewModel = function () {
                var self = this;
                self.myGroupsArray = ko.observableArray([]);
                
                var getGroups = function () {
                    groupService.getUserGroups(1, function (data) {
                        self.myGroupsArray(data);
                    });
                };
                self.viewGroupNotes = function (item) {
                    WinJS.Navigation.navigate('pages/groupNotes/groupNotes.html', { id: item.Id() });
                }

                self.edit = function (item) {
                    WinJS.Navigation.navigate('pages/newGroup/newGroup.html', { id: item.Id() });
                };

                self.delete = function (item) {
                    groupService.deleteGroup(item);
                };

                self.gotoAddGroup = function () {
                    WinJS.Navigation.navigate('pages/newGroup/newGroup.html', { id: 0 });
                };

                self.refresh = function () {
                    getGroups();
                };

                getGroups();

            };

            var groupsListViewModel = new GroupsListViewModel();
            ko.applyBindings(groupsListViewModel, document.getElementById("groups-container"));

        }
    });
})();