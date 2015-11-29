function GroupModel(data) {
    var self = this;
    if (data != null) {
        this.Id = ko.observable(data.Id);
        this.GroupName = ko.observable(data.GroupName);
        
    }
    else {
        this.Id = ko.observable();
        this.GroupName = ko.observable();
        
    }
};