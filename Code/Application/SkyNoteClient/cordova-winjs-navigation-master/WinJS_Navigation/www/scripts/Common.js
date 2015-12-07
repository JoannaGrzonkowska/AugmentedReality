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

    var R = 6378137; // Earth’s mean radius in meter
    var dLat = rad(otherLatitude - latitude);
    var dLong = rad(otherLongitude - longitude);
    var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
      Math.cos(rad(latitude)) * Math.cos(rad(otherLatitude)) *
      Math.sin(dLong / 2) * Math.sin(dLong / 2);
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = R * c;
    return d/1000; // returns the distance in km
};