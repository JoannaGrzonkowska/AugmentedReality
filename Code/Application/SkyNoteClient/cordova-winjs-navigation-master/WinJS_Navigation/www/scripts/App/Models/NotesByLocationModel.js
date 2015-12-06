function NotesByLocationModel(data) {
    var self = this;

    this.NotesToDelete = ko.observableArray([]);

    if (data.NotesToDelete != null) {
        data.NotesToDelete.forEach(function (item) {
            self.NotesToDelete.push(item);
        });
    };

    this.Notes = ko.observableArray([]);

    if (data.Notes != null) {
        data.Notes.forEach(function (item) {
            self.Notes.push(new NoteModel(item));
        });
    };
};