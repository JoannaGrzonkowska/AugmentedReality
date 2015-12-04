function UserAddModel(data) {
    var self = this;
    if (data != null) {
        this.UserId = ko.observable(data.UserId);
        this.Login = ko.observable(data.Login);
        this.Name = ko.observable(data.Name);
        this.Password = ko.observable(data.Password);
        this.Mail = ko.observable(data.Mail);
    }
    else {
        this.UserId = ko.observable();
        this.Login = ko.observable();
        this.Name = ko.observable();
        this.Password = ko.observable();
        this.ConformPassword = ko.observable();
        this.Mail = ko.observable();
    }
};
