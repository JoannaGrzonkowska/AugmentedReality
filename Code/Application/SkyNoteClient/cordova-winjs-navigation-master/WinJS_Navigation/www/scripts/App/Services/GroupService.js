var GroupService = function (urls) {
    var self = this;
    self.urls = urls;

    self.addGroup = function (group, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/group/get',
            type: 'POST',
            data: group,
            success: function (data) {
                if (data.IsSuccess) {
                    $("#success-message").html("OK").show();
                    handler();
                } else {
                    $(".alert").html(data.ErrorsToString).show();
                }
            }
        });
    }
};