(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/inviteToGroup/inviteToGroup.html", {
        ready: function (element, options) {

            var userService = new UserService();

            var InviteToGroupViewModel = function () {
                var self = this;
                self.friendsArray = ko.observableArray([]);

                var getFriends = function () {
                    userService.getFriends(options.groupId, options.userId, function (data) {
                        self.friendsArray(data);
                    });
                };

                self.invite = function (item) {
                    userService.inviteToGroup({
                        UserId: item.FriendId(),
                        GroupId: options.groupId,
                        Name: item.FriendName()
                    }, function () {
                        self.friendsArray.remove(item);
                    });
                };

                self.refresh = function () {
                    getFriends();
                };

                getFriends();

                self.back = function () {
                    WinJS.Navigation.navigate('pages/groupMembers/groupMembers.html', { groupId: options.groupId, userId: options.userId });
                };

                self.gotoGroups = function () {
                    WinJS.Navigation.navigate('pages/groups/groups.html', { userId: options.id });
                };

                self.gotoFriends = function () {
                    WinJS.Navigation.navigate('pages/userFriends/userFriends.html', { userId: options.id });
                };

                self.logout = function () {
                    WinJS.Navigation.navigate('pages/signIn/signIn.html');
                };

            };
            ko.applyBindings(new InviteToGroupViewModel(), document.getElementById("user-friends-container"));

        }
    });
})();
