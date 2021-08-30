$("#comments").on('click', '#btnCommentLike', function () {
    var commentId = jQuery(this).val();
    $.when(
        //add comment like
        $.ajax({
            method: 'POST',
            url: '/CommentLike/AddCommentsLike',
            data: {
                commentId: commentId,
            },
            beforeSend: function () {
                $('#' + commentId).html("<i class='fas fa-circle-notch fa-spin'></i>");
            },
            success: function (data) {
                // console.log(data)
                //Get comment like
                $.ajax({
                    dataType: 'JSON',
                    url: '/CommentLike/GetCommentLike',
                    data: {
                        commentId: commentId,
                    },
                    success: function (data) {
                        var id = commentId;
                        //alert(id)
                        $('#' + id).text(data.likeCount)
                        //  window.location.href = '/CommentLike/GetAllCommentsLike'
                        // $('#likeValue').text(data.likeCount)
                        // $('#btnCommentLike').html("<span><i class='fas fa-thumbs-up mr-1'></i></span>" + data.likeCount)
                    }
                })
            },
            complete: function () {
                /* $("#loads").hide();*/
            },
        }),


    )
})