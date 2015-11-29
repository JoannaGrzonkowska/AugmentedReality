(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/userFriends/userFriends.html", {
        ready: function (element, options) {

            var userService = new UserService();

            var UserFriendsViewModel = function () {
                var self = this;
                self.userFriendsArray = ko.observableArray([]);

                var getUserFriends = function () {
                    userService.getUserFriends(/*options.id*/ 1, function (data) {
                        self.userFriendsArray(data);
                    });
                };

                self.getFriendsNotes = function(item)
                {
                    WinJS.Navigation.navigate('pages/home/home.html', { id: item.Id() });
                }

                self.delete = function (item) {
                    noteService.removeFriend(item);   //Szymon zaimplementować!!
                };

                self.refresh = function () {
                    getUserFriends();
                };

                getUserFriends();

                self.back = function () {
                    WinJS.Navigation.navigate('pages/home/home.html');
                };

            };
            ko.applyBindings(new UserFriendsViewModel(), document.getElementById("user-friends-container"));

        }
    });
})();
