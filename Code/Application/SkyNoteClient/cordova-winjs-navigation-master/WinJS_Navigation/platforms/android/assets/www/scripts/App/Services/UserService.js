var UserService = function (urls) {
    var self = this;
    self.urls = urls;

    self.updateAvatar = function (updateUserAvatarCommand, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/user/updateAvatar',
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
    }
};