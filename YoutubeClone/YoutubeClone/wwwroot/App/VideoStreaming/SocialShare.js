//for demo purpose when this site will go live then use this site url
var pageURL = 'https://www.c-sharpcorner.com/UploadFile/cd7c2e/sharing-url-on-facebok-using-Asp-Net/';

//If click share button textbox will fill url link
$('#btnShares').click(function () {
    var pageURL = $(location).attr('href');
    $('#txtUrl').val(pageURL);
});

$('#linkFacebook').click(function () {
    var link = $('#linkFacebook');
    link.attr('href', link.attr('href') + pageURL);
})

$('#linkLinkdin').click(function () {
    var link = $('#linkLinkdin');
    link.attr('href', link.attr('href') + pageURL);
})

$('#linkTwitter').click(function () {
    var link = $('#linkTwitter');
    link.attr('href', link.attr('href') + pageURL);
})

$('#linkGooglePlus').click(function () {
    var link = $('#linkGooglePlus');
    link.attr('href', link.attr('href') + pageURL);
})