﻿(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/groupMembers/groupMembers.html", {
        ready: function (element, options) {

            var groupService = new GroupService();

            var GroupMembersViewModel = function () {
                var self = this;
                self.groupMembersArray = ko.observableArray([]);

                var getGroupMembers = function () {
                    groupService.getGroupMembers(options.groupId, function (data) {
                        self.groupMembersArray(data);
                    });
                };
                
                self.delete = function (item) {
                    noteService.removeUserFromGroup(item);  //nie zaimplementowane! Czy potrzebne!?
                };

                self.refresh = function () {
                    getGroupMembers();
                };

                getGroupMembers();

                self.back = function () {
                    WinJS.Navigation.navigate('pages/groupNotes/groupNotes.html', { groupId: options.groupId, userId: options.userId });
                };

                self.inviteFriend = function () {
                    WinJS.Navigation.navigate('pages/inviteToGroup/inviteToGroup.html', { groupId: options.groupId, userId: options.userId });
                }
            };
            ko.applyBindings(new GroupMembersViewModel(), document.getElementById("group-members-container"));

        }
    });
})();
