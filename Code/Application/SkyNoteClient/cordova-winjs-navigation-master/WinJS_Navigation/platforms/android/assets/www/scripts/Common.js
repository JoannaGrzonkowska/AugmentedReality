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
}