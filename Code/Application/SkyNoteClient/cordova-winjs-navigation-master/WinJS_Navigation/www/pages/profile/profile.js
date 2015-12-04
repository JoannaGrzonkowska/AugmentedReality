(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/profile/profile.html", {

        ready: function (element, options) {


            var ProfileViewModel = function () {
                var self = this;
                self.avatarPath = ko.observable('http://skynoteasiatest.azurewebsites.net/api/File/GetUserAvatar?userid=1');

                var userService = new UserService();
                var cropBoxHelper = new CropBoxHelper(self.avatarPath(), $("#avatar-edit-container"), function (img) {
                    $('.cropped').append('<img src="' + img + '">');
                    userService.updateAvatar({ ImageBase64: img, UserId: 1 }, function (data) {
                        //self.refreshAvatar();
                    });
                });

                self.back = function () {
                };

            };

            var profileViewModel = new ProfileViewModel();
            ko.applyBindings(profileViewModel, document.getElementById("profile-container"));

        }
    });
})();
