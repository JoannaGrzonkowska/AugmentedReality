
var NoteService = function (urls) {
    var self = this;
    self.urls = urls;

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

    self.getCategories = function (handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://skynoteasiatest.azurewebsites.net/api/Category/CategoriesSelectList',
            type: 'GET',
            success: function (data) {
                var mappedData = $.map(data, function (item) {
                    return new CategoryModel(item);
                });
                handler(mappedData);
            }
        });
    };
};