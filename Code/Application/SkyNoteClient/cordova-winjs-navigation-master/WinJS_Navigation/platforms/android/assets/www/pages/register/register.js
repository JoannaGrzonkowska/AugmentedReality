(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/register/register.html", {
        ready: function (element, options) {

            var $registerForm = $("#register-form");

            $registerForm.validate({
                rules: {
                    login: "required",
                    name: "required",
                    pass: "required",
                    email: "required",
                    confpass: {
                        equalTo: "#pass",
                        required: true
                    }
                },
                messages: {
                    login: "Please enter your login",
                    name: "Please enter your name",
                    pass: "Please enter password",
                    email: "Please enter email",
                    confpass: "Passwords must match"
                }
            });

            var userService = new UserService();

            var RegisterViewModel = function () {
                var self = this;
                self.Login = ko.observable();
                self.Password = ko.observable();
                self.Email = ko.observable();
                self.Name = ko.observable();

                self.registerUser = function () {
                    if ($registerForm.valid()) {

                        userService.addNewUser(
                        {
                            Login: self.Login,
                            Password: self.Password,
                            Mail: self.Email,
                            Name: self.Name
                        });
                    }
                };

                self.signIn = function () {
                    WinJS.Navigation.navigate('pages/signIn/signIn.html');
                }
            };

            ko.applyBindings(new RegisterViewModel(), document.getElementById("register-container"));

        }
    });
})();
