function NoteDetailsViewModel(data) {
    var self = this;

    this.Categories = ko.observableArray([]);

    if (data.Categories != null) {
        data.Categories.forEach(function (item) {
            self.Categories.push(new CategoryModel(item));
        });
    };

    this.Note = new NoteModel(data.Note);
};