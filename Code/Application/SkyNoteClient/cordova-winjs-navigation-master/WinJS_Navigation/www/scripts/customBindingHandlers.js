ko.bindingHandlers.localizedDateTime = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var date = moment(value);

        element.innerHTML = date.format('YYYY-MM-DD HH:mm');
    }
};

ko.bindingHandlers.localizedDate = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var date = moment(value);

        element.innerHTML = date.format('YYYY-MM-DD');
    }
};

ko.bindingHandlers.localizedDateWithDescription = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var date = moment(value);
        var todayDate = new Date();
        var htmlDateText;

        if (date.isSame(todayDate, 'day')) {
            htmlDateText = "Today";
        }
        else if (date.isSame(todayDate.setDate(todayDate.getDate() - 1), 'day')) {
            htmlDateText = "Yesterday";
        }
        else {
            htmlDateText = date.format('YYYY-MM-DD');
        }

        htmlDateText += " " + date.format('HH:mm');
        element.innerHTML = htmlDateText;
    }
};

ko.bindingHandlers.localizedTime = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var date = moment(value);

        element.innerHTML = date.format('HH:mm');
    }
};
