
var CategoriesService = function () {
    var self = this;

    self.getCategoriesSelectList = function (handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: Paths.serverUrl + 'Category/CategoriesSelectList',
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



