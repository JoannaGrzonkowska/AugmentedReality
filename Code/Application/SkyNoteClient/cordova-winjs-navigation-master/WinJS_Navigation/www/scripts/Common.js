function showAlert(message, isSuccess) {
    var iconToUse = isSuccess ? "success" : "warning";
    var $div = $('<div/>').addClass("alert alert-" + iconToUse);
    $div.append('<button type="button" class="close" data-dismiss="alert">&times;</button>')
    $div.append(message);
    $div.prependTo('#alerts');

};

function showAlertAfterAjax(data, successfulMessage) {
    var message = data.IsSuccess ? successfulMessage : data.ErrorsToString;
    showAlert(message, data.IsSuccess);
};

var rad = function (x) {
    return x * Math.PI / 180;
};

function calcDistance(longitude, latitude, otherLongitude, otherLatitude) {
    var R = 6367;
    var distance = R * Math.acos(Math.cos(rad(latitude)) * Math.cos(rad(otherLatitude)) *
         Math.cos(rad(otherLongitude) - rad(longitude)) +
         Math.sin(rad(latitude)) * Math.sin(rad(otherLatitude)));
    return distance.toFixed(3); //  distance in km
};

var Paths = {
    serverUrl: 'http://localhost:59284/api/' //'http://skynoteasiatest.azurewebsites.net/api/'
};