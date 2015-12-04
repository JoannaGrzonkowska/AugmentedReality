function NoteImageModel(data) {
    var self = this;
    this.ServerPath = ko.observable(data.ServerPath);
    if (data != null) {
        this.Filename = ko.observable(data.Filename);
        this.ImageBase64 = ko.observable(data.ImageBase64);
    } else {
        this.Filename = ko.observable();
        this.ImageBase64 = ko.observable();
    }
    this.Path = ko.computed(function () {
        return self.Filename() ? self.ServerPath()+ self.Filename() : self.ImageBase64();
    });
};