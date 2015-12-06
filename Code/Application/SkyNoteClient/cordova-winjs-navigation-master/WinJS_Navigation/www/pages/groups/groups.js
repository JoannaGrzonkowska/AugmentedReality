(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/groups/groups.html", {

        ready: function (element, options) {

            var groupService = new GroupService();

            var GroupsListViewModel = function () {
                var self = this;
                self.myGroupsArray = ko.observableArray([]);
                
                var getGroups = function () {
                    groupService.getUserGroups(options.userId, function (data) {
                        self.myGroupsArray(data);
                    });
                };
                self.viewGroupNotes = function (item) {
                    WinJS.Navigation.navigate('pages/groupNotes/groupNotes.html', { groupId: item.GroupId(), userId: options.userId });
                }

                self.edit = function (item) {
                    WinJS.Navigation.navigate('pages/newGroup/newGroup.html', { id: item.GroupId() });
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

                self.gotoFriends = function () {
                    WinJS.Navigation.navigate('pages/userFriends/userFriends.html', { id: options.userId });
                };

                self.gotoNotes = function () {
                    WinJS.Navigation.navigate('pages/home/home.html', { id: options.userId });
                };

                self.logout = function () {
                    WinJS.Navigation.navigate('pages/signIn/signIn.html');
                };

            };

            var groupsListViewModel = new GroupsListViewModel();
            ko.applyBindings(groupsListViewModel, document.getElementById("groups-container"));

        }
    });
})();