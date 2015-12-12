function PotentialFriendModel(data) {
    var self = this;
    if (data != null) {
        this.UserId = ko.observable(data.UserId);
        this.Login = ko.observable(data.Name);
        this.AvatarPath = ko.observable(Paths.serverUrl + 'File/GetUserAvatar?userid=' + data.UserId);
    }
    else {
        this.UserId = ko.observable();
        this.Login = ko.observable();
    }
};