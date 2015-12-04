function TypeModel(data) {
    var self = this;

    this.TypeId = ko.observable(data.TypeId);
    this.Name = ko.observable(data.Name);
};
