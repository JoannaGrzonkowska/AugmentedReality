function NoteModel(data) {
    var self = this;
    if (data != null) {
        this.NoteId = ko.observable(data.NoteId);
        this.Topic = ko.observable(data.Topic);
        this.Content = ko.observable(data.Content);
        this.Date = ko.observable(data.Date);
        this.Longitude = ko.observable(data.XCord);
        this.Latitude = ko.observable(data.YCord);
    }
    else {
        this.NoteId = ko.observable();
        this.Topic = ko.observable();
        this.Content = ko.observable();
        this.Date = ko.observable();
    }
    this.IsSelected = ko.observable(false);
};
