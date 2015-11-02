function NoteAddModel(data) {
    var self = this;
    if (data != null) {
        this.Topic = ko.observable(data.Topic);
        this.Content = ko.observable(data.Content);
    }
    else {
        this.Topic = ko.observable();
        this.Content = ko.observable();
    }
};
