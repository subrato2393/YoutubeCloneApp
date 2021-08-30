$(document).on('click', '#btnCopy', function () {
    var value = $('#txtUrl').val();
    $('#btnCopy').html("Copied");
    $('#btnCopy').prop('disabled', true);
    copytext(value, this);
})

function copytext(text, context) {
    var textField = document.createElement('textarea');
    textField.innerText = text;

    if (context) {
        context.parentNode.insertBefore(textField, context);
    } else {
        document.body.appendChild(textField);
    }

    textField.select();
    document.execCommand('copy');
    textField.parentNode.removeChild(textField);
}