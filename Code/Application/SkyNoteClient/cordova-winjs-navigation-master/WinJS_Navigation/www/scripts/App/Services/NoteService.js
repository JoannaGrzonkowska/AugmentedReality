var NoteService = function (urls) {
    var self = this;
    self.urls = urls;

    self.addNote = function (note, handler) {
         $.ajaxSetup({ cache: false });

         $.ajax({
             url: 'http://localhost:59284/api/note',
             type: 'POST',
             data: note,
             success: function (data) {
                // if (data.IsSuccess) {
                     //$("#success-message").html("OK").show();
                     handler();
                /* } else {
                     //$(".alert").html(data.ErrorsToString).show();
                 }*/
             }
         });
    }
};