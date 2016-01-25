$(document).ready(function () {
    var submitButton = $('#clientAnswerSubmit select');
    submitButton.click(function () {
        var answerValue = $('#clientAnswers').val();
        GetStuffList(categoryValue);
    });
});

function GetStuffList(categoryValue) {
    StuffSelection_Proxy.GetStuffListHttpGet(categoryValue,
               successCallback, failureCallback);
}

var successCallback = function (data) {
    var response = eval(data.d);
    $('#divStuffList').html(response[0].Name + ' ' +
             response[0].Description + ' (€ ' + response[0].Price + ')');
}

var failureCallback = function (data) {
    alert('Request failure');
}