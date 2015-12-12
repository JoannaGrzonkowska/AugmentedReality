(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/profile/profile.html", {

        ready: function (element, options) {


            var ProfileViewModel = function () {
                var self = this;
                this.User = ko.observable();
                this.Avatar = ko.observable();
                self.Login = ko.observable();
                self.Name = ko.observable();
                self.Mail = ko.observable();

                var userService = new UserService();

                self.refreshAvatar = function () {
                    $('#user-avatar').removeAttr("src").attr("src", self.Avatar() + "&time=" + new Date().getTime());
                }

                self.back = function () {
                    WinJS.Navigation.navigate('pages/home/home.html', { id: options.userId });
                };

                userService.getUserById(options.userId, function (data) {
                    self.Login(data.Login());
                    self.Name(data.Name());
                    self.Mail(data.Mail());
                    self.Avatar(data.AvatarPath());
                    self.refreshAvatar();

                    var cropBoxHelper = new CropBoxHelper(self.Avatar(), $("#avatar-edit-container"), function (img) {
                        userService.updateAvatar({ ImageBase64: img, UserId: options.userId }, function (data) {
                            self.refreshAvatar();
                        });
                    });
                });

            };

            var profileViewModel = new ProfileViewModel();
            ko.applyBindings(profileViewModel, document.getElementById("profile-container"));

        }
    });
})();
