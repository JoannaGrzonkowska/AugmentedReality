var UserService = function (urls) {
    var self = this;
    self.urls = urls;

    
 self.updateAvatar = function (updateUserAvatarCommand, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/updateAvatar',
            type: 'POST',
            data: updateUserAvatarCommand,
            success: function (data) {
                if (data.IsSuccess) {
                   // $("#success-message").html("OK").show();
                    handler();
                } else {
                  //  $(".alert").html(data.ErrorsToString).show();
                }
            }
        });
    };

    self.getAllUsers = function (handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/get',//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new GroupModel(item);
                });
                handler(mappedData);
            }
        });
    };

    self.getUserFriends = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/RetrieveUsersFriends/' + id,
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new UserModel(item);
                });
                handler(mappedData);
            }
        });
    };

    self.getUserInvites = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/GetFriendInvites/' + id,
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new UserModel(item);
                });
                handler(mappedData);
            }
        });
    };

    self.decide = function (decision, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/DecideFriendInvite/',
            type: 'POST',
            data: decision,
            success: function (data) {                
                handler();
            }
        });
    };


    self.addFriend = function (user) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/AddFriend/',//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'Post',
            success: function (data) {
                showAlertAfterAjax(data, 'Friend ' + user.Name + ' successfuly added.');
            }
        });
    };

    self.removeFriend = function (user, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/remove/',//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'Post',
            success: function (data) {
                handler();
            }
        });
    };

    self.addNewUser = function (user) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/user/AddNewUser/',//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'POST',
            data: user,
            success: function (data) {
                showAlertAfterAjax(data, 'User ' + user.Login() + ' successfuly registered.');
            }
        });
    };

    self.signIn = function (user, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/user/SignIn/',//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'Post',
            data: user,
            success: function (data) {
                var mappedData = new SignInModel(data);
                handler(mappedData);
            }
        });
    };
};
