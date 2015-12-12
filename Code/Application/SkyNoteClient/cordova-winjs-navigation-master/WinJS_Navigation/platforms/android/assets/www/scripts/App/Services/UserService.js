var UserService = function () {
    var self = this;

    self.updateAvatar = function (updateUserAvatarCommand, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/updateAvatar',
            type: 'POST',
            data: updateUserAvatarCommand,
            success: function (data) {
                if (data.IsSuccess) {
                    handler();
                }
            }
        });
    };

    self.getUserById = function (id, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/GetUserById/' + id,
            type: 'GET',
            success: function (data) {
                mappedData = new UserDetailsModel(data);
                handler(mappedData);
            }
        });
    };

    self.getAllUsers = function (id, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/GetAllPotentialFriends/' + id,
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new PotentialFriendModel(item);
                });
                handler(mappedData);
            }
        });
    };
    
    self.getUserFriends = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/RetrieveUsersFriends/' + id,
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new FriendModel(item);
                });
                handler(mappedData);
            }
        });
    };

    self.getUserInvites = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/GetFriendInvites/' + id,
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
            url: Paths.serverUrl + 'user/DecideFriendInvite/',
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
            url: Paths.serverUrl + 'user/AddFriend/',
            type: 'Post',
            data:user,
            success: function (data) {
                showAlertAfterAjax(data, 'Friend ' + user.Name + ' successfuly added.');
            }
        });
    };

    self.removeFriend = function (user, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/remove/',
            type: 'Post',
            success: function (data) {
                handler();
            }
        });
    };

    self.addNewUser = function (user) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/AddNewUser/',
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
            url: Paths.serverUrl + 'user/SignIn',
            type: 'POST',
            data: user,
            success: function (data) {
                var mappedData = new SignInModel(data);
                handler(mappedData);
            }
        });
    };

    self.inviteFriend = function (user) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/InviteFriend/',
            type: 'Post',
            data:user,
            success: function (data) {
                showAlertAfterAjax(data, 'Friend ' + user.Name + ' invited. Wait for his anwser');
            }
        });
    };

    self.getFriends = function (groupId, userId, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/GetPotentialGroupMembers?groupId=' + groupId + '&userId=' + userId,
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new FriendModel(item);
                });
                handler(mappedData);
            }
        });
    };

    self.inviteToGroup = function (invitation) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/InviteFriend/',
            type: 'Post',
            data: invitation,
            success: function (data) {
                showAlertAfterAjax(data, 'Friend ' + invitation.Name + ' invited.');
            }
        });
    };
};
