var GroupService = function () {
    var self = this;

    self.addGroup = function (group) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'group/addnewgroup',
            type: 'POST',
            data: JSON.stringify(group),
            contentType: 'application/json',
            success: function (data) {
                showAlertAfterAjax(data, 'Group ' + group.Name + ' successfuly added.');
            }
        });
    }

    self.getUserGroups = function (id, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'user/RetriveUsersGroups/' +id,
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new GroupModel(item);
                });
                handler(mappedData);
            }
        });
    };

    self.getGroup = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'group/get/' + id,
            type: 'GET',
            success: function (data) {
                var mappedData = new GroupModel(data);
                handler(mappedData);
            }
        });
    };


    self.getGroupMembers = function (id, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'group/RetriveGroupMembers/' + id,
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new UserModel(item);
                });
                handler(mappedData);
            }
        });
    };
};
