var GroupService = function (urls) {
    var self = this;
    self.urls = urls;

    self.addGroup = function (group) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/group/addnewgroup',
            type: 'POST',
            data: group,
            success: function (data) {
                showAlertAfterAjax(data, 'Group ' + group.Name + ' successfuly added.');
            }
        });
    }

    self.getUserGroups = function (id, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/user/RetriveUsersGroups/' +id,//localhost:59284 skynoteasiatest.azurewebsites.net
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
            url: 'http://localhost:59284/api/group/get/' + id,
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
            url: 'http://localhost:59284/api/group/RetriveGroupMembers/' + id,//localhost:59284 skynoteasiatest.azurewebsites.net
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
