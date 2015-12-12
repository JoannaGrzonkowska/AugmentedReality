function FriendModel(data) {
    var self = this;
    if (data != null) {
        this.FriendId = ko.observable(data.Id);
        this.FriendName = ko.observable(data.UserName);
        this.AvatarPath = ko.observable(Paths.serverUrl + 'File/GetUserAvatar?userid=' + data.UserId);
    }
    else {
        this.FriendId = ko.observable();
        this.FriendName = ko.observable();
    }
};