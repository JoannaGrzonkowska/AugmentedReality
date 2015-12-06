function GroupModel(data) {
    var self = this;
    if (data != null) {
        this.GroupId = ko.observable(data.GroupId);
        this.GroupName = ko.observable(data.GroupName);        
    }
    else {
        this.GroupId = ko.observable();
        this.GroupName = ko.observable();        
    }
};