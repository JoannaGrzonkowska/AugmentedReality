(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/viewUsers/viewUsers.html", {
        ready: function (element, options) {

            var userService = new UserService();

            var UserFriendsViewModel = function () {
                var self = this;
                self.usersArray = ko.observableArray([]);

                var getAllUsers = function () {
                    userService.getAllUsers(options.userId, function (data) {
                        self.usersArray(data);
                    });
                };

                self.invite = function (item) {
                    userService.inviteFriend(
                    {
                        Name: item.Login(),
                        UserId: options.userId,
                        FriendId: item.UserId()
                    })
                };

                getAllUsers();

                self.back = function () {
                    WinJS.Navigation.navigate('pages/userFriends/userFriends.html', { userId: options.userId });
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

                self.gotoProfile = function () {
                };

            };
            ko.applyBindings(new UserFriendsViewModel(), document.getElementById("view-user-container"));

        }
    });
})();