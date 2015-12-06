function NotesByLocationViewModel(data) {
    var self = this;

    this.Groups = ko.observableArray([]);

    if (data.Groups != null) {
        data.Groups.forEach(function (item) {
            self.Groups.push(new GroupModel(item));
        });
    };

    this.Categories = ko.observableArray([]);

    if (data.Categories != null) {
        data.Categories.forEach(function (item) {
            self.Categories.push(new CategoryModel(item));
        });
    };

    this.Notes = ko.observableArray([]);

    if (data.Notes != null) {
        data.Notes.forEach(function (item) {
            self.Notes.push(new NoteModel(item));
        });
    };
};