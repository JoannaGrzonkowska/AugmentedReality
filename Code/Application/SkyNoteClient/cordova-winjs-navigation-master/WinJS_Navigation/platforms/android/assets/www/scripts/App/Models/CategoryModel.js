
function CategoryModel(data) {
    var self = this;

    this.CategoryId = ko.observable(data.CategoryId);
    this.Name = ko.observable(data.Name);
    
    this.Types = ko.observableArray([]);

    if (data.Types != null) {
        data.Types.forEach(function (item) {
            self.Types.push(new TypeModel(item));
        });
    };
};
