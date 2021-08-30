//Insert video view into Database
function reset() {
    startTime = new Date();
}

$('video')[0].addEventListener('play', reset);
$('video')[0].addEventListener('pause', reset);
$('video')[0].addEventListener('stop', reset);

var IsPlayed = true;

$('video')[0].addEventListener('timeupdate', (e) => {
    let elapsedSeconds = (new Date() - startTime) / 1000;
    if (elapsedSeconds > 10 && IsPlayed) {
        IsPlayed = false;

        $.ajax(
            {
                type: 'POST',
                dataType: 'JSON',
                url: '/VideoView/AddVideoView',
                data: { videoId: videoId },
            });
    }
});

