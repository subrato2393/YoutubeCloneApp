function hideCommentReply(commentId) {
    $('#txtBoxReply' + commentId).hide();
    $('#btnCancel' + commentId).hide();
    $('#btnReply' + commentId).hide();
}

$("#comments").on('click', '#btnCommentReply', function () {
    var commentId = jQuery(this).val();


    // alert(commentId)
    $('#txtReply' + commentId).show();
    $('#btnCancel' + commentId).click(function () {
        hideCommentReply(commentId);
    });

    $('#btnReply' + commentId).click(function () {
        var commentReply = {
            commentId: commentId,
            videoId: videoId,
            description: $('#txtBoxReply' + commentId).val(),
        };
        addCommentReply(commentReply)

        function addCommentReply(commentReply) {
            $.ajax({
                dataType: 'JSON',
                method: 'POST',
                url: '/CommentsReply/AddCommentsReply',
                contentType: "application/json",
                data: JSON.stringify(commentReply),

                success: function (data) {
                    hideCommentReply(commentId);
                    getCurrentCommentReply(commentId);
                }
            })

        }
        function getCurrentCommentReply() {
            $.ajax(
                {
                    type: 'POST',
                    dataType: 'JSON',
                    url: '/CommentsReply/GetCurrentCommentReply',
                    data: { commentId: commentId },
                    success: function (data) {
                        console.log(data)
                        $('#divCommentReply' + commentId).append(`<div>${data.userName}</div><div>${data.description}</div><button style="background-color:Transparent" id="btnCommentLike" data-toggle="tooltip" data-placement="top" title="Like" value=${data.id}>
                        <span><i class="far fa-thumbs-up mr-1"></i></span>
                        <span class="ml-1"></span>
                    </button>
                    <button class="ml-3" style="background-color:Transparent" id="btnCommentReply" data-toggle="tooltip" data-placement="top" title="Reply" value=${data.id}>
                                            Reply
                    </button>`)
                    }
                });
        }
    })
})