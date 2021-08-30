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
                getCommentLike(data);
            },
            complete: function () {
            },
        }),
    )
    function getCommentLike(result) {
        $.ajax({
            dataType: 'JSON',
            url: '/CommentLike/GetCommentLike',
            data: {
                commentId: commentId,
            },
            success: function (data) {
                var id = commentId;
                $('#' + id).text(data.likeCount)
            }
        })
    }
})