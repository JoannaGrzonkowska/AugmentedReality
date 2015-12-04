/// <reference path="knockout-3.3.0.debug.js" />
/// <reference path="knockout-3.3.0.js" />

var ServerInformation = {
    POIDATA_SERVER: 'http://skynoteasiatest.azurewebsites.net/api/note/get',
};

alert("1");
var NotesListViewModel = function () {
    alert("2");
    var self = this;
    self.myNotesArray = ko.observableArray([]);
    self.lastRefresh = ko.observable();
    self.test = ko.observable(4);

    self.lastRefresh(new Date());

    self.isRequestingData = false;
    self.initiallyLoadedData = false;
    self.markerList = ko.observableArray([]);
    self.currentMarker = null;
    self.currentMarkerDetails = ko.observable();

    self.latitude = ko.observable();
    self.longitude = ko.observable();

    self.selectedCategoryId = ko.observable();
    self.selectedTypeId = ko.observable();

    var noteService = new NoteService();

    self.categories = ko.observableArray([]);
    self.types = ko.computed(function () {
        self.selectedTypeId(null);
        if (self.selectedCategoryId()) {
            var selectedCategoryItem = $.grep(self.categories(), function (n, i) {
                return n.CategoryId() == self.selectedCategoryId();
            });

            if (selectedCategoryItem.length > 0) {
                return selectedCategoryItem[0].Types();
            }
        }
        return null;
    });

    var getCategoriesViewModel = function () {
        noteService.getCategories(function (data) {
            self.categories(data);
        });
    };

    self.loadPoisFromJsonData = function (poiData) {

        AR.context.destroyAll();

        self.markerList([]);

        World.markerDrawable_idle = new AR.ImageResource("assets/marker_idle.png");
        World.markerDrawable_selected = new AR.ImageResource("assets/marker_selected.png");
        World.markerDrawable_directionIndicator = new AR.ImageResource("assets/indi.png");

        alert(poiData.length);

        for (var currentPlaceNr = 0; currentPlaceNr < poiData.length; currentPlaceNr++) {
            var singlePoi =  {
                "id": poiData[currentPlaceNr].id(),
                "latitude": parseFloat(poiData[currentPlaceNr].latitude()),
                "longitude": parseFloat(poiData[currentPlaceNr].longitude()),
                "altitude": parseFloat(poiData[currentPlaceNr].altitude()),
                "title": poiData[currentPlaceNr].title(),
                "description": poiData[currentPlaceNr].description(),
                "date": poiData[currentPlaceNr].date(),
                "author": poiData[currentPlaceNr].author()
            };

            self.markerList.push(new Marker(singlePoi));
        }
    };

    self.requestDataFromServer = function (lat, lon) {
        self.isRequestingData = true;

        var jqxhr = $.getJSON(ServerInformation.POIDATA_SERVER, function (data) {
            var mappedData = $.map(data, function (item) {
                return new NoteModel(item);
            });
            self.loadPoisFromJsonData(mappedData);
        })
            .error(function (err) {
                alert('error');
            })
			.complete(function () {
			    self.isRequestingData = false;
			});
    };

    self.locationChanged = function (lat, lon, alt, acc) {

        self.latitude(lat);
        self.longitude(lon);

        if (!self.initiallyLoadedData) {
            self.requestDataFromServer(lat, lon);
            self.initiallyLoadedData = true;
        }
    };

    self.onMarkerSelected = function (marker) {
        self.currentMarker = marker;
        self.currentMarkerDetails(marker.poiData);

        // show panel
        $("#panel-poidetail").panel("open", 123);

        $(".ui-panel-dismiss").unbind("mousedown");

        // deselect AR-marker when user exits detail screen div.
        $("#panel-poidetail").on("panelbeforeclose", function (event, ui) {
            self.currentMarker.setDeselected(self.currentMarker);
        });
    };

    var searchNotes = function () {

        alert(' lon:' + self.longitude() + ' lat:' + self.latitude() + ' cat: ' + self.selectedCategoryId() + ' type: ' + self.selectedTypeId());

        noteService.getNotesByLocation(function (data) {
            self.loadPoisFromJsonData(data);
            self.lastRefresh(new Date());
        }, self.longitude(), self.latitude(), 20, self.selectedCategoryId(), self.selectedTypeId());
    };

    self.search = function () {
        searchNotes();
    };

    alert("3");
    getCategoriesViewModel();
    alert("3.1");

};

alert("4");
var notesListViewModel = new NotesListViewModel();

var World = {

    markerDrawable_idle: new AR.ImageResource("assets/marker_idle.png"),
    markerDrawable_selected: new AR.ImageResource("assets/marker_selected.png"),
    markerDrawable_directionIndicator: new AR.ImageResource("assets/indi.png"),

    onMarkerSelected: notesListViewModel.onMarkerSelected

};

AR.context.onLocationChanged = notesListViewModel.locationChanged;

(function () {
    $(document).ready(function () {
        ko.applyBindings(notesListViewModel, document.getElementById("notes-container"));
    });
})();
