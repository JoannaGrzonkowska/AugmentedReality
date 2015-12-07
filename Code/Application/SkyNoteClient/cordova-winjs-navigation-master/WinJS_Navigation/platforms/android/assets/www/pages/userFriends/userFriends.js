(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/userFriends/userFriends.html", {
        ready: function (element, options) {

            var userService = new UserService();

            var UserFriendsViewModel = function () {
                var self = this;
                self.userFriendsArray = ko.observableArray([]);
                self.invitationsArray = ko.observableArray([]);

                var getUserInvites = function () {
                    userService.getUserInvites(options.userId, function (data) {
                        self.invitationsArray(data);
                    })
                }
                var getUserFriends = function () {
                    userService.getUserFriends(options.userId, function (data) {
                        self.userFriendsArray(data);
                    });
                };

                self.getFriendsNotes = function(item)
                {
                    WinJS.Navigation.navigate('pages/userNotes/userNotes.html',
                        { id: item.FriendId(), name: item.FriendName(), userId: options.userId });
                }

                self.delete = function (item) {
                    var self = this;
                    userService.removeFriend(item, function () {

                    });
                };

                self.accept = function (item) {
                    userService.decide({
                        InvatedUserId: options.userId,
                        InvatingUserId: item.UserId(),
                        State: "ACCEPT"
                    }, function () {
                        self.invitationsArray.remove(item);
                    });
                };

                self.decline = function (item) {
                    userService.decide({
                        InvatedUserId: options.userId,
                        InvatingUserId: item.UserId(),
                        State: "DECLINE"
                    }, function () {
                        self.invitationsArray.remove(item);
                    });
                };

                self.refresh = function () {
                    getUserFriends();
                    getUserInvites();
                };

                getUserFriends();
                getUserInvites();

                self.back = function () {
                    WinJS.Navigation.navigate('pages/home/home.html', { id: options.userId });
                };

                self.search = function () {
                    WinJS.Navigation.navigate('pages/viewUsers/viewUsers.html', { userId: options.userId });
                };

                self.gotoGroups = function () {
                    WinJS.Navigation.navigate('pages/groups/groups.html', { userId: options.userId });
                };                               

                self.gotoNotes = function () {
                    WinJS.Navigation.navigate('pages/home/home.html', { id: options.userId });
                };

                self.logout = function () {
                    WinJS.Navigation.navigate('pages/signIn/signIn.html');
                };

            };
            ko.applyBindings(new UserFriendsViewModel(), document.getElementById("user-friends-container"));

        }
    });
})();
