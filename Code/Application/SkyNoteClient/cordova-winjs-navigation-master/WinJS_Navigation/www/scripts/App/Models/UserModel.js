function UserModel(data) {
    var self = this;
    if (data != null) {
        this.UserId = ko.observable(data.UserId);
        this.Login = ko.observable(data.UserName);
    }
    else {
        this.UserId = ko.observable();
        this.Login = ko.observable();
    }
};
