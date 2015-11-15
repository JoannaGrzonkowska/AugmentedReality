
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

    self.getNote = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/get/' + id,
            type: 'GET',
            success: function (data) {
                var mappedData = new NoteModel(data);
                handler(mappedData);
            }
        });
    };

    self.addNote = function (note) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/post',
            type: 'POST',
            data: note,
            success: function (data) {
                showAlertAfterAjax(data, 'Note ' + note.Topic + ' successfuly added.');
            }
        });
    }

    self.editNote = function (note) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/note/put',
            type: 'PUT',
            data: note,
            success: function (data) {
                showAlertAfterAjax(data, 'Note ' + note.Topic + ' successfuly edited.');
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