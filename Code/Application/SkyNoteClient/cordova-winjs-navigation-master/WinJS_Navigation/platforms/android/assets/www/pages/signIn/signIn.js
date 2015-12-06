(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/signIn/signIn.html", {
        ready: function (element, options) {

            var $signInForm = $("#signIn-form");

            $signInForm.validate({
                rules: {
                    login: "required",
                    pass: "required",
                },
                messages: {
                    login: "Please enter your login",
                    pass: "Please enter password",
                }
            });

            var userService = new UserService();

            var UserSignInViewModel = function () {
                var self = this;
                self.Login = ko.observable();
                self.Password = ko.observable();
                
                self.signIn = function () {
                    if ($signInForm.valid()) {                       

                        userService.signIn(
                            {
                                Login: self.Login,
                                Password: self.Password
                            },
                            function (data) {
                                //self.userFriendsArray(data);
                                if(data.IsSignedIn() === true)
                                {
                                    WinJS.Navigation.navigate('pages/home/home.html', { id: data.UserId(), userName: data.UserName()});
                                }
                                else
                                {
                                    WinJS.Navigation.navigate('pages/signIn/signIn.html');
                                }
                            });
                    }
                };

                self.register = function () {
                    WinJS.Navigation.navigate('pages/register/register.html');
                }
            };

            ko.applyBindings(new UserSignInViewModel(), document.getElementById("user-signIn-container"));

        }
    });
})();
