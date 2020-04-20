function like(postId) {
    var likeInfo = { postId: postId };
    var token = $("#likesForm input[name=__RequestVerificationToken]").val();
    $.ajax({
        url: "/api/likes",
        type: "POST",
        data: JSON.stringify(likeInfo),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            var elementId = "#likesCount-" + postId
            $(elementId).html(data.likesCount)
        }   
    });
}