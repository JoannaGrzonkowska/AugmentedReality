function SignInModel(data) {
    var self = this;
    if (data != null) {
        this.UserId = ko.observable(data.UserId);
        this.Login = ko.observable(data.Login);
        this.UserName = ko.observable(data.UserName);
        this.IsSignedIn = ko.observable(data.IsSignedIn);
        this.ErrorMessage = ko.observable(data.ErrorMessage);
    }
    else {
        this.UserId = ko.observable();
        this.Login = ko.observable();
        this.UserName = ko.observable();
        this.IsSignedIn = ko.observable();
        this.ErrorMessage = ko.observable();
    }
};