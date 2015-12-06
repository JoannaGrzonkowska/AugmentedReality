function FriendModel(data) {
    var self = this;
    if (data != null) {
        this.FriendId = ko.observable(data.Id);
        this.FriendName = ko.observable(data.UserName);
    }
    else {
        this.FriendId = ko.observable();
        this.FriendName = ko.observable();
    }
};