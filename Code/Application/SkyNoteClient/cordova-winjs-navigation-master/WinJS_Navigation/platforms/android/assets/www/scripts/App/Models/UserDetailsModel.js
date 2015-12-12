function UserDetailsModel(data) {
    var self = this;
    this.UserId = ko.observable(data.UserID);
    this.Name = ko.observable(data.Name);
    this.Login = ko.observable(data.Login);
    this.Mail = ko.observable(data.Mail);

    this.AvatarPath = ko.observable(Paths.serverUrl + 'File/GetUserAvatar?userid=' + self.UserId());

};
