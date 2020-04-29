function follow(userId) {
    var followInfo = { userId: userId };
    var token = $("#followsForm input[name=__RequestVerificationToken]").val();
    $.ajax({
        url: "/api/follows",
        type: "POST",
        data: JSON.stringify(followInfo),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            var followButtonId = "#follow-button";
            var followButton = $(followButtonId);
            if ($(followButtonId).html() == "Follow") {
                $(followButtonId).html("Unfollow");
                $(followButtonId).removeClass("btn-primary");
                $(followButtonId).addClass("btn-danger");
            } else {
                $(followButtonId).html("Follow");
                $(followButtonId).removeClass("btn-danger");
                $(followButtonId).addClass("btn-primary");
            }
        } 
    })
}