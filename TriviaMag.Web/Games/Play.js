$(document).ready(function () {
    var submitButton = $('#clientAnswerSubmit select');
    submitButton.click(function () {
        var answerValue = $('#clientAnswers').val();
        GetStuffList(categoryValue);
    });
});