function like(postId) {
    var likeInfo = { postId: postId };
    console.log(postId);
    $.ajax({
        url: "/api/likes",
        type: "POST",
        data: JSON.stringify(likeInfo),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var elementId = "#likesCount-" + postId
            $(elementId).html(data.likesCount)
        }   
    });
}