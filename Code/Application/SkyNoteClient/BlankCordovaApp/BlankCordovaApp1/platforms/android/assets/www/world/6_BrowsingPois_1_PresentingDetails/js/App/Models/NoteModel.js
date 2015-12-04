function NoteModel(data) {
    var self = this;
        this.id = ko.observable(data.NoteId);
        this.longitude = ko.observable(data.XCord);
        this.latitude = ko.observable(data.YCord);
        this.altitude = ko.observable(data.ZCord);
        this.title = ko.observable(data.Topic);
        this.description = ko.observable(data.Content);
        this.date = ko.observable(data.Date);
        this.author = ko.observable(data.Name);
};
