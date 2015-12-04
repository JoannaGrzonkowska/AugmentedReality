function NoteInGroupModel(data) {
    var self = this;
    if (data != null) {
        this.NoteId = ko.observable(data.NoteId);
        this.Topic = ko.observable(data.Topic);
        this.Content = ko.observable(data.Content);
        this.Date = ko.observable(data.Date);
        this.Login = ko.observable(data.Login)
    }
    else {
        this.NoteId = ko.observable();
        this.Topic = ko.observable();
        this.Content = ko.observable();
        this.Date = ko.observable();
        this.Login = ko.observable();
    }
};
