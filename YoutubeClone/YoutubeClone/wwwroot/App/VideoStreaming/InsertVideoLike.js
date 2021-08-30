//Insert Like into Database
$('#btnLike').click(function () {
    addLikeIntoDatabase();

    function addLikeIntoDatabase() {
        $.when(
            $.ajax({
                method: 'POST',
                dataType: 'JSON',
                url: '/Like/AddLike',
                data: {
                    videoId: videoId,
                },
                beforeSend: function () {
                    $("#btnLike").html("<i class='fas fa-circle-notch fa-spin'></i>");
                },
                success: function (data) {
                    if (data.isLikedBefore == true) {
                        deleteLike(data);
                    }
                    else {
                        $("#btnLike").removeClass("btn btn-outline-success").addClass("btn btn-success");
                    }
                    getLike();
                },
                complete: function () {
                },
                error: function () {
                    window.location.href = '/Account/Login';
                }
            }),
        );
    }
    function deleteLike(result) {
        $.ajax({
            dataType: 'JSON',
            url: '/Like/Deletelike',
            data: {
                videoId: videoId,
            },
            success: function (data) {
                $('#btnLike').html("<span><i class='fas fa-thumbs-up mr-1'></i></span>" + data.likeCount)
                $("#btnLike").removeClass("btn btn-success").addClass("btn btn-outline-success");
            }
        })
    }
    function getLike() {
        $.ajax({
            dataType: 'JSON',
            url: '/Like/GetLike',
            data: {
                videoId: videoId,
            },
            success: function (data) {
                $('#btnLike').html("<span><i class='fas fa-thumbs-up mr-1'></i></span>" + data.likeCount)
            }
        })
    }
})