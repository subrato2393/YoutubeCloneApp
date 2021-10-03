//Get All comments from Database
$.ajax({
    dataType: 'JSON',
    url: '/Comment/GetComments',
    data: {
        videoId: videoId,
    },
    success: function (data) {
        $.each(data, function (key, value) {
            var div = generateDivForGetAllComments(value);
            $('#comments').append(div);
        });
    }
})
function generateDivForGetAllComments(value) {
    var div = `<div class="col-1">
                <div><img class="channel-icon" src="/user/thumbnil.jpg" /></div></div>
                <div class="col-11 mb-4">
                <div>${value.userName}</div>
                <div>
                 ${value.description}
                </div>
                <div>
                    <button style="background-color:Transparent" id="btnCommentLike" data-toggle="tooltip" data-placement="top" title="Like" value=${value.id}>
                        <span><i class="far fa-thumbs-up mr-1"></i></span>
                        <span class="ml-1" id='${value.id}'>${value.likeCount}</span>
                    </button>
                
                </div>
                <div class='row mt-3'>
                 <div id='txtReply${value.id}' style='display:none'>
                    <input id='txtBoxReply${value.id}' class='form-control'  type='text' >
                      <button id='btnReply${value.id}' type="submit" class="btn btn-success btn-sm float-right ml-2 mt-2">Reply</button>
                      <button id='btnCancel${value.id}' type="submit" class="btn btn-success btn-sm float-right mt-2">Cancel</button>
                 </div>
                  <div>
                   
                   </div>
                   </div>`
    return div;
}

//Insert and get Comments
$('#btnComment').click(function () {
    var comment = {
        videoId: videoId,
        description: $('#txtComment').val(),
    };

    $('#txtComment').val('');
    addCommentIntoDatabase(comment);

    function addCommentIntoDatabase(comment) {
        $.ajax({
            method: 'POST',
            url: '/Comment/AddComment',
            contentType: "application/json",
            data: JSON.stringify(comment),
            beforeSend: function () {

            },
            success: function (data) {
                getCurrentComment(data);

            },
            error: function () {
                window.location.href = '/Account/Login'
            },
            complete: function () {

            }
        })
    }
    function getCurrentComment(result) {
        $.ajax({
            method: 'POST',
            url: '/Comment/GetCurrentComment',
            data: {
                videoId: videoId,
            },

            success: function (data) {
                console.log(data);

                var div = ` <div class="col-1">
                <div><img class="channel-icon" src="/user/thumbnil.jpg" /></div>
                 </div>
                <div class="col-11 mb-4">
                <div>${data.userName}</div>
                <div>
                 ${data.description}
                </div>
                <div>
                    <button style="background-color:Transparent" id="btnCommentLike" data-toggle="tooltip" data-placement="top" title="Like" value=${data.id}>
                        <span><i class="far fa-thumbs-up mr-1"></i></span>
                        <span class="ml-1" id='${data.id}'>${data.likeCount}</span>
                    </button>
                    <button class="ml-3" style="background-color:Transparent" id="btnCommentReply" data-toggle="tooltip" data-placement="top" title="Reply" value=${data.id}>
                        Reply
                    </button>
                </div>
                <div id='txtReply${data.id}' style='display:none'>
                   <input id='txtBoxReply${data.id}' class='form-control'  type='text' >
                      <button id='btnReply${data.id}' type="submit" class="btn btn-success btn-sm float-right ml-2 mt-2">Reply</button>
                      <button id='btnCancel${data.id}' type="submit" class="btn btn-success btn-sm float-right mt-2">Cancel</button>
                 </div>
                 </div>`
                $('#comments').prepend(div);
            },
            error: function () {
                alert("Error")
            }
        })
    }
})