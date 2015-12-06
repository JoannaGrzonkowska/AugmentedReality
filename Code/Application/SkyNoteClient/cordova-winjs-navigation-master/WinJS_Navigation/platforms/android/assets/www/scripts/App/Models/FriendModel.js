function FriendModel(data) {
    var self = this;
    if (data != null) {
        this.FriendId = ko.observable(data.FriendId);
        this.FriendName = ko.observable(data.FriendName);
    }
    else {
        this.FriendId = ko.observable();
        this.FriendName = ko.observable();
    }
};