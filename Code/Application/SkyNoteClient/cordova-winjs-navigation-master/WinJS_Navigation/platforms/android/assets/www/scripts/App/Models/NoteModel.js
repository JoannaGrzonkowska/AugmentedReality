function NoteModel(data, userLongitude, userLatitude) {
    var self = this;
    if (data != null) {
        this.NoteId = ko.observable(data.NoteId);
        this.Topic = ko.observable(data.Topic);
        this.Content = ko.observable(data.Content);
        this.Date = ko.observable(data.Date);
        this.Longitude = ko.observable(data.XCord);
        this.Latitude = ko.observable(data.YCord);
        this.Images = ko.observableArray([]);
        this.LocationAddress = ko.observable(data.LocationAddress);
        this.GroupIds = ko.observable(data.GroupIds);

        this.CategoryId = ko.observable(data.CategoryId);
        this.TypeId = ko.observable(data.TypeId);

        if (data.ImagesFilenames != null) {
            data.ImagesFilenames.forEach(function (item) {
                self.Images.push(new NoteImageModel({
                    Filename: item,
                    ServerPath: 'http://skynoteasiatest.azurewebsites.net/api/File/GetNoteImage?noteId=' + self.NoteId() + '&filename='
                }));
            });
        };
    }
    else {
        this.NoteId = ko.observable();
        this.Topic = ko.observable();
        this.Content = ko.observable();
        this.Date = ko.observable();
        this.Images = ko.observableArray([]);
    }
    this.IsSelected = ko.observable(false);

    self.CalcDistance = function (otherLongitude, otherLatitude) {
        return calcDistance(self.Longitude(), self.Latitude(), otherLongitude, otherLatitude);
    };

    this.DistanceToUser = ko.observable()
    if (userLongitude != null && userLatitude != null) {
        this.DistanceToUser(self.CalcDistance(userLongitude, userLatitude));
    };
};
