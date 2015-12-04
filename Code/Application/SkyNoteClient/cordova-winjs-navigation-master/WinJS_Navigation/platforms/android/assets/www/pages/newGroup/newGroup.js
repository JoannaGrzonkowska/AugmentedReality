(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/newGroup/newGroup.html", {
        ready: function (element, options) {

            var $groupForm = $("#group-form");

            $groupForm.validate({
                rules: {
                    name: "required"
                },
                messages: {
                    name: "Please enter group name"
                }
            });

            var groupService = new GroupService();

            var GroupAddViewModel = function () {
                var self = this;
                self.GroupId = ko.observable(options.id)
                self.Name = ko.observable();

                var isNew = self.GroupId() === 0;
                self.headerText = isNew ? 'Add new group' : 'Edit group';

                self.loadGroupData = function (data) {
                    self.Name(data.Name());
                };

                self.addGroup = function () {
                    var options = {
                        enableHighAccuracy: true
                    };

                    groupService.addGroup(
                       {
                           Name: self.Name(),                           
                           UserId: 1
                       });
                };

                self.editGroup = function () {
                    groupService.editGroup(
                      {
                          Id: self.GroupId(),
                          Name: self.Name()
                      });
                };

                self.save = function () {
                    if ($groupForm.valid()) {
                        if (isNew) {
                            self.addGroup();
                        }
                        else {
                            self.editGroup();
                        }
                    }
                };

                self.back = function () {
                    WinJS.Navigation.navigate('pages/groups/groups.html');
                };

                if (!isNew) {

                    groupService.getGroup(options.id, function (data) {
                        self.loadGroupData(data);
                    });
                }
            };
            ko.applyBindings(new GroupAddViewModel(), document.getElementById("group-edit-container"));

        }
    });
})();
