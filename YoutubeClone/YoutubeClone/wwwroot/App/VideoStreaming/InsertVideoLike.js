//Insert Like into Database
$('#btnLike').click(function () {
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
                else {
                    $("#btnLike").removeClass("btn btn-outline-success").addClass("btn btn-success");
                }
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
            },
            complete: function () {
                /* $("#loads").hide();*/
            },
            error: function () {
                window.location.href = '/Account/Login';
            }
        }),
    );

})