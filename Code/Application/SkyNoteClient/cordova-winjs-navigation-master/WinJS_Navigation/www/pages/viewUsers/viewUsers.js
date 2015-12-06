(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/viewUsers/viewUsers.html", {
        ready: function (element, options) {

            var userService = new UserService();

            var UserFriendsViewModel = function () {
                var self = this;
                self.usersArray = ko.observableArray([]);

                var getUserFriends = function () {
                    userService.getUserFriends(options.userId, function (data) {
                        self.userFriendsArray(data);
                    });
                };                

                self.invite = function (item) {
                    
                };               
                
                getUserFriends();

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
            ko.applyBindings(new UserFriendsViewModel(), document.getElementById("user-friends-container"));

        }
    });
})();
