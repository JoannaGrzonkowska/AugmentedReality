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
                    userService.getUserInvites(options.id, function (data) {
                        self.invitationsArray(data);
                    })
                }
                var getUserFriends = function () {
                    userService.getUserFriends(options.id, function (data) {
                        self.userFriendsArray(data);
                    });
                };

                self.getFriendsNotes = function(item)
                {
                    WinJS.Navigation.navigate('pages/home/home.html', { id: item.Id() });
                }

                self.delete = function (item) {
                    var self = this;
                    userService.removeFriend(item, function () {

                    });
                };

                self.accept = function (item) {
                    userService.decide({
                        InvatedUserId: options.id,
                        InvatingUserId: item.UserId(),
                        State: "ACCEPT"
                    }, function () {
                        self.invitationsArray.remove(item);
                    });
                };

                self.decline = function (item) {
                    userService.decide({
                        InvatedUserId: options.id,
                        InvatingUserId: item.UserId,
                        State: "DECLINE"
                    }, function () {
                        $(self).closest('.remove').remove();
                    });
                };

                self.refresh = function () {
                    getUserFriends();
                    getUserInvites();
                };

                getUserFriends();
                getUserInvites();

                self.back = function () {
                    WinJS.Navigation.navigate('pages/home/home.html');
                };

                self.gotoGroups = function () {
                    WinJS.Navigation.navigate('pages/groups/groups.html', { id: options.id });
                };

                self.gotoFriends = function () {
                    WinJS.Navigation.navigate('pages/userFriends/userFriends.html', { id: options.id });
                };

                self.gotoNotes = function () {
                    WinJS.Navigation.navigate('pages/home/home.html', { id: options.id });
                };

            };
            ko.applyBindings(new UserFriendsViewModel(), document.getElementById("user-friends-container"));

        }
    });
})();
