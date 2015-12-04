
var NoteService = function (urls) {
    var self = this;
    self.urls = urls;

    self.getUserNotes = function (handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/get',//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new NoteModel(item);
                });
                handler(mappedData);
            }
        });
    };

    self.getNotesByLocation = function (handler, xCord, yCord, radius, categoryId, typeId) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/NotesByLocation?xCord=' + xCord
                + '&yCord=' + yCord
                + '&radius=' + radius
                + '&categoryId=' + categoryId
                + '&typeId=' + typeId,
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new NoteModel(item);
                });
                handler(mappedData);
            }
        });
    };

    self.getMyNotesViewModel = function (handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/MyNotesViewModel',
            type: 'GET',
            success: function (data) {
                var mappedData = new MyNotesViewModel(data);
                handler(mappedData);
            }
        });
    };

    self.getNote = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/get/' + id,
            type: 'GET',
            success: function (data) {
                var mappedData = new NoteDetailsViewModel(data);
                handler(mappedData);
            }
        });
    };

    self.addNote = function (note) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/AddNewNote',
            type: 'POST',
            data: note,
            contentType: 'application/json',
            success: function (data) {
                showAlertAfterAjax(data, 'Note ' + JSON.parse(note).Topic + ' successfuly added.');
            }
        });
    }

    self.editNote = function (note) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/put',
            type: 'PUT',
            data: note,
            contentType: 'application/json',
            success: function (data) {
                showAlertAfterAjax(data, 'Note ' + JSON.parse(note).Topic + ' successfuly edited.');
            }
        });
    }

    self.deleteNote = function (note) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/delete/' + note.NoteId(),
            type: 'DELETE',
            success: function (data) {
                showAlertAfterAjax(data, 'Note ' + note.Topic() + ' successfuly deleted.');
            }
        });
    }

};