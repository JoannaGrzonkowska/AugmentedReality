// For an introduction to the Page Control template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232511
(function () {
    "use strict";

    WinJS.UI.Pages.define("pages/note/note.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            // TODO: Initialize the page here.

          //  document.addEventListener("backbutton", this.onBackKeyDown, false);

           // var elem = document.querySelector("#cancelButton");
           // elem.addEventListener('click', this.onBackKeyDown);

            var noteService = new NoteService();
            
            var NoteAddViewModel = function () {
                alert("sfdww");
                var self = this;
                self.Topic = ko.observable();
                self.Content = ko.observable();
                
                self.add = function () {
                    alert("sfd");

                    var options = {
                        enableHighAccuracy: true
                    };

                    navigator.geolocation.getCurrentPosition(function (position) {
                        var longitude = position.coords.longitude;
                        var latitude = position.coords.latitude;
                        var altitude = position.coords.altitude;

                        alert("longitude " + longitude);
                        alert("latitude " + latitude);
                        alert("altitude " + altitude);

                        noteService.addNote(
                       {
                           Topic: self.Topic(),
                           Content: self.Content(),
                           UserId: 1,
                           xCord: longitude,
                           yCord: latitude,
                           zCord: altitude

                       },
                       function () {
                           alert("sfdee");
                           self.Topic("");
                           self.Content("");
                       });

                    }, function () {
                        alert("sssfdee");
                    }, options);

                };

            };
            ko.applyBindings(new NoteAddViewModel(), document.getElementById("note-form"));

        },

        unload: function () {
            // TODO: Respond to navigations away from this page.
        },

        updateLayout: function (element, viewState, lastViewState) {
            /// <param name="element" domElement="true" />

            // TODO: Respond to changes in viewState.
        },

        btnHandler: function (args) {
            WinJS.Navigation.navigate('pages/page2/page2.html', args);
        },

        onBackKeyDown: function (args) {
            
        if (WinJS.Navigation.canGoBack == true) {
            WinJS.Navigation.back(1).done( /* Your success and error handlers */);

        }
    }

    });
})();
