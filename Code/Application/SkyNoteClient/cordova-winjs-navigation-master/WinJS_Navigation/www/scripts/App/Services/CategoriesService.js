var CategoriesService = function (urls) {
    var self = this;
    self.urls = urls;

    self.getCategoriesSelectList = function (handler) {

        $.ajaxSetup({ cache: false });

        $.ajax({
            url: 'http://localhost:59284/api/Category/CategoriesSelectList',
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