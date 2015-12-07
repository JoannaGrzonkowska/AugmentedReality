(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/profile/profile.html", {

        ready: function (element, options) {


            var ProfileViewModel = function () {
                var self = this;
                self.avatarPath = ko.observable('http://skynoteasiatest.azurewebsites.net/api/File/GetUserAvatar?userid=' + options.userId);

                var userService = new UserService();
                var cropBoxHelper = new CropBoxHelper(self.avatarPath(), $("#avatar-edit-container"), function (img) {
                    $('.cropped').append('<img src="' + img + '">');
                    userService.updateAvatar({ ImageBase64: img, UserId: options.userId }, function (data) {
                        //self.refreshAvatar();
                    });
                });

                self.back = function () {
                    WinJS.Navigation.navigate('pages/home/home.html', { id: options.userId });
                };

            };

            var profileViewModel = new ProfileViewModel();
            ko.applyBindings(profileViewModel, document.getElementById("profile-container"));

        }
    });
})();
