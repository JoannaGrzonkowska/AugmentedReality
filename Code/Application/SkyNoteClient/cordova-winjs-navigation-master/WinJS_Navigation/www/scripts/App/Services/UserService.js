var UserService = function (urls) {
    var self = this;
    self.urls = urls;

    
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

    self.addNewUser = function (user) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/AddNewUser/',//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'Post',
            success: function (data) {
                showAlertAfterAjax(data, 'User ' + user.Login + ' successfuly registered.');
            }
        });
    };

    self.signIn = function (user, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/SignIn/',//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'Post',
            success: function (data) {
                var mappedData = SignInModel(data);
                handler(mappedData);
            }
        });
    };
};
