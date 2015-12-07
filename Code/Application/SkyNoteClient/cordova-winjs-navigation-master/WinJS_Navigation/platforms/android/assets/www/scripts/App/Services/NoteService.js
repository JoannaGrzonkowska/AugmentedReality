
var NoteService = function (urls) {
    var self = this;
    self.urls = urls;

    self.getUserNotes = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/note/RetrieveUsersNotes/' + id,//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new NoteModel(item);
                });
                handler(mappedData);
            }
        });
    };

    self.getGroupNotes = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/note/RetrieveGroupsNotes/' + id,//localhost:59284 skynoteasiatest.azurewebsites.net
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new NoteInGroupModel(item);
                });
                handler(mappedData);
            }
        });
    };



    self.getNotesByLocation = function (handler, userId, xCord, yCord, radius, categoryId, typeId, groupIds) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/note/NotesByLocation?userId=' + userId
                + '&xCord=' + xCord
                + '&yCord=' + yCord
                + '&radius=' + radius
                + '&categoryId=' + categoryId
                + '&typeId=' + typeId
                + '&groupIds=' + groupIds,
            type: 'GET',
            success: function (data) {
                var mappedData = new NotesByLocationModel(data);
                handler(mappedData);
            }
        });
    };

    self.getNotesByLocationViewModel = function (handler, userId, xCord, yCord, radius, categoryId, typeId, groupIds) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/note/NotesByLocationViewModel?userId=' + userId
                + '&xCord=' + xCord
                + '&yCord=' + yCord
                + '&radius=' + radius
                + '&categoryId=' + categoryId
                + '&typeId=' + typeId
                + '&groupIds=' + groupIds,
            type: 'GET',
            success: function (data) {
                var mappedData = new NotesByLocationViewModel(data, xCord, yCord);
                handler(mappedData);
            }
        });
    };

    self.getMyNotesViewModel = function (id, handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/note/MyNotesViewModel/' + id,
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
            url: 'http://localhost:59284/api/note/get/' + id,
            type: 'GET',
            success: function (data) {
                var mappedData = new NoteDetailsViewModel(data);
                handler(mappedData);
            }
        });
    };

    self.addNote = function (note, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/note/addnewnote',
            type: 'POST',
            data: note,
            contentType: 'application/json',
            success: function (data) {
                showAlertAfterAjax(data, 'Note ' + JSON.parse(note).Topic + ' successfuly added.');
                handler(data);
            }
        });
    }

    self.editNote = function (note, handler) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/note/put',
            type: 'PUT',
            data: note,
            contentType: 'application/json',
            success: function (data) {
                showAlertAfterAjax(data, 'Note ' + JSON.parse(note).Topic + ' successfuly edited.');
                handler(data);
            }
        });
    }

    self.deleteNote = function (note) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/note/delete/' + note.NoteId(),
            type: 'DELETE',
            success: function (data) {
                showAlertAfterAjax(data, 'Note ' + note.Topic() + ' successfuly deleted.');
            }
        });
    }

    self.shareNote = function (note) {
        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/note/ShareNoteInGroup/',
            type: 'POST',
            data: note,
            success: function (data) {
                var i = data;
            }
        });
    }

};